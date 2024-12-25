using CSharpEgitimKampı301.BusinessLayer.Abstract;
using CSharpEgitimKampı301.BusinessLayer.Concrete;
using CSharpEgitimKampı301.DataAccessLayer.EntityFrameWork;
using CSharpEgitimKampı301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampı301.PresentationLayer
{
  public partial class Form1 : Form
  {
    private readonly ICategoryService _categoryService;
    public Form1()
    {
      _categoryService = new CategoryManager(new EfCategoryDal());
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void btnList_Click(object sender, EventArgs e)
    {
      var categoryValues = _categoryService.TGetAll();
      dataGridView1.DataSource = categoryValues;
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      Category category = new Category();
      category.CategoryName = txtCategoryName.Text;
      category.CategoryStatus = true;
      _categoryService.TInsert(category);
      MessageBox.Show("Ekleme İşlemi Başarılı");
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      int id = int.Parse(txtCategoryID.Text);
      var values = _categoryService.TGetById(id);
      _categoryService.TDelete(values);
      MessageBox.Show("Silme İşlemi Başarılı");

    }

    private void btnGetById_Click(object sender, EventArgs e)
    {
      int id = int.Parse(txtCategoryID.Text);
      var values = _categoryService.TGetById(id);
      dataGridView1.DataSource = values;
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
      int updatedId = int.Parse(txtCategoryID.Text);
      var updatedValue = _categoryService.TGetById(updatedId);
      updatedValue.CategoryName = txtCategoryName.Text;
      updatedValue.CategoryStatus = true;
      _categoryService.TUpdate(updatedValue);
      MessageBox.Show("Güncelleme İşlemi Başarılı");

    }
  }
}
