using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace WinDbFirst
{
    public partial class EfSorgular : Form
    { 
        NorthwindEntities db=new NorthwindEntities();
        public EfSorgular()
        {
            InitializeComponent();
        }

        private void EfSorgular_Load(object sender, EventArgs e)
        {

            



        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region soru
            //siparisler tablosundan musterisirketadi,calısanın adi,calısan soyadi,sipariş ıd,siparis tarihi,kargo sirketinin adi
            #region Linq to Sql(Method Yöntemi)
            var result = db.Orders
                .OrderBy(x=> x.OrderID)
                .Select(p => new
            {
                MusteriAdi=p.Customers.CompanyName,
                CalisanAdi=p.Employees.FirstName,
                CalisanSoyadi=p.Employees.LastName,
                SiparisId=p.OrderID,
                SiparisTarihi=p.OrderDate,
                Kargo=p.Shippers.CompanyName,
            });
           
            dataGridView1.DataSource = result.ToList();




            #endregion



            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region Soru
            //Fiyati 20 ile 50 arasında olan stoklarin Id,UrunAdi,Fiyati,StokMiktari gelsin

            #region Linq To sql (method yontemi)
            var query = db.Products
                .Where(x => x.UnitPrice >= 20 && x.UnitPrice <= 50)
                .OrderBy(x => x.ProductName)
                .Select(p => new
                {
                    p.ProductID,
                    p.ProductName,
                    p.UnitPrice,
                    p.QuantityPerUnit
                });

            dataGridView1.DataSource = query.ToList();
            #endregion

            #region Sql
            var query2 = from p in db.Products
                         where p.UnitPrice >= 20 && p.UnitPrice <= 50
                         orderby p.ProductName descending
                         select new
                         {
                             p.ProductID,
                             p.ProductName,
                             p.UnitPrice,
                             p.QuantityPerUnit
                         };
            dataGridView1.DataSource = query2.ToList();


            #endregion


            #endregion
        }

        private void button3_Click(object sender, EventArgs e)
        {
            #region Soru
            //Müsteri isimlerinde restaurante keli,mesi gecen kac kelime vardır
            #region Linq Method
            //var result = db.Customers.Where(p => p.CompanyName.Contains("restaurante"));
            //dataGridView1.DataSource=result.ToList();

            #region Linq to sql
            var result2 = from p in db.Customers
                          where p.CompanyName.Contains("restaurante")
                          select p;
            dataGridView1.DataSource = result2.ToList();

            #endregion

            #endregion

            #endregion
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //kategorisi seafood olan midyedolma urununu product tablosuna
            //fiyati 3.5 adeti 59 tane olacak sekilde ekleyin

            #region 1.yol
            Products midyeDolma = new Products();
            midyeDolma.ProductName = "midye dolma";
            midyeDolma.UnitPrice = 3.5m;
            midyeDolma.UnitsInStock = 59;
            var cat = db.Categories.Where(c => c.CategoryName == "SeaFood").FirstOrDefault();
            midyeDolma.CategoryID = cat.CategoryID;

            db.Products.Add(midyeDolma);
            db.SaveChanges(); 
            dataGridView1.DataSource=db.Products.Where(x=>x.ProductName=="midye dolma").ToList();
            #endregion

            #region 2.yol
            db.Products.Add(new Products
            {
                ProductName = "Kokarec",
                UnitPrice =30,
                UnitsInStock =0,
                CategoryID=db.Categories.Where(c=> c.CategoryName=="SeaFood").FirstOrDefault().CategoryID
            }) ;
            db.SaveChanges();
            #endregion


        }

        private void button5_Click(object sender, EventArgs e)
        {
            #region Soru
            //calisanlarin ad, soyad, dogum tarihi, ve yaslarini lissteleyin
            #region Linq to method
            var result = db.Employees.Select(p => new
            {
               AdSoyad= p.FirstName+" "+p.LastName,
               DogumTarihi=p.BirthDate,
               yas=SqlFunctions.DateDiff("year",p.BirthDate,DateTime.Now)
            });

            #endregion




            #endregion
            dataGridView1.DataSource=result.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            #region Soru
            //kategorilerine gore urun sayısı
            #region linq to sql
            var result = db.Products
                .GroupBy(p => p.Categories.CategoryName)
                .Select(g => new
                {
                    kategoriAdi = g.Key,
                    toplamstok = g.Sum(q => q.UnitsInStock)
                });
            dataGridView1.DataSource=result.ToList();



            #endregion





            #endregion
        }
    }
}
