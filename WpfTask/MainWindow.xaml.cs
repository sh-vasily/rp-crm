using System.Data.Entity;
using System.Windows;
using WpfTask.Models;

namespace WpfTask
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RiPContext db;   
        public MainWindow()
        {
            InitializeComponent();

            db = new RiPContext();
            db.Companys.Load();
            companysGrid.ItemsSource = db.Companys.Local.ToBindingList();

            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (companysGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < companysGrid.SelectedItems.Count; i++)
                {
                    var company = companysGrid.SelectedItems[i] as Company;
                    if (company != null)
                    {
                        db.Companys.Remove(company);
                    }
                }
            }
            db.SaveChanges();
        }
    }
}
