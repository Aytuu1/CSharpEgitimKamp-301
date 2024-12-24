using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampı301.EFProject
{
  public partial class Form1 : Form
  {
    EgitimKampıEfTravelDbEntities db = new EgitimKampıEfTravelDbEntities();
    public Form1()
    {
      InitializeComponent();
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void btnList_Click(object sender, EventArgs e)
    {

      var values = db.TblGuide.ToList();
      dataGridView1.DataSource = values;
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      TblGuide guide = new TblGuide();
      guide.GuideName = txtName.Text;
      guide.GuideSurname = txtSurname.Text;
      db.TblGuide.Add(guide);
      db.SaveChanges();
      MessageBox.Show("Rehber Başarıyla Eklendi");
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      int id = int.Parse(txtID.Text);
      var removeValue = db.TblGuide.Find(id);
      db.TblGuide.Remove(removeValue);
      db.SaveChanges();
      MessageBox.Show("Rehber başarıyla silindi");

    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
      int id = int.Parse(txtID.Text);
      var updateValue = db.TblGuide.Find(id);
      updateValue.GuideName = txtName.Text;
      updateValue.GuideSurname = txtSurname.Text;
      db.SaveChanges();
      MessageBox.Show("Rehber Başarıyla Güncellendi","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
    }

    private void btnGetByID_Click(object sender, EventArgs e)
    {
      
      int id = int.Parse(txtID.Text);
      var getById = db.TblGuide.Where(x=>x.GuideID== id).ToList();
      dataGridView1.DataSource= getById;
      
    }
  }
}
