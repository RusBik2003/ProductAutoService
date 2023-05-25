using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductAutoService
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AutoServiceEntities _context = new AutoServiceEntities();
        private List<Product> products = new List<Product>();
        private string SelectManufacturer="";
        private string FindedName="";
        public MainWindow()
        {
            InitializeComponent();
            ListProduct.ItemsSource = _context.Product.OrderBy(prod => prod.Title).ToList();

            products = _context.Product.ToList();

            List<Manufacturer> _manufacturers = new List<Manufacturer>();
            _manufacturers.Add(new Manufacturer() { Name = "все типы" });
            _manufacturers.AddRange(_context.Manufacturer.OrderBy(man => man.Name).ToList());

            cmbManufacture.ItemsSource = _manufacturers;
        }

        public void Viborka()
        {
            products = _context.Product.OrderBy(p => p.Title).ToList();

            if (FindedName != "")
            {
                products = products.OrderBy(prod => prod.Title).Where(prod => prod.Title.ToLower().Contains(FindedName.ToLower())).ToList();
            }

            if (SelectManufacturer != "")
            {
                if (SelectManufacturer != "все типы")
                {
                    products = products.OrderBy(p => p.Title).Where(p => p.Manufacturer.Name.Contains(SelectManufacturer)).ToList();
                }
            }

            SortCost _sortCost = new SortCost();
            if ((bool)chbSortUpCost.IsChecked)
            {
                products = _sortCost.SortCostUp(products);
            }
            else if ((bool)chbSortDownCost.IsChecked)
            {
                products = _sortCost.SortCostDown(products);
            }
            else products = products.OrderBy(p => p.Title).ToList();
            ListProduct.ItemsSource = products;
        }

        private void ChbSortUpCost_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)chbSortDownCost.IsChecked)
            {
                chbSortDownCost.IsChecked = false;
            }

            Viborka();
        }
       

        private void ChbSortUpCost_Unchecked(object sender, RoutedEventArgs e)
        {
            ListProduct.ItemsSource = products.OrderBy(p => p.Title).ToList();
        }

        private void ChbSortDownCost_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)chbSortUpCost.IsChecked)
            { 
                chbSortUpCost.IsChecked = false;
            }

            Viborka();
        }

        private void ChbSortDownCost_Unchecked(object sender, RoutedEventArgs e)
        {
            ListProduct.ItemsSource = products.OrderBy(p => p.Title).ToList();
        }

        private void TxtSearchName_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            FindedName = txtSearchName.Text;

            Viborka();
        }

        private void CmbManufacture_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            products = _context.Product.ToList();
            Manufacturer m=(Manufacturer)cmbManufacture.SelectedItem;
            SelectManufacturer = m.Name;
            Viborka();
        }

        private void BtnDelPoduct_Click(object sender, RoutedEventArgs e)
        {
            Product _delProduct = (Product) ListProduct.SelectedItem;

            if (_delProduct != null)
            {
                int f = _context.ProductSale.Where(ps => ps.Product.Title.Contains(_delProduct.Title)).ToList().Count;
                if (f == 0)
                {
                    var m = MessageBox.Show("Вы уверены, что хотите удалить товар? "+ _delProduct.Title, "Подтвердить?", MessageBoxButton.YesNoCancel);
                    if (m == MessageBoxResult.Yes)
                    {
                        _context.Product.Remove(_delProduct);
                        _context.SaveChanges();
                        Viborka();
                    }
                }
                else MessageBox.Show("Нельзя удалить товар, который имеет продажи", "Предупреждение", MessageBoxButton.OK);
                
            }
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddProductWindow window = new Windows.AddProductWindow(_context, this);
            window.ShowDialog();
        }
    }
}
