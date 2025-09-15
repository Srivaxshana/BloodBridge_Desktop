using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
  
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void login(object sender, RoutedEventArgs e)

        {
            string username = txtUserName.Text;
            string password = txtPassword.Password;

            using (UserDataContext context = new UserDataContext())
            {
                bool userfound = context.Users.Any(user=> user.name == username && user.password==password);

                if(userfound)
                {
                    GrantAccess();
                    Close();
                }

                else
                {
                    MessageBox.Show("User Not Found");
                }
            }
        }
            public void GrantAccess()
        {
         
            Dashboard main=new Dashboard();
            main.Show();
        }

        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}


//Password for login
//sri 789
// admin admin123
