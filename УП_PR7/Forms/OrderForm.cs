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
    public partial class OrderForm : Form
    {
        private List<Product> products = new List<Product>();
        private List<Product> cart = new List<Product>();
        private List<Client> clients = new List<Client>();
        private decimal deliveryCost = 300;
        private readonly string connectionString = "Host=localhost;Database=tech_shop;Username=postgres;Password=123;Port=5433";

        private Label totalLabel;
        private ComboBox clientCombo;
        private FlowLayoutPanel productsPanel;
        private FlowLayoutPanel cartPanel;
        private CheckBox deliveryCheck;
        private readonly Color accentColor = Color.FromArgb(3, 3, 149);
        private readonly Font mainFont = new Font("Times New Roman", 14);

        public OrderForm()
        {
            InitializeComponent();
            LoadData();
            InitializeUI();
        }

        private void LoadData()
        {
            LoadProducts();
            LoadClients();
        }

        private void LoadProducts()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM products", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("product_id")),
                            Category = reader.GetString(reader.GetOrdinal("category")),
                            Name = reader.GetString(reader.GetOrdinal("product_name")),
                            Price = reader.GetInt32(reader.GetOrdinal("price")),
                            Quantity = reader.GetInt32(reader.GetOrdinal("quantity"))
                        });
                    }
                }
            }
        }

        private void LoadClients()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM clients", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clients.Add(new Client
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("client_id")),
                            Name = reader.GetString(reader.GetOrdinal("client_name")),
                            Phone = reader.GetString(reader.GetOrdinal("phone"))
                        });
                    }
                }
            }
        }

        private void InitializeUI()
        {
            this.Text = "Оформление заказа";
            this.Size = new Size(1000, 700);
            this.BackColor = Color.White;

            // Клиентский комбобокс
            clientCombo = new ComboBox
            {
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = mainFont,
                Height = 40
            };
            clientCombo.Items.AddRange(clients.Select(c => $"{c.Name} ({c.Phone})").ToArray());

            // Главный TabControl
            var tabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = mainFont,
                Padding = new Point(10, 10)
            };

            // Вкладка с товарами
            var productsTab = new TabPage("Товары по категориям");
            var categoriesCombo = new ComboBox
            {
                Dock = DockStyle.Top,
                Font = mainFont,
                Height = 40,
                Margin = new Padding(5)
            };
            categoriesCombo.Items.AddRange(products.Select(p => p.Category).Distinct().ToArray());
            categoriesCombo.SelectedIndexChanged += (s, e) => ShowProducts(categoriesCombo.SelectedItem?.ToString());

            productsPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = false,
                BackColor = Color.FromArgb(253, 215, 167),
                Padding = new Padding(10)
            };

            productsTab.Controls.Add(productsPanel);
            productsTab.Controls.Add(categoriesCombo);

            // Вкладка с корзиной
            var cartTab = new TabPage("Корзина");
            cartPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = false,
                BackColor = Color.FromArgb(253, 215, 167),
                Padding = new Padding(10)
            };

            var checkoutPanel = new Panel { Dock = DockStyle.Bottom, Height = 150, BackColor = Color.White };
            totalLabel = new Label { Text = "Итого: 0 руб.", Font = new Font(mainFont, FontStyle.Bold), Dock = DockStyle.Top, Height = 40 };
            deliveryCheck = new CheckBox { Text = "Требуется доставка (+300 руб.)", Dock = DockStyle.Top, Font = mainFont, Height = 40 };
            deliveryCheck.CheckedChanged += (s, e) => UpdateTotal();

            var checkoutBtn = new Button
            {
                Text = "Оформить заказ",
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = accentColor,
                ForeColor = Color.White,
                Font = new Font(mainFont, FontStyle.Bold)
            };
            checkoutBtn.Click += ProcessOrder;

            checkoutPanel.Controls.Add(checkoutBtn);
            checkoutPanel.Controls.Add(deliveryCheck);
            checkoutPanel.Controls.Add(totalLabel);
            cartTab.Controls.Add(cartPanel);
            cartTab.Controls.Add(checkoutPanel);

            // Добавляем вкладки
            tabControl.TabPages.Add(productsTab);
            tabControl.TabPages.Add(cartTab);

            // Добавляем элементы на форму в правильном порядке
            this.Controls.Add(tabControl);
            this.Controls.Add(clientCombo);

            // Загружаем первую категорию
            if (categoriesCombo.Items.Count > 0)
            {
                categoriesCombo.SelectedIndex = 0;
            }
        }

        private TabPage CreateProductsTab()
        {
            var productsTab = new TabPage("Товары по категориям");
            var categoriesCombo = new ComboBox { Dock = DockStyle.Top, Font = mainFont, Height = 40 };
            categoriesCombo.Items.AddRange(products.Select(p => p.Category).Distinct().ToArray());
            categoriesCombo.SelectedIndexChanged += (s, e) => ShowProducts(categoriesCombo.SelectedItem?.ToString());

            productsPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, BackColor = Color.FromArgb(253, 215, 167) };
            productsTab.Controls.Add(productsPanel);
            productsTab.Controls.Add(categoriesCombo);

            return productsTab;
        }

        private TabPage CreateCartTab()
        {
            var cartTab = new TabPage("Корзина");
            cartPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, BackColor = Color.FromArgb(253, 215, 167) };

            var checkoutPanel = new Panel { Dock = DockStyle.Bottom, Height = 150, BackColor = Color.White };
            totalLabel = new Label { Text = "Итого: 0 руб.", Font = new Font(mainFont, FontStyle.Bold), Dock = DockStyle.Top, Height = 40 };
            deliveryCheck = new CheckBox { Text = "Требуется доставка (+300 руб.)", Dock = DockStyle.Top, Font = mainFont, Height = 40 };
            deliveryCheck.CheckedChanged += (s, e) => UpdateTotal();

            var checkoutBtn = new Button { Text = "Оформить заказ", Dock = DockStyle.Bottom, Height = 50, BackColor = accentColor, ForeColor = Color.White, Font = new Font(mainFont, FontStyle.Bold) };
            checkoutBtn.Click += ProcessOrder;

            checkoutPanel.Controls.Add(checkoutBtn);
            checkoutPanel.Controls.Add(deliveryCheck);
            checkoutPanel.Controls.Add(totalLabel);
            cartTab.Controls.Add(cartPanel);
            cartTab.Controls.Add(checkoutPanel);

            return cartTab;
        }

        private void ShowProducts(string category)
        {
            productsPanel.Controls.Clear();
            if (category == null) return;

            foreach (var product in products.Where(p => p.Category == category))
            {
                var panel = new Panel { Size = new Size(350, 120), Margin = new Padding(10), BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle };
                var nameLabel = new Label { Text = product.Name, Location = new Point(10, 10), Font = mainFont, AutoSize = true };
                var priceLabel = new Label { Text = $"{product.Price} руб. (Остаток: {product.Quantity})", Location = new Point(10, 40), Font = mainFont, AutoSize = true };

                var addBtn = new Button { Text = "Добавить", Location = new Point(10, 70), Size = new Size(100, 30), BackColor = accentColor, ForeColor = Color.White, Font = mainFont, Tag = product };
                addBtn.Click += (s, e) => AddToCart(product);

                panel.Controls.Add(nameLabel);
                panel.Controls.Add(priceLabel);
                panel.Controls.Add(addBtn);
                productsPanel.Controls.Add(panel);
            }
        }

        private void AddToCart(Product product)
        {
            var existing = cart.FirstOrDefault(p => p.Id == product.Id);
            if (existing != null)
            {
                existing.Quantity++;
            }
            else
            {
                cart.Add(new Product { Id = product.Id, Name = product.Name, Price = product.Price, Quantity = 1 });
            }
            UpdateCart();
        }

        private void UpdateCart()
        {
            cartPanel.Controls.Clear();
            foreach (var product in cart)
            {
                var panel = new Panel { Size = new Size(500, 80), Margin = new Padding(10), BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle };
                var nameLabel = new Label { Text = $"{product.Name} - {product.Price} руб. x {product.Quantity}", Location = new Point(10, 10), Font = mainFont, AutoSize = true };
                var removeBtn = new Button { Text = "Удалить", Location = new Point(400, 10), Size = new Size(80, 30), BackColor = accentColor, ForeColor = Color.White, Font = mainFont, Tag = product };
                removeBtn.Click += (s, e) => { cart.Remove((Product)removeBtn.Tag); UpdateCart(); };

                panel.Controls.Add(nameLabel);
                panel.Controls.Add(removeBtn);
                cartPanel.Controls.Add(panel);
            }
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            decimal total = cart.Sum(p => p.Price * p.Quantity);
            if (deliveryCheck.Checked) total += deliveryCost;
            totalLabel.Text = $"Итого: {total} руб.";
        }

        private void ProcessOrder(object sender, EventArgs e)
        {
            if (clientCombo.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите клиента!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cart.Count == 0)
            {
                MessageBox.Show("Корзина пуста!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Заказ успешно оформлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cart.Clear();
            UpdateCart();
        }

        private void OrderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
