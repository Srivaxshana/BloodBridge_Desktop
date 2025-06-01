using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;

namespace Blood_Bridge
{
    public class DataBaseHelper
    {
        private string connectionString = "Data Source=donors.db;Version=3;";

        // Create database if it doesn't exist
        public void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
       
                connection.Open();
                string createTableQuery = @"CREATE TABLE IF NOT EXISTS Donors (
                                        DonorID INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Name TEXT NOT NULL,
                                        BloodType TEXT NOT NULL,
                                        Contact TEXT NOT NULL,
                                        Address TEXT NOT NULL)";
                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Donar> GetAllDonors()
        {
            var donors = new List<Donar>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Donors";
                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        donors.Add(new Donar
                        {
                            DonorID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            BloodType = reader.GetString(2),
                            Contact = reader.GetString(3),
                            Address = reader.GetString(4)
                        });
                    }
                }
            }
            return donors;
        }



        // Add
        public void AddDonor(Donar donor)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Donors (Name, BloodType, Contact, Address) VALUES (@Name, @BloodType, @Contact, @Address)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", donor.Name);
                    command.Parameters.AddWithValue("@BloodType", donor.BloodType);
                    command.Parameters.AddWithValue("@Contact", donor.Contact);
                    command.Parameters.AddWithValue("@Address", donor.Address);
                    command.ExecuteNonQuery();
                }
          
            }
        }

      

        // Update 
        public void UpdateDonor(Donar donor)
        {
   
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Donors SET Name = @Name, BloodType = @BloodType, Contact = @Contact, Address = @Address WHERE DonorID = @DonorID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DonorID", donor.DonorID);
                    command.Parameters.AddWithValue("@Name", donor.Name);
                    command.Parameters.AddWithValue("@BloodType", donor.BloodType);
                    command.Parameters.AddWithValue("@Contact", donor.Contact);
                    command.Parameters.AddWithValue("@Address", donor.Address);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Delete
        public void DeleteDonor(int donorID)
        {

          
            
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Donors WHERE DonorID = @DonorID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DonorID", donorID);
                    command.ExecuteNonQuery();
                }
            }
        }




        //for blood

        private const string DatabaseFile = "BloodBank.db";

        public DataBaseHelper()
        {
            using (var connection = new SQLiteConnection($"Data Source={DatabaseFile};Version=3;"))
            {
                connection.Open();
                string createTableQuery = """
                CREATE TABLE IF NOT EXISTS BloodDetails (
                    BloodType TEXT PRIMARY KEY,
                    Quantity INTEGER NOT NULL
                );
            """;
                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddOrUpdateBloodDetail(string bloodType, int quantity)
        {
            using (var connection = new SQLiteConnection($"Data Source={DatabaseFile};Version=3;"))
            {
                connection.Open();
                string insertOrUpdateQuery = """
                INSERT INTO BloodDetails (BloodType, Quantity)
                VALUES (@BloodType, @Quantity)
                ON CONFLICT(BloodType) DO UPDATE SET Quantity = @Quantity;
            """;
                using (var command = new SQLiteCommand(insertOrUpdateQuery, connection))
                {
                    command.Parameters.AddWithValue("@BloodType", bloodType);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Blood_details> GetBloodDetails()
        {
            List<Blood_details> bloodDetails = new List<Blood_details>();
            using (var connection = new SQLiteConnection($"Data Source={DatabaseFile};Version=3;"))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM BloodDetails";
                using (var command = new SQLiteCommand(selectQuery, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bloodDetails.Add(new Blood_details
                        {
                            BloodType = reader.GetString(0),
                            Quantity = reader.GetInt32(1)
                        });
                    }
                }
            }
            return bloodDetails;
        }

        public void DeleteBloodDetail(string bloodType)
        {
            using (var connection = new SQLiteConnection($"Data Source={DatabaseFile};Version=3;"))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM BloodDetails WHERE BloodType = @BloodType";
                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@BloodType", bloodType);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("No record found to delete.");
                    }
                }
            }
            /*
            using (var connection = new SQLiteConnection($"Data Source={DatabaseFile};Version=3;"))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM BloodDetails WHERE BloodType = @BloodType";
                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@BloodType", bloodType);
                    command.ExecuteNonQuery();
                }
            }
            */
        }
    }
        
    
}

