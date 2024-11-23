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
    public partial class FrmStatistic : Form
    {
        public FrmStatistic()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void FrmStatistic_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Location.Count().ToString();
            lblSumCapacity.Text = db.Location.Sum(x => x.Capacity).ToString();
            lblGuideCount.Text = db.Location.Count().ToString();
            lblAvgCapacity.Text = db.Location.Average(x => x.Capacity)?.ToString("0.00");
            lblAvgLocationPrice.Text = db.Location.Average(x => x.Price)?.ToString("0.00") + " ₺";

            int lastCountryId = db.Location.Max(x => x.LocationId);
            lblLastCountryName.Text = db.Location.Where(x => x.LocationId == lastCountryId).Select(y => y.Country).FirstOrDefault();

            lblCappadociaLocationCapacity.Text = db.Location.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();
            lblTurkiyeCapacityAvg.Text = db.Location.Where(x => x.Country == "Türkiye").Average(y => y.Capacity)?.ToString("0.00");

            var romeGuideId = db.Location.Where(x => x.City == "Roma").Select(y => y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text = db.Guide.Where(x => x.GuideId == romeGuideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();

            var maxCapacity = db.Location.Max(x => x.Capacity);
            lblMaxCapacityLocation.Text = db.Location.Where(x => x.Capacity == maxCapacity).Select(y => y.City).FirstOrDefault().ToString();

            var maxPrice = db.Location.Max(x => x.Price);
            lblMaxPriceLocation.Text = db.Location.Where(x => x.Price == maxPrice).Select(y => y.City).FirstOrDefault().ToString();

            var guideIdByNameAysegulCinar = db.Guide.Where(x => x.GuideName == "Ayşegül" && x.GuideSurname == "Çınar").Select(y => y.GuideId).FirstOrDefault();
            lblAysegulCinarLocationCount.Text = db.Location.Where(x => x.GuideId == guideIdByNameAysegulCinar).Count().ToString();

            Design();
        }
        private void Design() // Tasarım (ChatGpt sağolsun :) )
        {
            // Formda bulunan panelleri gez
            foreach (Panel panel in this.Controls.OfType<Panel>())
            {
                // Paneldeki tüm label'ları bul
                var labels = panel.Controls.OfType<Label>().ToList();

                // Eğer panelde iki label varsa
                if (labels.Count == 2)
                {
                    // Toplam etiket yüksekliğini hesapla (etiketlerin arasındaki mesafeye dikkat et)
                    int totalHeight = labels[0].Height + labels[1].Height;

                    // Yüksekliği ortalamak için başlangıç Y konumunu hesapla
                    int startY = (panel.Height - totalHeight) / 2;

                    // İlk etiketi yerleştir
                    labels[0].Location = new Point(
                        (panel.Width - labels[0].Width) / 2,
                        startY
                    );

                    // İkinci etiketi yerleştir
                    labels[1].Location = new Point(
                        (panel.Width - labels[1].Width) / 2,
                        startY + labels[0].Height // İkinci etiketin Y koordinatını birinci etiketten sonra ayarla
                    );
                }
            }
        }
    }
}
