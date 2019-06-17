using System;
using System.Data.Entity;
using System.Windows;

namespace WpfTask
{
    /// <summary>
    /// Логика взаимодействия для  MainWindow.xaml
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

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            //var cmpdlg = new CompanyDialog();
            // cmpdlg.ShowDialog();

            if (companysGrid.SelectedItems.Count == 1)
            {
                var company = companysGrid.SelectedItems[0] as Company;

                if (company != null)
                {
                    var selected_company = dBContex.Company.Find(company.Id);

                    MessageBox.Show(selected_company.ToString());
                }

                

                /*MessageBox.Show($"{company is null}");                
                
                try
                {
                    selected_company = dBContex.Company.Find(company.Id);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ошибка");
                }*/
               // if (dBContex.Company.Find(company)!= null)
               // {
               //    MessageBox.Show("Yes");
               // }

                //if (from c in dBContex.Compan c ==  company)

                //dBContex.Company.Add(companysGrid.SelectedItems[0] as Company);
                //dBContex.SaveChanges();
                /*
                var company = companysGrid.SelectedItems[0] as Company;
                if (company != null)
                {
                    dBContex.Company.Remove(company);
                }*/
            }


             //   dBContex.SaveChanges();

        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            dBContex.Company.Load();
            companysGrid.ItemsSource = dBContex.Company.Local.ToBindingList();
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

        private void deleteButton_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
