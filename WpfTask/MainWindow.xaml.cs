﻿using System;
using System.Data.Entity;
using System.Linq;
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
            if (companysGrid.SelectedItems.Count == 1)
            {
                var company = companysGrid.SelectedItems[0] as Company;

                if (company != null)
                {
                    var selected_company = dBContex.Company.FirstOrDefault(c => c.Id == company.Id);
                    
                    if(selected_company is null)
                    {
                        if (company.Name is null)
                        {
                            MessageBox.Show("Введите название компании");
                        }
                        else if (company.ContractStatus is null)
                        {
                            MessageBox.Show("Введите статус контракта с компанией");
                        }
                        else
                        {
                            dBContex.Company.Add(company);
                            dBContex.SaveChanges();

                            MessageBox.Show($"Запись : {company.ToString()} \nуспешно добавлена в базу данных");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Запись с таким Id уже содержится в базе данных");
                    }
                }
                else
                {
                    MessageBox.Show("Невозможно добавить пустую запись");
                }
            }
            else
            {
                switch(companysGrid.SelectedItems.Count)
                {
                    case 0:
                        MessageBox.Show("Выберите запсиь для добавления");
                        break;
                    default:
                        MessageBox.Show("Выберите только одну запсиь для добавления");
                        break;
                }
            }
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
    }
}
