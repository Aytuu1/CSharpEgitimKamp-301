using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampı301.EFProject
{
  public partial class FrmStatistics : Form
  {
    public FrmStatistics()
    {
      InitializeComponent();
    }
    EgitimKampıEfTravelDbEntities db = new EgitimKampıEfTravelDbEntities();

    private void label9_Click(object sender, EventArgs e)
    {

    }

    private void FrmStatistics_Load(object sender, EventArgs e)
    {
      #region Toplam Lokasyon Sayısı
      lblLocationCount.Text = db.TblLocation.Count().ToString();
      #endregion

      #region Toplam Kapasite
      lblTotalCapacity.Text = db.TblLocation.Sum(x => x.LocationCapacity).ToString();
      #endregion

      #region Rehber Sayısı
      lblGuideCount.Text = db.TblGuide.Count().ToString();
      #endregion

      #region Ortalama Kapasite
      lblAvgCapacity.Text = db.TblLocation.Average(x => x.LocationCapacity).ToString();
      #endregion

      #region Ortalama Tur Fiyatı
      lblAvgTourPrice.Text = db.TblLocation.Average(x => x.LocationPrice).ToString() + " ₺";

      #endregion

      #region Eklenen Son Ülke
      int lastCountryId = db.TblLocation.Max(x => x.LocationID);
      lblLastAddCountry.Text = db.TblLocation.Where(x => x.LocationID == lastCountryId).Select(y => y.LocationCountry).FirstOrDefault();
      #endregion

      #region Kapadokya Tur Kapasitesi

      lblCappadociaCapacity.Text = db.TblLocation.Where(x => x.LocationCity == "Kapadokya").Select(y => y.LocationCapacity).FirstOrDefault().ToString();

      #endregion

      #region Türkiye Turları Ortalama Kapasite
      lblTurkeyTourAvgCapacity.Text = db.TblLocation.Where(x => x.LocationCountry == "Türkiye").Average(y => y.LocationCapacity).ToString();

      #endregion

      #region Roma Gezisi Rehberi
      var romeGuidID = db.TblLocation.Where(x => x.LocationCity == "Roma Turistik").Select(y => y.GuideID).FirstOrDefault();

      lblRomeGuidName.Text = db.TblGuide.Where(x => x.GuideID == romeGuidID).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();


      #endregion

      #region En Yüksek Kapasiteli Tur
      var maxCapacity = db.TblLocation.Max(x => x.LocationCapacity);

      lblMaxCapacityTour.Text = db.TblLocation.Where(x => x.LocationCapacity == maxCapacity).Select(y => y.LocationCity).FirstOrDefault().ToString();
      #endregion

      #region En Pahalı Tur
      var maxLocationPrice = db.TblLocation.Max(x => x.LocationPrice);

      lblMaxPriceLocation.Text = db.TblLocation.Where(x => x.LocationPrice == maxLocationPrice).Select(y => y.LocationCity).FirstOrDefault().ToString();

      #endregion

      #region Ayşegül Çınar Tur Sayısı
      var guideIdByNameAysegulCınar = db.TblGuide.Where(x => x.GuideName == "Ayşegül" & x.GuideSurname == "Çınar").Select(y => y.GuideID).FirstOrDefault();



      lblAysegulCinarLocationCount.Text = db.TblLocation.Where(x => x.GuideID == guideIdByNameAysegulCınar).Count().ToString();
      #endregion


      



    }

    private void label20_Click(object sender, EventArgs e)
    {

    }

    private void lblGuideCount_Click(object sender, EventArgs e)
    {

    }

    private void label18_Click(object sender, EventArgs e)
    {

    }

    private void label15_Click(object sender, EventArgs e)
    {

    }
  }
}
