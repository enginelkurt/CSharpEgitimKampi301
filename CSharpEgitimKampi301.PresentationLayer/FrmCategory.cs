using CSharpEgitimKampi301.BusinessLayer.Absract;
using CSharpEgitimKampi301.BusinessLayer.Concrete;
using CSharpEgitimKampi301.DataAccessLayer.EntityFramework;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.PresentationLayer
{
    public partial class FrmCategory : Form
    {
        private readonly ICategoryService _categoryService;
        private object txtCategoryId;

        public FrmCategory()
        {
            _categoryService = new CategoryManager(new EfCategoryDal());
            InitializeComponent();
        }

        

        private void btnList_Click(object sender, EventArgs e)
        {
            var categoryValues = _categoryService.TGetAll();
            dataGridView1.DataSource=categoryValues;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName=txtKategoriName.Text;
            category.CategorStatus = true;
            _categoryService.TInsert(category);
            MessageBox.Show("Ekleme basarili");


        }

        private object GetTxtCategoryId()
        {
            return txtCategoryId;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtKategoriId.Text);
            var deletedValues=_categoryService.TGetById(id);
            _categoryService.TDelete(deletedValues);
            MessageBox.Show("Silme basarili");

        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtKategoriId.Text);
            var values= _categoryService.TGetById(id);
            dataGridView1 .DataSource=values;
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
          
            int updatedId = int.Parse(txtKategoriId.Text);
            var updatedValue=_categoryService.TGetById(updatedId);
            updatedValue.CategoryName = txtKategoriName.Text;
            updatedValue.CategorStatus=true;
            _categoryService.TUpdate(updatedValue);
        }
    }

   
}
