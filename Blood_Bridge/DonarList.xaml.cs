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

namespace Blood_Bridge
{
   
    public partial class DonarList : Window
    {
        private DataBaseHelper dbHelper = new DataBaseHelper();

        public DonarList()
        {
            InitializeComponent();
            LoadDonorData();
        }

        private void LoadDonorData()
        {
            List<Donar> donors = dbHelper.GetAllDonors();
            donorGrid.ItemsSource = donors; // Load data into DataGrid
          
           
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
