﻿using System;
using System.Collections.Generic;
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
using System.Data.OleDb;

namespace DatabaseLab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;

        public MainWindow()
        {
            InitializeComponent();
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\DatabaseLab.accdb");
        }

        private void AssetsButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();

            OleDbDataReader read = cmd.ExecuteReader();
            //Hardcoded an arbitrary magic number here. Ideally would be more thoughtful.
            object[] data = new object[10];
            string atext = "";

            while (read.Read())
            {
                read.GetValues(data);
                //And here.
                for(int i = 0; i < 10; i++)
                {
                    atext += data[i] + " ";
                }
                atext += "\n";
            }

            AssetText.Text = atext;
            cn.Close();
        }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Employees";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();

            OleDbDataReader read = cmd.ExecuteReader();
            //Hardcoded an arbitrary magic number here. Ideally would be more thoughtful.
            object[] data = new object[10];
            string etext = "";

            while (read.Read())
            {
                read.GetValues(data);
                //And here.
                for (int i = 0; i < 10; i++)
                {
                    etext += data[i] + " ";
                }
                etext += "\n";
            }

            EmployeeText.Text = etext;
            cn.Close();
        }
    }
}
