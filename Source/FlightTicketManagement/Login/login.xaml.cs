using FlightTicketManagement.Helper;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace FlightTicketManagement
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : UserControl
    {
        public login() {
            InitializeComponent();

        }

        private void onMainAppClose(object sender, EventArgs e) {
            MainWindow.Instance.Close();
        }

        private async void login_Click(object sender, RoutedEventArgs e) {
            if (await Authenticater.Instance.Authenticate(userName.Text,passWord.Password))

            {
                MainWindow.Instance.Hide();
                MainApp newApp = new MainApp();
                newApp.Closed += new EventHandler(onMainAppClose);
                newApp.Show();
            }
        }



        private void signUp_Click(object sender, RoutedEventArgs e) {
            MainWindow.Instance.switchToSignUp();
        }
    }
}
