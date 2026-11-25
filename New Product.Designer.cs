namespace PharmaGo
{
    partial class New_Product
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtName = new TextBox();
            nameLabel = new Label();
            categoryLabel = new Label();
            priceLabel = new Label();
            btnAdd = new Button();
            btnRemove = new Button();
            btnUpdate = new Button();
            btnRefresh = new Button();
            btnClear = new Button();
            dgvProducts = new DataGridView();
            cmbCategory = new ComboBox();
            numPrice = new NumericUpDown();
            numQuantity = new NumericUpDown();
            quantityLabel = new Label();
            dtpExpiry = new DateTimePicker();
            expDateLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(22, 39);
            txtName.Name = "txtName";
            txtName.Size = new Size(193, 27);
            txtName.TabIndex = 0;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Microsoft Sans Serif", 9F);
            nameLabel.Location = new Point(22, 18);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(48, 18);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "Name";
            // 
            // categoryLabel
            // 
            categoryLabel.AutoSize = true;
            categoryLabel.Font = new Font("Microsoft Sans Serif", 9F);
            categoryLabel.Location = new Point(22, 72);
            categoryLabel.Name = "categoryLabel";
            categoryLabel.Size = new Size(68, 18);
            categoryLabel.TabIndex = 3;
            categoryLabel.Text = "Category";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Font = new Font("Microsoft Sans Serif", 9F);
            priceLabel.Location = new Point(22, 126);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(42, 18);
            priceLabel.TabIndex = 5;
            priceLabel.Text = "Price";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(60, 128, 125);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(22, 313);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(193, 29);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add New Product";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.FromArgb(60, 128, 125);
            btnRemove.Cursor = Cursors.Hand;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold);
            btnRemove.ForeColor = Color.White;
            btnRemove.Location = new Point(22, 355);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(193, 29);
            btnRemove.TabIndex = 7;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(60, 128, 125);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(22, 399);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(193, 29);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Update Product";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(60, 128, 125);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(567, 344);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(193, 29);
            btnRefresh.TabIndex = 9;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(60, 128, 125);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(567, 388);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(193, 29);
            btnClear.TabIndex = 10;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(272, 21);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(488, 274);
            dgvProducts.TabIndex = 11;
            dgvProducts.CellClick += dgvProducts_CellClick;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(22, 95);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(193, 28);
            cmbCategory.TabIndex = 12;
            // 
            // numPrice
            // 
            numPrice.Location = new Point(22, 149);
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(193, 27);
            numPrice.TabIndex = 13;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(22, 204);
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(193, 27);
            numQuantity.TabIndex = 15;
            // 
            // quantityLabel
            // 
            quantityLabel.AutoSize = true;
            quantityLabel.Font = new Font("Microsoft Sans Serif", 9F);
            quantityLabel.Location = new Point(22, 181);
            quantityLabel.Name = "quantityLabel";
            quantityLabel.Size = new Size(62, 18);
            quantityLabel.TabIndex = 14;
            quantityLabel.Text = "Quantity";
            // 
            // dtpExpiry
            // 
            dtpExpiry.Font = new Font("Microsoft Sans Serif", 9F);
            dtpExpiry.Location = new Point(22, 262);
            dtpExpiry.Name = "dtpExpiry";
            dtpExpiry.Size = new Size(193, 24);
            dtpExpiry.TabIndex = 16;
            // 
            // expDateLabel
            // 
            expDateLabel.AutoSize = true;
            expDateLabel.Font = new Font("Microsoft Sans Serif", 9F);
            expDateLabel.Location = new Point(22, 239);
            expDateLabel.Name = "expDateLabel";
            expDateLabel.Size = new Size(83, 18);
            expDateLabel.TabIndex = 17;
            expDateLabel.Text = "Expiry Date";
            // 
            // New_Product
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(251, 247, 238);
            ClientSize = new Size(800, 450);
            Controls.Add(expDateLabel);
            Controls.Add(dtpExpiry);
            Controls.Add(numQuantity);
            Controls.Add(quantityLabel);
            Controls.Add(numPrice);
            Controls.Add(cmbCategory);
            Controls.Add(dgvProducts);
            Controls.Add(btnClear);
            Controls.Add(btnRefresh);
            Controls.Add(btnUpdate);
            Controls.Add(btnRemove);
            Controls.Add(btnAdd);
            Controls.Add(priceLabel);
            Controls.Add(categoryLabel);
            Controls.Add(nameLabel);
            Controls.Add(txtName);
            Name = "New_Product";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "New_Product";
            Load += New_Product_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private Label nameLabel;
        private Label categoryLabel;
        private Label priceLabel;
        private Button btnAdd;
        private Button btnRemove;
        private Button btnUpdate;
        private Button btnRefresh;
        private Button btnClear;
        private DataGridView dgvProducts;
        private ComboBox cmbCategory;
        private NumericUpDown numPrice;
        private NumericUpDown numQuantity;
        private Label quantityLabel;
        private DateTimePicker dtpExpiry;
        private Label expDateLabel;
    }
}