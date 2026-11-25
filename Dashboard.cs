
using System;
using System.Data;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PharmaGo
{
    public partial class Dashboard : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Pharmago;Integrated Security=True;TrustServerCertificate=True;";

        FlowLayoutPanel categoryPanel;

        public Dashboard()
        {
            InitializeComponent();

            SetupDashboard();
            LoadCategories();
            LoadProducts();
        }

        private void SetupDashboard()
        {
            categoryPanel = new FlowLayoutPanel();

            categoryPanel.Dock = DockStyle.Top;
            categoryPanel.Height = 65;
            categoryPanel.BackColor = Color.FromArgb(240, 245, 250);
            categoryPanel.Padding = new Padding(10);
            categoryPanel.AutoScroll = true;

            this.Controls.Add(categoryPanel);
            categoryPanel.BringToFront();

            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(35, 90, 130);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;
            dataGridView1.ColumnHeadersHeight = 40;

            dataGridView1.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(190, 220, 240);
            dataGridView1.DefaultCellStyle.SelectionForeColor =
                Color.Black;
        }

        private void LoadCategories()
        {
            categoryPanel.Controls.Clear();

            Button allButton = new Button();

            allButton.Text = "All Products";
            StyleCategoryButton(allButton);
            allButton.Click += (s, e) => LoadProducts();

            categoryPanel.Controls.Add(allButton);

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query =
                        "SELECT CategoryID, CategoryName FROM Categories";

                    SqlDataAdapter adapter =
                        new SqlDataAdapter(query, con);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        int categoryID =
                            Convert.ToInt32(row["CategoryID"]);

                        string categoryName =
                            row["CategoryName"].ToString();

                        Button btn = new Button();

                        btn.Text = categoryName;
                        StyleCategoryButton(btn);

                        btn.Click += (s, e) =>
                            LoadProducts(categoryID);

                        categoryPanel.Controls.Add(btn);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StyleCategoryButton(Button btn)
        {
            btn.Width = 130;
            btn.Height = 40;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

            btn.BackColor = Color.FromArgb(35, 90, 130);
            btn.ForeColor = Color.White;

            btn.Font = new Font("Segoe UI", 10,
                FontStyle.Bold);

            btn.Cursor = Cursors.Hand;
            btn.Margin = new Padding(5);
        }

        private void LoadProducts()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT ProductID, ProductName,
                        Price, Quantity, ExpiryDate
                        FROM Products";

                    SqlDataAdapter adapter =
                        new SqlDataAdapter(query, con);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadProducts(int categoryID)
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT ProductID, ProductName,
                        Price, Quantity, ExpiryDate
                        FROM Products
                        WHERE CategoryID = @CategoryID";

                    SqlCommand cmd =
                        new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue(
                        "@CategoryID", categoryID);

                    SqlDataAdapter adapter =
                        new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        {
        }

        private int counter = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            counter--;
            label7.Text = counter.ToString();
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
            counter++;
            label7.Text = counter.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            New_Product newProductForm = new New_Product();
            newProductForm.Show();

            this.Hide();
        }
    }
}
