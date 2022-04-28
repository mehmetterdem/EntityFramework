using CodeFirstWin.Contexts;
using CodeFirstWin.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirstWin
{
    public partial class Form1 : Form
    {
        PostgreContext postgredb;
        public Form1()
        {
            InitializeComponent();
            postgredb = new PostgreContext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kategori kategori = new Kategori();
            kategori.KategoriAdi = textBox2.Text;
            kategori.Aciklama = textBox1.Text;
            //kategori.CreateDate = DateTime.Now;
            postgredb.Kategoriler.Add(kategori);
            postgredb.SaveChanges();
            dataGridView1.DataSource= postgredb.Kategoriler.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kategori kategori=new Kategori();
            
        }
    }
}
