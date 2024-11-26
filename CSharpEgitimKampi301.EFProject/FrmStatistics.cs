using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            #region Toplam Lokasyon Sayisi

            lblLocationCount.Text = db.Location.Count().ToString();
            lblSumCapacity.Text = db.Location.Sum(x => x.Capacity)?.ToString();
            lblGuideCount.Text = db.Guide.Count().ToString();
            lblAvgCapacity.Text = db.Location.Average(x => x.Capacity).ToString();
            lblAvgLocationPrice.Text = db.Location.Average(x => x.Price)?.ToString("0.00" + "TL");
            int LastCountryId = db.Location.Max(x => x.LocationId);
            lblLastCountryName.Text = db.Location.Where(x => x.LocationId == LastCountryId).Select(y => y.Countrty).FirstOrDefault();
            lblCappadociaLocationCapacity.Text = db.Location.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();
            lblTurkiyeCapacityAvg.Text = db.Location.Where(x => x.Countrty == "Türkiye").Average(y => y.Capacity).ToString();
            var veronaGuideId = db.Location.Where(x => x.City == "Verona").Select(y => y.GuideId).FirstOrDefault();
            lblVeronaGuideName.Text = db.Guide.Where(x => x.GuideId == veronaGuideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault();
            var maxCapacity = db.Location.Max(x => x.Capacity);
            lblMaxCapacityLocation.Text = db.Location.Where(x => x.Capacity == maxCapacity).Select(y => y.City).FirstOrDefault().ToString();
            var maxPrice = db.Location.Max(x => x.Price);
            lblMaxPriceLocation.Text = db.Location.Where(x => x.Price == maxPrice).Select(y => y.City).FirstOrDefault().ToString();
            var guideIdByNameAysegulCınar = db.Guide.Where(x => x.GuideName == "Aysegül" && x.GuideSurname == "Cınar").Select(y => y.GuideId).FirstOrDefault();
            lblAysegulCinarLocationCount.Text=db.Location.Where(x=>x.GuideId==guideIdByNameAysegulCınar).Count().ToString();



            #endregion
        }

    }
    }

