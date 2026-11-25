using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace PharmaGo
{
    public partial class New_Product : Form
    {
        private const string ConnStr =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=Pharmago;Integrated Security=True;TrustServerCertificate=True";

        private int? selectedId = null;   // ProductID of the row picked in the grid

        public New_Product()
        {
            InitializeComponent();
        }

        private void New_Product_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadProducts();
        }

        private void LoadCategories()
        {
            using (var conn = new SqlConnection(ConnStr))
            using (var da = new SqlDataAdapter(
                "SELECT CategoryID, CategoryName FROM Categories ORDER BY CategoryName", conn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                cmbCategory.DataSource = dt;
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CategoryID";
            }
        }

        private void LoadProducts(string search = "")
        {
            const string sql = @"
                SELECT p.ProductID, p.ProductName, c.CategoryName, p.CategoryID,
                       p.Price, p.Quantity, p.ExpiryDate
                FROM Products p
                LEFT JOIN Categories c ON c.CategoryID = p.CategoryID
                WHERE p.ProductName LIKE @s
                ORDER BY p.ProductID DESC";

            using (var conn = new SqlConnection(ConnStr))
            using (var da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@s", "%" + search + "%");
                var dt = new DataTable();
                da.Fill(dt);
                dgvProducts.DataSource = dt;
            }

            dgvProducts.Columns["ProductID"].Visible = false;
            dgvProducts.Columns["CategoryID"].Visible = false;
            dgvProducts.Columns["ProductName"].HeaderText = "Product";
            dgvProducts.Columns["CategoryName"].HeaderText = "Category";
            dgvProducts.Columns["ExpiryDate"].HeaderText = "Expiry Date";
            dgvProducts.Columns["ExpiryDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter the product name.");
                txtName.Focus();
                return false;
            }
            if (cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("Please choose a category.");
                return false;
            }
            if (numPrice.Value <= 0)
            {
                MessageBox.Show("Price must be greater than 0.");
                numPrice.Focus();
                return false;
            }
            return true;
        }

        private void AddProductParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
            cmd.Parameters.AddWithValue("@cat", (int)cmbCategory.SelectedValue);
            cmd.Parameters.AddWithValue("@price", numPrice.Value);
            cmd.Parameters.AddWithValue("@qty", (int)numQuantity.Value);
            cmd.Parameters.AddWithValue("@exp", dtpExpiry.Value.Date);
        }

        private void ClearFields()
        {
            selectedId = null;
            txtName.Clear();
            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
            numPrice.Value = 0;
            numQuantity.Value = 0;
            dtpExpiry.Value = DateTime.Today;
            dgvProducts.ClearSelection();
            txtName.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            const string sql = @"INSERT INTO Products (ProductName, CategoryID, Price, Quantity, ExpiryDate)
                                 VALUES (@name, @cat, @price, @qty, @exp)";
            try
            {
                using (var conn = new SqlConnection(ConnStr))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    AddProductParameters(cmd);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Product added.");
                ClearFields();
                LoadProducts();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (selectedId == null)
            {
                MessageBox.Show("Select a product from the table first.");
                return;
            }
            if (MessageBox.Show("Delete this product?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                using (var conn = new SqlConnection(ConnStr))
                using (var cmd = new SqlCommand("DELETE FROM Products WHERE ProductID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", selectedId.Value);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                ClearFields();
                LoadProducts(txtName.Text);
            }
            catch (SqlException ex) when (ex.Number == 547)   // foreign key conflict
            {
                MessageBox.Show("This product is used in other records (e.g. sales), so it can't be deleted.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == null)
            {
                MessageBox.Show("Select a product from the table first.");
                return;
            }
            if (!ValidateInput()) return;

            const string sql = @"UPDATE Products
                                 SET ProductName=@name, CategoryID=@cat, Price=@price,
                                     Quantity=@qty, ExpiryDate=@exp
                                 WHERE ProductID=@id";
            try
            {
                using (var conn = new SqlConnection(ConnStr))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    AddProductParameters(cmd);
                    cmd.Parameters.AddWithValue("@id", selectedId.Value);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Product updated.");
                ClearFields();
                LoadProducts(txtName.Text);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            LoadProducts();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            LoadProducts(txtName.Text);
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvProducts.Rows[e.RowIndex];

            selectedId = Convert.ToInt32(row.Cells["ProductID"].Value);
            txtName.Text = row.Cells["ProductName"].Value?.ToString();
            cmbCategory.SelectedValue = Convert.ToInt32(row.Cells["CategoryID"].Value);
            numPrice.Value = Convert.ToDecimal(row.Cells["Price"].Value);
            numQuantity.Value = Convert.ToDecimal(row.Cells["Quantity"].Value);
            dtpExpiry.Value = Convert.ToDateTime(row.Cells["ExpiryDate"].Value);
        }
        
    }
}
