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
using System.Xml.Linq;

namespace Blood_Bridge
{
    /// <summary>
    /// Interaction logic for Blood_Details_Edit.xaml
    /// </summary>
    public partial class Blood_Details_Edit : Window
    {
        private DataBaseHelper _databaseHelper = new DataBaseHelper();
        private string _selectedBloodType = string.Empty;
       
        public Blood_Details_Edit()
        {
            InitializeComponent();
            LoadBloodDetails();
        }

        /*  private void LoadBloodDetails()
          {
              BloodList.Items.Clear();
              List<Blood_details> bloodDetails = _databaseHelper.GetBloodDetails();
              foreach (var blood in bloodDetails)
              {
                  BloodList.Items.Add($"{blood.BloodType} - {blood.Quantity} units");
              }
          }
        */
        private void LoadBloodDetails()
        {
            bloodGrid.ItemsSource = _databaseHelper.GetBloodDetails();
        }
        private void OnAddOrUpdateBlood(object sender, RoutedEventArgs e)
        {

            string bloodType = BloodTypeTextBox.Text.Trim();
            if (string.IsNullOrEmpty(bloodType))
            {
                MessageBox.Show("Blood Type cannot be empty.");
                return;
            }

            if (!int.TryParse(QuantityTextBox.Text, out int quantity))
            {
                MessageBox.Show("Invalid quantity");
                return;
            }

            /* string bloodType = BloodTypeTextBox.Text;
             if (!int.TryParse(QuantityTextBox.Text, out int quantity))
             {
                 MessageBox.Show("Invalid quantity");
                 return;
             }
            */
            _databaseHelper.AddOrUpdateBloodDetail(bloodType, quantity);
            LoadBloodDetails();
            MessageBox.Show("Blood record added/updated successfully!");
        }

        private void OnDeleteBlood(object sender, RoutedEventArgs e)
        {
             if (string.IsNullOrEmpty(_selectedBloodType))
              {
                  MessageBox.Show("Select a blood record to delete");
                  return;
              }
              _databaseHelper.DeleteBloodDetail(_selectedBloodType);
            _selectedBloodType = string.Empty;
            LoadBloodDetails();
              MessageBox.Show("Blood record deleted successfully!");
            
                              /*  if (string.IsNullOrWhiteSpace(_selectedBloodType))
                                {
                                    MessageBox.Show("Please select a blood record to delete.");
                                    return;
                                }

                                _databaseHelper.DeleteBloodDetail(_selectedBloodType);
                                _selectedBloodType = string.Empty;
                                LoadBloodDetails();
                                MessageBox.Show("Blood record deleted successfully!");
                              */

            



          
        }


        /* private void OnBloodSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
         {
             if (bloodGrid.SelectedItem is Blood_details selectedBlood)
             {
                 BloodTypeTextBox.Text = selectedBlood.BloodType;
                 QuantityTextBox.Text = selectedBlood.Quantity.ToString();
                 _selectedBloodType = selectedBlood.BloodType;
             }
             /* if (BloodList.SelectedItem != null)
              {
                  string selectedText = BloodList.SelectedItem.ToString();
                  string[] parts = selectedText.Split('-');
                  if (parts.Length > 1)
                  {
                      _selectedBloodType = parts[0].Trim();
                  }
              }
         }

             */

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bloodGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (bloodGrid.SelectedItem is Blood_details selectedBlood)
            {
                BloodTypeTextBox.Text = selectedBlood.BloodType;
                QuantityTextBox.Text = selectedBlood.Quantity.ToString();
                _selectedBloodType = string.IsNullOrWhiteSpace(selectedBlood.BloodType) ? "" : selectedBlood.BloodType;//_selectedBloodType = selectedBlood.BloodType;
            }

        }
    }
}
