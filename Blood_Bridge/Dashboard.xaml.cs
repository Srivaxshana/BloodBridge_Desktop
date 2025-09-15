using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Blood_Bridge
{
 
    public partial class Dashboard : Window
    {
                public Dashboard()
                {
                    InitializeComponent();

                }
  
        private void Donar(object sender, RoutedEventArgs e)
        {
            OptionPopup.IsOpen = !OptionPopup.IsOpen;
        }
         private void Edit(object sender, RoutedEventArgs e)
         {
            Donars DonarWindow = new Donars();
            DonarWindow.ShowDialog();
         }
 

         private void AllDonarDetails(object sender, RoutedEventArgs e)
         {
            DonarList donorListWindow = new DonarList();
            donorListWindow.Show();
         }
        

        private void Blood(object sender, RoutedEventArgs e)
        {

            Blood_Details_Edit BloodEditwindow = new Blood_Details_Edit();
            BloodEditwindow.Show();
        }

        private void DashboardWindow(object sender, RoutedEventArgs e)
        {
            Dashboard DashboardWindow = new Dashboard();
            DashboardWindow.ShowDialog();
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Show();
           
            this.Close();
        }

    
    }
}
