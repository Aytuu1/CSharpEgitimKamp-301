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
  public partial class FrmLocation : Form
  {
    public FrmLocation()
    {
      InitializeComponent();
    }
    EgitimKampıEfTravelDbEntities db = new EgitimKampıEfTravelDbEntities();
    private void btnList_Click(object sender, EventArgs e)
    {
      var values = db.TblLocation.ToList();
      dataGridView1.DataSource = values;

    }

    private void FrmLocation_Load(object sender, EventArgs e)
    {
      var values = db.TblGuide.Select(x => new
      {
        FullName=x.GuideName + " " +x.GuideSurname,
        x.GuideID
      }).ToList();

      cmbGuide.DisplayMember = "FullName";
      cmbGuide.ValueMember = "GuideID";
      cmbGuide.DataSource = values;
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      TblLocation location = new TblLocation();
      location.LocationCapacity = byte.Parse(nudCapacity.Value.ToString());
      location.LocationCity=txtCity.Text;
      location.LocationCountry=txtCountry.Text;
      location.LocationPrice = decimal.Parse(txtPrice.Text);
      location.DayNight = txtDayNight.Text;
      location.GuideID = int.Parse(cmbGuide.SelectedValue.ToString());
      db.TblLocation.Add(location);
      db.SaveChanges();
      MessageBox.Show("Ekleme Başarıyla Gerçekleştirildi");
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      int id = int.Parse(txtID.Text);
      var valueRemove = db.TblLocation.Find(id);
      db.TblLocation.Remove(valueRemove);
      db.SaveChanges();
      MessageBox.Show("Silme işlemi Başarıyla Gerçekleştirildi");


    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
      int id = int.Parse(txtID.Text);
      var valueUpdate = db.TblLocation.Find(id);
      valueUpdate.LocationPrice =decimal.Parse(txtPrice.Text);
      valueUpdate.LocationCapacity=byte.Parse(nudCapacity.Value.ToString());
      valueUpdate.LocationCity=txtCity.Text;
      valueUpdate.LocationCountry=txtCountry.Text;
      valueUpdate.DayNight=txtDayNight.Text;
      valueUpdate.GuideID = int.Parse(cmbGuide.SelectedValue.ToString());
      db.SaveChanges();
      MessageBox.Show("Güncelleme işlemi Başarıyla Gerçekleştirildi");
    }
  }
}
