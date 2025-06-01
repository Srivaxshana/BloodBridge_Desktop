using System;
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
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Drawing;

namespace Blood_Bridge
{

    public partial class Donars : Window
    {
        private DataBaseHelper _dbHelper;
        private Donar selectedDonor;
        public Donars()
        {
            InitializeComponent();
            _dbHelper = new     DataBaseHelper();
            _dbHelper.InitializeDatabase();
            LoadDonors();
        }

        private void LoadDonors()
        {
            donorGrid.ItemsSource = null;
            donorGrid.ItemsSource = _dbHelper.GetAllDonors();
                                                                               
        }

        private void donorGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (donorGrid.SelectedItem != null)
            {
                selectedDonor = donorGrid.SelectedItem as Donar;
                if (selectedDonor != null)
                {
                    txtName.Text = selectedDonor.Name;
                    txtBloodType.Text = selectedDonor.BloodType;
                    txtContact.Text = selectedDonor.Contact;
                    txtAddress.Text = selectedDonor.Address;
                }
            }
        }

        private void OnAddDonor(object sender, RoutedEventArgs e)
        {
            var donor = new Donar
            {
                Name = txtName.Text,
               
                BloodType = txtBloodType.Text,
                Contact = txtContact.Text,
          
                Address = txtAddress.Text,
            
            };

            _dbHelper.AddDonor(donor);
            // Console.WriteLine($"Added Donor: {donor.Name},{donor.BloodType}, {donor.Contact}, {donor.Address}");

            LoadDonors();
            MessageBox.Show("Donor added successfully!");
        }


        private void OnUpdateDonar(object sender, RoutedEventArgs e)
        {
            if (selectedDonor != null)
            {
                selectedDonor.Name = txtName.Text;
                selectedDonor.BloodType = txtBloodType.Text;
                selectedDonor.Contact = txtContact.Text;
                selectedDonor.Address = txtAddress.Text;
         

                _dbHelper.UpdateDonor(selectedDonor);
                LoadDonors();
                MessageBox.Show("Donor updated successfully!");
            }
            else
            {
                MessageBox.Show("Please select a donor to update.");
            }
        }

        private void OnDeleteDonor(object sender, RoutedEventArgs e)
        {
            if (selectedDonor != null)
            {
                _dbHelper.DeleteDonor(selectedDonor.DonorID);
                LoadDonors();
                MessageBox.Show("Donor deleted successfully!");
            }
            else
            {
                MessageBox.Show("Please select a donor to delete.");
            }
        
        }

        private void DonarDetails(object sender, RoutedEventArgs e)
        {
            DonarList donorListWindow = new DonarList();
            donorListWindow.Show();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
