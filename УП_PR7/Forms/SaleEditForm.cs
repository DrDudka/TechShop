using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace УП_PR7.Forms
{
    public partial class SaleEditForm : Form
    {
        private readonly string connectionString = "Host=localhost;Database=tech_shop;Username=postgres;Password=123;Port=5433";
        private readonly List<TextBox> requiredTextBoxes = new List<TextBox>();

        public SaleEditForm()
        {
            InitializeComponent();
            LoadData();
            ConfigureDataGridView();
            LoadComboBoxData();
        }

        private void LoadData()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT s.sale_id, s.cheque, p.product_name, s.quantity, c.client_name, 
                               s.sale_date, s.sum, s.delivery_date, s.status, s.priority
                        FROM sales s
                        JOIN products p ON s.product_id = p.product_id
                        JOIN clients c ON s.client_id = c.client_id
                        ORDER BY s.sale_date";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
                    {
                        DataTable dt = new DataTable();
                        NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                        adapter.Fill(dt);

                        dataGridSale.DataSource = dt;
                        dataGridSale.Columns["sale_id"].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ConfigureDataGridView()
        {
            dataGridSale.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridSale.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridSale.MultiSelect = false;
            dataGridSale.ReadOnly = true;

            dataGridSale.Columns["cheque"].HeaderText = "Чек";
            dataGridSale.Columns["product_name"].HeaderText = "Товар";
            dataGridSale.Columns["quantity"].HeaderText = "Количество";
            dataGridSale.Columns["client_name"].HeaderText = "Клиент";
            dataGridSale.Columns["sale_date"].HeaderText = "Дата продажи";
            dataGridSale.Columns["sum"].HeaderText = "Сумма";
            dataGridSale.Columns["delivery_date"].HeaderText = "Дата доставки";
            dataGridSale.Columns["status"].HeaderText = "Статус";
            dataGridSale.Columns["priority"].HeaderText = "Приоритет";
        }

        private void LoadComboBoxData()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Загрузка товаров
                    string productQuery = "SELECT product_id, product_name FROM products ORDER BY product_name";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(productQuery, conn))
                    {
                        NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                        DataTable productDt = new DataTable();
                        adapter.Fill(productDt);
                        comboBoxProduct.DataSource = productDt;
                        comboBoxProduct.DisplayMember = "product_name";
                        comboBoxProduct.ValueMember = "product_id";
                    }

                    // Загрузка клиентов
                    string clientQuery = "SELECT client_id, client_name FROM clients ORDER BY client_name";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(clientQuery, conn))
                    {
                        NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                        DataTable clientDt = new DataTable();
                        adapter.Fill(clientDt);
                        comboBoxClient.DataSource = clientDt;
                        comboBoxClient.DisplayMember = "client_name";
                        comboBoxClient.ValueMember = "client_id";
                    }

                    // Заполнение вариантов статуса и приоритета
                    comboBoxStatus.Items.AddRange(new[] { "Ожидает", "Завершено", "Отменено" });
                    comboBoxPriority.Items.AddRange(new[] { "Низкий", "Средний", "Высокий" });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridSale_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridSale.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridSale.SelectedRows[0];

                txtCheque.Text = row.Cells["cheque"].Value != DBNull.Value ? row.Cells["cheque"].Value.ToString() : string.Empty;
                comboBoxProduct.Text = row.Cells["product_name"].Value != DBNull.Value ? row.Cells["product_name"].Value.ToString() : string.Empty;
                txtQuantity.Text = row.Cells["quantity"].Value != DBNull.Value ? row.Cells["quantity"].Value.ToString() : string.Empty;
                comboBoxClient.Text = row.Cells["client_name"].Value != DBNull.Value ? row.Cells["client_name"].Value.ToString() : string.Empty;

                dateTimePickerSaleDate.Value = row.Cells["sale_date"].Value != DBNull.Value
                    ? Convert.ToDateTime(row.Cells["sale_date"].Value)
                    : DateTime.Now;
                txtSum.Text = row.Cells["sum"].Value != DBNull.Value ? row.Cells["sum"].Value.ToString() : string.Empty;
                dateTimePickerDeliveryDate.Value = row.Cells["delivery_date"].Value != DBNull.Value
                    ? Convert.ToDateTime(row.Cells["delivery_date"].Value)
                    : DateTime.Now;

                comboBoxStatus.Text = row.Cells["status"].Value != DBNull.Value ? row.Cells["status"].Value.ToString() : string.Empty;
                comboBoxPriority.Text = row.Cells["priority"].Value != DBNull.Value ? row.Cells["priority"].Value.ToString() : string.Empty;
            }
        }

        private void buttonEditSale_Click(object sender, EventArgs e)
        {
            if (dataGridSale.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите продажу для редактирования!");
                return;
            }

            int saleId = Convert.ToInt32(dataGridSale.SelectedRows[0].Cells["sale_id"].Value);

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                UPDATE sales 
                SET 
                    cheque = @Cheque,
                    product_id = @ProductId,
                    quantity = @Quantity,
                    client_id = @ClientId,
                    sale_date = @SaleDate,
                    sum = @Sum,
                    delivery_date = @DeliveryDate,
                    status = @Status,
                    priority = @Priority
                WHERE sale_id = @SaleId";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SaleId", saleId);
                        command.Parameters.AddWithValue("@Cheque", string.IsNullOrWhiteSpace(txtCheque.Text) ? (object)DBNull.Value : txtCheque.Text);
                        command.Parameters.AddWithValue("@ProductId", Convert.ToInt32(comboBoxProduct.SelectedValue));
                        command.Parameters.AddWithValue("@Quantity", string.IsNullOrWhiteSpace(txtQuantity.Text) ? (object)DBNull.Value : Convert.ToInt32(txtQuantity.Text));
                        command.Parameters.AddWithValue("@ClientId", Convert.ToInt32(comboBoxClient.SelectedValue));
                        command.Parameters.AddWithValue("@SaleDate", dateTimePickerSaleDate.Value);
                        command.Parameters.AddWithValue("@Sum", string.IsNullOrWhiteSpace(txtSum.Text) ? (object)DBNull.Value : Convert.ToInt32(txtSum.Text));
                        command.Parameters.AddWithValue("@DeliveryDate", dateTimePickerDeliveryDate.Value);
                        command.Parameters.AddWithValue("@Status", string.IsNullOrWhiteSpace(comboBoxStatus.Text) ? (object)DBNull.Value : comboBoxStatus.Text);
                        command.Parameters.AddWithValue("@Priority", string.IsNullOrWhiteSpace(comboBoxPriority.Text) ? (object)DBNull.Value : comboBoxPriority.Text);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Данные о продаже обновлены!", "Успех");
                            LoadData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
            }
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            SalesViewForm salesViewForm = new SalesViewForm();
            salesViewForm.Show();
            this.Hide();
        }

        private void SaleEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void TextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProvider1.SetError(textBox, "Поле обязательно для заполнения");
            }
            else
            {
                errorProvider1.SetError(textBox, "");
            }
        }

        private void SaleEditForm_Load(object sender, EventArgs e)
        {
            requiredTextBoxes.Add(txtCheque);
            requiredTextBoxes.Add(txtQuantity);
            requiredTextBoxes.Add(txtSum);

            foreach (var textBox in requiredTextBoxes)
            {
                textBox.Validating += TextBox_Validating;
            }
        }

        private void txtSum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
            if (e.KeyChar == '-')
            {
                e.Handled = true;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '-')
            {
                e.Handled = true;
            }
        }
    }
}
