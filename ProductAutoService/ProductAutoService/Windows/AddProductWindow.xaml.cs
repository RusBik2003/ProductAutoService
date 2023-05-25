using Microsoft.Win32;
using ProductAutoService.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProductAutoService.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        private AutoServiceEntities _context;
        private MainWindow window;
        public AddProductWindow(AutoServiceEntities autoServiceEntities, MainWindow mainwindow)
        {
            InitializeComponent();
            this._context = autoServiceEntities;
            this.window = mainwindow;
        }

        private string path = "";

        private void BtnAddImage_Click(object sender, RoutedEventArgs e)
        {
            path = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JPEG|*jpg|PNG|*png";
            ofd.FileName = "Картинка";
            ofd.DefaultExt = ".jpg";
            Nullable<bool> result = ofd.ShowDialog();

            if (result==true)
            {
                path = ofd.FileName;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.UriSource = new Uri(path);
                bitmapImage.EndInit();

                ImgProduct.Source = bitmapImage;
            }
               
        }

        private string GenUniqueFileName(string pathDirectory)
        {
            
            string filename;
            do
            {
                filename = string.Format(@"{0}.jpg", Guid.NewGuid());
            }
            while (File.Exists(pathDirectory + filename));
            return filename;
        }

        private void BtnAddNewProduct_Click(object sender, RoutedEventArgs e)
        {
            string _pathDyrectory = System.IO.Path.GetFullPath(@"..\..\");
            string fullPath;
            string copypath = @"\Товары автосервиса\";
            string _filename = GenUniqueFileName(_pathDyrectory+copypath);
            string _newpath = _pathDyrectory+copypath+_filename;
            if (path == "")
            {
                path = @"\Resource\DefImage.jpeg";
                fullPath = _pathDyrectory + path;
            }
            else fullPath = path;

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.UriSource=new Uri(fullPath);
            bitmapImage.EndInit();

            bitmapImage.


            Product _product = new Product()
            {
                ID = _context.Product.ToList().Count + 1,
                Title = txtAddTitle.Text,
                Cost = 100,
                Description = "",
                MainImagePath = @"Товары автосервиса\" + _filename,
                IsActive = true,
                ManufacturerID = 2
            };

            _context.Product.Add(_product);

            
            _context.SaveChanges();
            window.Viborka();
            
        }
    }
}
