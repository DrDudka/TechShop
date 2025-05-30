using Npgsql;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace УП_PR7.Forms
{
    public partial class DeliveryViewForm : Form
    {
        private readonly string connectionString = "Host=localhost;Database=tech_shop;Username=postgres;Password=123;Port=5433";

        public DeliveryViewForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"SELECT * FROM sales s
                        JOIN clients c ON c.client_id = s.client_id
                        JOIN products p ON p.product_id = s.product_id";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Panel panel = CreatePartnerPanel(reader);
                            flowLayoutPanel1.Controls.Add(panel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить данные: " + ex.Message);
            }
        }

        private Panel CreatePartnerPanel(NpgsqlDataReader reader)
        {
            Panel panel = new Panel()
            {
                Size = new Size(950, 175),
                BorderStyle = BorderStyle.Fixed3D,
                Margin = new Padding(10),
                BackColor = Color.FromArgb(0x03, 0x03, 0x95),
                Cursor = Cursors.Hand
            };
            panel.DoubleClick += (s, e) => OpenDeliveryEditForm();

            Label ClientName = new Label()
            {
                Location = new Point(10, 10),
                Text = reader["client_name"].ToString(),
                AutoSize = true,
                Font = new Font("Times New Roman", 16),
            };

            Label Address = new Label()
            {
                Location = new Point(10, 40),
                Text = $"Адрес: {reader["address"]}",
                AutoSize = true,
                Font = new Font("Times New Roman", 14),
            };

            Label Phone = new Label()
            {
                Location = new Point(10, 60),
                Text = $"Телефон: {reader["phone"]}",
                AutoSize = true,
                Font = new Font("Times New Roman", 14),
            };

            Label ProductName = new Label()
            {
                Location = new Point(10, 80),
                Text = $"Товар: {reader["product_name"]}",
                AutoSize = true,
                Font = new Font("Times New Roman", 14),
            };
            
            Label Category = new Label()
            {
                Location = new Point(10, 100),
                Text = $"Категория: {reader["category"]}",
                AutoSize = true,
                Font = new Font("Times New Roman", 14),
            };

            Label DeliveryDate = new Label()
            {
                Location = new Point(10, 120),
                Text = $"Дата доставки: {reader["delivery_date"]}",
                AutoSize = true,
                Font = new Font("Times New Roman", 14),
            };
            
            Label Status = new Label()
            {
                Location = new Point(10, 140),
                Text = $"Статус: {reader["status"]}",
                AutoSize = true,
                Font = new Font("Times New Roman", 14),
            };

            panel.Controls.Add(ClientName);
            panel.Controls.Add(Address);
            panel.Controls.Add(Phone);
            panel.Controls.Add(ProductName);
            panel.Controls.Add(Category);
            panel.Controls.Add(DeliveryDate);
            panel.Controls.Add(Status);

            return panel;
        }

        private void OpenDeliveryEditForm()
        {
            DeliveryEditForm deliveryEditForm = new DeliveryEditForm();
            deliveryEditForm.FormClosed += (s, args) => LoadData();
            deliveryEditForm.Show();
            this.Hide();
        }

        private void DeliveryViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonCart_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm();
            orderForm.Show();
            this.Hide();
        }
    }
}
