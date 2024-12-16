using CSharpEgitimKampi301.BusinessLayer.Abstract;
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
    public partial class FrmProduct : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public FrmProduct()
        {
            _productService = new ProductManager(new EfProductDal());
            _categoryService = new CategoryManager(new EfCategoryDal());
            InitializeComponent();
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            var productsValues = _productService.TGetAll();
            dataGridView1.DataSource = productsValues;
        }

        private void btnList2_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetProductsWithCategory();
            dataGridView1.DataSource = values;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var deleteProduct = _productService.TGetById(id);
            _productService.TDelete(deleteProduct);
            MessageBox.Show("Ürün Silindi");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.ProductName = txtProductName.Text;
            product.ProductStock = int.Parse(txtProductStock.Text);
            product.ProductPrice=decimal.Parse(txtProductPrice.Text);
            product.CategoryId = int.Parse(cmbCategory.SelectedValue.ToString());
            product.ProductDescription=txtDescription.Text;
            _productService.TInsert(product);
            MessageBox.Show("Ekleme işlemi yapıldı");

        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var values = _productService.TGetById(id);
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var updateProduct = _productService.TGetById(id);
            updateProduct.ProductName = txtProductName.Text;
            updateProduct.ProductPrice = decimal.Parse(txtProductPrice.Text);
            updateProduct.ProductStock= int.Parse(txtProductStock.Text);
            updateProduct.CategoryId = int.Parse(cmbCategory.SelectedValue.ToString());
            updateProduct.ProductDescription= txtDescription.Text;
            _productService.TUpdate(updateProduct);
            MessageBox.Show("Ürün Güncellendi");
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            var values = _categoryService.TGetAll();
            cmbCategory.DataSource = values;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";
        }
    }
}
