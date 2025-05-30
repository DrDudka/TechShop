namespace УП_PR7.Forms
{
    partial class SaleEditForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaleEditForm));
            this.dataGridSale = new System.Windows.Forms.DataGridView();
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.comboBoxProduct = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.dateTimePickerSaleDate = new System.Windows.Forms.DateTimePicker();
            this.txtSum = new System.Windows.Forms.TextBox();
            this.dateTimePickerDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.comboBoxPriority = new System.Windows.Forms.ComboBox();
            this.buttonEditSale = new System.Windows.Forms.Button();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelCheque = new System.Windows.Forms.Label();
            this.labelProduct = new System.Windows.Forms.Label();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.labelClient = new System.Windows.Forms.Label();
            this.labelSaleDate = new System.Windows.Forms.Label();
            this.labelSum = new System.Windows.Forms.Label();
            this.labelDeliveryDate = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelPriority = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridSale
            // 
            this.dataGridSale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridSale.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(215)))), ((int)(((byte)(167)))));
            this.dataGridSale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSale.Location = new System.Drawing.Point(12, 12);
            this.dataGridSale.Name = "dataGridSale";
            this.dataGridSale.Size = new System.Drawing.Size(1714, 402);
            this.dataGridSale.TabIndex = 0;
            this.dataGridSale.SelectionChanged += new System.EventHandler(this.dataGridSale_SelectionChanged);
            // 
            // txtCheque
            // 
            this.txtCheque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(215)))), ((int)(((byte)(167)))));
            this.txtCheque.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCheque.Location = new System.Drawing.Point(47, 73);
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.Size = new System.Drawing.Size(200, 29);
            this.txtCheque.TabIndex = 2;
            // 
            // comboBoxProduct
            // 
            this.comboBoxProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(215)))), ((int)(((byte)(167)))));
            this.comboBoxProduct.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxProduct.FormattingEnabled = true;
            this.comboBoxProduct.Location = new System.Drawing.Point(47, 128);
            this.comboBoxProduct.Name = "comboBoxProduct";
            this.comboBoxProduct.Size = new System.Drawing.Size(200, 29);
            this.comboBoxProduct.TabIndex = 4;
            // 
            // txtQuantity
            // 
            this.txtQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(215)))), ((int)(((byte)(167)))));
            this.txtQuantity.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtQuantity.Location = new System.Drawing.Point(47, 190);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(200, 29);
            this.txtQuantity.TabIndex = 6;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(215)))), ((int)(((byte)(167)))));
            this.comboBoxClient.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(47, 252);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(200, 29);
            this.comboBoxClient.TabIndex = 8;
            // 
            // dateTimePickerSaleDate
            // 
            this.dateTimePickerSaleDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(215)))), ((int)(((byte)(167)))));
            this.dateTimePickerSaleDate.Location = new System.Drawing.Point(278, 252);
            this.dateTimePickerSaleDate.Name = "dateTimePickerSaleDate";
            this.dateTimePickerSaleDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerSaleDate.TabIndex = 10;
            // 
            // txtSum
            // 
            this.txtSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(215)))), ((int)(((byte)(167)))));
            this.txtSum.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSum.Location = new System.Drawing.Point(278, 190);
            this.txtSum.Name = "txtSum";
            this.txtSum.Size = new System.Drawing.Size(200, 29);
            this.txtSum.TabIndex = 12;
            this.txtSum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSum_KeyPress);
            // 
            // dateTimePickerDeliveryDate
            // 
            this.dateTimePickerDeliveryDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(215)))), ((int)(((byte)(167)))));
            this.dateTimePickerDeliveryDate.Location = new System.Drawing.Point(47, 309);
            this.dateTimePickerDeliveryDate.Name = "dateTimePickerDeliveryDate";
            this.dateTimePickerDeliveryDate.Size = new System.Drawing.Size(431, 20);
            this.dateTimePickerDeliveryDate.TabIndex = 14;
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(215)))), ((int)(((byte)(167)))));
            this.comboBoxStatus.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(278, 128);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(200, 29);
            this.comboBoxStatus.TabIndex = 16;
            // 
            // comboBoxPriority
            // 
            this.comboBoxPriority.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(215)))), ((int)(((byte)(167)))));
            this.comboBoxPriority.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxPriority.FormattingEnabled = true;
            this.comboBoxPriority.Location = new System.Drawing.Point(278, 73);
            this.comboBoxPriority.Name = "comboBoxPriority";
            this.comboBoxPriority.Size = new System.Drawing.Size(200, 29);
            this.comboBoxPriority.TabIndex = 18;
            // 
            // buttonEditSale
            // 
            this.buttonEditSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(149)))));
            this.buttonEditSale.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEditSale.ForeColor = System.Drawing.Color.White;
            this.buttonEditSale.Location = new System.Drawing.Point(47, 345);
            this.buttonEditSale.Name = "buttonEditSale";
            this.buttonEditSale.Size = new System.Drawing.Size(431, 46);
            this.buttonEditSale.TabIndex = 19;
            this.buttonEditSale.Text = "Редактировать";
            this.buttonEditSale.UseVisualStyleBackColor = false;
            this.buttonEditSale.Click += new System.EventHandler(this.buttonEditSale_Click);
            // 
            // buttonMenu
            // 
            this.buttonMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(149)))));
            this.buttonMenu.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMenu.ForeColor = System.Drawing.Color.White;
            this.buttonMenu.Location = new System.Drawing.Point(47, 397);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(431, 44);
            this.buttonMenu.TabIndex = 20;
            this.buttonMenu.Text = "Главная";
            this.buttonMenu.UseVisualStyleBackColor = false;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // labelCheque
            // 
            this.labelCheque.AutoSize = true;
            this.labelCheque.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCheque.Location = new System.Drawing.Point(43, 49);
            this.labelCheque.Name = "labelCheque";
            this.labelCheque.Size = new System.Drawing.Size(39, 21);
            this.labelCheque.TabIndex = 1;
            this.labelCheque.Text = "Чек";
            // 
            // labelProduct
            // 
            this.labelProduct.AutoSize = true;
            this.labelProduct.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelProduct.Location = new System.Drawing.Point(43, 105);
            this.labelProduct.Name = "labelProduct";
            this.labelProduct.Size = new System.Drawing.Size(58, 21);
            this.labelProduct.TabIndex = 3;
            this.labelProduct.Text = "Товар";
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelQuantity.Location = new System.Drawing.Point(43, 166);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(105, 21);
            this.labelQuantity.TabIndex = 5;
            this.labelQuantity.Text = "Количество";
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelClient.Location = new System.Drawing.Point(43, 228);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(68, 21);
            this.labelClient.TabIndex = 7;
            this.labelClient.Text = "Клиент";
            // 
            // labelSaleDate
            // 
            this.labelSaleDate.AutoSize = true;
            this.labelSaleDate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSaleDate.Location = new System.Drawing.Point(274, 228);
            this.labelSaleDate.Name = "labelSaleDate";
            this.labelSaleDate.Size = new System.Drawing.Size(122, 21);
            this.labelSaleDate.TabIndex = 9;
            this.labelSaleDate.Text = "Дата продажи";
            // 
            // labelSum
            // 
            this.labelSum.AutoSize = true;
            this.labelSum.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSum.Location = new System.Drawing.Point(275, 166);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(64, 21);
            this.labelSum.TabIndex = 11;
            this.labelSum.Text = "Сумма";
            // 
            // labelDeliveryDate
            // 
            this.labelDeliveryDate.AutoSize = true;
            this.labelDeliveryDate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDeliveryDate.Location = new System.Drawing.Point(43, 285);
            this.labelDeliveryDate.Name = "labelDeliveryDate";
            this.labelDeliveryDate.Size = new System.Drawing.Size(125, 21);
            this.labelDeliveryDate.TabIndex = 13;
            this.labelDeliveryDate.Text = "Дата доставки";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStatus.Location = new System.Drawing.Point(274, 106);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(65, 21);
            this.labelStatus.TabIndex = 15;
            this.labelStatus.Text = "Статус";
            // 
            // labelPriority
            // 
            this.labelPriority.AutoSize = true;
            this.labelPriority.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPriority.Location = new System.Drawing.Point(274, 49);
            this.labelPriority.Name = "labelPriority";
            this.labelPriority.Size = new System.Drawing.Size(97, 21);
            this.labelPriority.TabIndex = 17;
            this.labelPriority.Text = "Приоритет";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox1.Controls.Add(this.txtCheque);
            this.groupBox1.Controls.Add(this.dateTimePickerDeliveryDate);
            this.groupBox1.Controls.Add(this.labelDeliveryDate);
            this.groupBox1.Controls.Add(this.comboBoxStatus);
            this.groupBox1.Controls.Add(this.labelStatus);
            this.groupBox1.Controls.Add(this.txtSum);
            this.groupBox1.Controls.Add(this.labelSum);
            this.groupBox1.Controls.Add(this.comboBoxPriority);
            this.groupBox1.Controls.Add(this.labelPriority);
            this.groupBox1.Controls.Add(this.dateTimePickerSaleDate);
            this.groupBox1.Controls.Add(this.labelSaleDate);
            this.groupBox1.Controls.Add(this.buttonMenu);
            this.groupBox1.Controls.Add(this.buttonEditSale);
            this.groupBox1.Controls.Add(this.comboBoxClient);
            this.groupBox1.Controls.Add(this.labelClient);
            this.groupBox1.Controls.Add(this.labelCheque);
            this.groupBox1.Controls.Add(this.comboBoxProduct);
            this.groupBox1.Controls.Add(this.labelProduct);
            this.groupBox1.Controls.Add(this.txtQuantity);
            this.groupBox1.Controls.Add(this.labelQuantity);
            this.groupBox1.Location = new System.Drawing.Point(1198, 490);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(527, 484);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // SaleEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1737, 967);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridSale);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SaleEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактировать данные о продажах";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SaleEditForm_FormClosed);
            this.Load += new System.EventHandler(this.SaleEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridSale;
        private System.Windows.Forms.TextBox txtCheque;
        private System.Windows.Forms.ComboBox comboBoxProduct;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.ComboBox comboBoxClient;
        private System.Windows.Forms.DateTimePicker dateTimePickerSaleDate;
        private System.Windows.Forms.TextBox txtSum;
        private System.Windows.Forms.DateTimePicker dateTimePickerDeliveryDate;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.ComboBox comboBoxPriority;
        private System.Windows.Forms.Button buttonEditSale;
        private System.Windows.Forms.Button buttonMenu;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label labelCheque;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.Label labelClient;
        private System.Windows.Forms.Label labelSaleDate;
        private System.Windows.Forms.Label labelSum;
        private System.Windows.Forms.Label labelDeliveryDate;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelPriority;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}