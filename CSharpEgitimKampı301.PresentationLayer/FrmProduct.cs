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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampı301.PresentationLayer
{
  public partial class FrmProduct : Form
  {
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    public FrmProduct()
    {
      _categoryService = new CategoryManager(new EfCategoryDal());
      _productService = new ProductManager(new EfProductDal());
      InitializeComponent();
    }


    private void label5_Click(object sender, EventArgs e)
    {

    }

    private void btnList_Click(object sender, EventArgs e)
    {
      var values = _productService.TGetAll();
      dataGridView1.DataSource = values;
    }

    private void btnList2_Click(object sender, EventArgs e)
    {
      var values = _productService.TgetProductWithCategory();
      dataGridView1.DataSource = values;
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      int id = int.Parse(txtProductID.Text);
      var deletedProduct = _productService.TGetById(id);
      _productService.TDelete(deletedProduct);
      MessageBox.Show("Ürün Başarıyla Silindi");
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      Product product = new Product();
      product.CategoryID = int.Parse(cmbCategoryID.Text);
      product.ProductStock = int.Parse(txtProductStock.Text);
      product.ProductName = txtProductName.Text;
      product.ProductPrice = decimal.Parse(txtProductPrice.Text);
      product.ProductDescription = txtDescription.Text;
      _productService.TInsert(product);
      MessageBox.Show("Ürün Başarıyla Eklendi");
    }

    private void btnGetById_Click(object sender, EventArgs e)
    {
      int id = int.Parse(txtProductID.Text);
      var getValue = _productService.TGetById(id);
      dataGridView1.DataSource = getValue;

    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
      int id = int.Parse(txtProductID.Text);
      var updateValue = _productService.TGetById(id);
      updateValue.CategoryID=int.Parse(cmbCategoryID.SelectedValue.ToString());
      updateValue.ProductName = txtProductName.Text;
      updateValue.ProductPrice = decimal.Parse(txtProductPrice.Text);
      updateValue.ProductDescription = txtDescription.Text;
      updateValue.ProductStock = int.Parse(txtProductStock.Text);
      _productService.TUpdate(updateValue);
      MessageBox.Show("Ürün Başarıyla güncellendi");
    }

    private void cmbCategoryID_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void FrmProduct_Load(object sender, EventArgs e)
    {
      var values = _categoryService.TGetAll();
      cmbCategoryID.DataSource = values;
      cmbCategoryID.DisplayMember = "CategoryName";
      cmbCategoryID.ValueMember = "CategoryId"; 
    }
  }
}
