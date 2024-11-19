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
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Location.ToList();
            dataGridView1.DataSource= values;
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.Guide.Select(x => new
            {
                FullName=x.GuideName+" " + x.GuideSurname,
                x.GuideId
            }).ToList();
            cmbGuide.DisplayMember = "FullName";
            cmbGuide.ValueMember = "GuideId";
            cmbGuide.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location locaciton = new Location();
            locaciton.Capacity =byte.Parse(nudCapacity.Value.ToString());
            locaciton.City = txtCity.Text;
            locaciton.Country = txtCountry.Text;
            locaciton.Prize = decimal.Parse(txtPrize.Text);
            locaciton.DayNight = txtDayNight.Text;
            locaciton.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            db.Location.Add(locaciton);
            db.SaveChanges();
            MessageBox.Show("Ekleme işlemi başarılı");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var deletedValue = db.Location.Find(id);
            db.Location.Remove(deletedValue);
            db.SaveChanges();
            MessageBox.Show("Silme işlemi başarılı");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updatedValue = db.Location.Find(id);
            updatedValue.City = txtCity.Text;
            updatedValue.Country = txtCountry.Text;
            updatedValue.Prize = decimal.Parse(txtPrize.Text);
            updatedValue.Capacity = byte.Parse(nudCapacity.Value.ToString());
            updatedValue.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Güncelleme İşlemi Başarılı");
        }
    }
}
