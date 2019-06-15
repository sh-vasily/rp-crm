using System.Data.Entity;
using System.Windows;

namespace WpfTask
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        CompanyDBContex dBContex;

        public MainWindow()
        {
            InitializeComponent();

            dBContex = new CompanyDBContex();

            dBContex.Company.Load();
            companysGrid.ItemsSource = dBContex.Company.Local.ToBindingList();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            dBContex.Dispose();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            dBContex.Company.Load();
            companysGrid.ItemsSource = dBContex.Company.Local.ToBindingList();

            dBContex.SaveChanges();
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
                        dBContex.Company.Remove(company);
                    }
                }
            }
            dBContex.SaveChanges();
        }

    }
}
