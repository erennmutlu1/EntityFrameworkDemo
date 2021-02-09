using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            dgwProducts.DataSource = _productDal.GetAll();
        }

        private void SearchProducts(string key)
        {
           // var result = _productDal.GetAll().Where(p=>p.Name.Contains(key)).ToList();
           var result = _productDal.GetByName(key);
           dgwProducts.DataSource = result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name= textBox1.Text,
                UnitPrice = Convert.ToDecimal(textBox2.Text),
                StockAmount = Convert.ToInt32(textBox3.Text)


            });
            LoadProducts();
            MessageBox.Show("Added!!");
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
          _productDal.Update(new Product
          {

              Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
              Name = textBox4.Text,
              UnitPrice = Convert.ToDecimal(textBox5.Text),
              StockAmount = Convert.ToInt32(textBox6.Text)

          });
          LoadProducts();
          MessageBox.Show("Updated!!!");
        }

        

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            textBox5.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            textBox6.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
           _productDal.Delete(new Product
           {
               Id= Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
           });
            LoadProducts();
            MessageBox.Show("Deleted!");
        }

        private void tbxsearch_TextChanged(object sender, EventArgs e)
        {
            SearchProducts(tbxsearch.Text);
        }
    }
}
