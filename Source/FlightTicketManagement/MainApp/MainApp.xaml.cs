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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlightTicketManagement
{
    /// <summary>
    /// Interaction logic for MainApp.xaml
    /// </summary>
    public partial class MainApp : Window
    {
        bool isMaximize = false;

        public MainApp() {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void maximizeBtn_Click(object sender, RoutedEventArgs e) {
            this.isMaximize = !this.isMaximize;

            if (this.isMaximize) {
                this.WindowState = WindowState.Maximized;
            }
            else this.WindowState = WindowState.Normal;
        }

        private void minimizeBtn_Click(object sender, RoutedEventArgs e) {
            this.WindowState = WindowState.Minimized;
        }

        private void menuBtn_Click(object sender, RoutedEventArgs e) {
        }

        private void tileBar_MouseDown(object sender, MouseButtonEventArgs e) {
            this.DragMove();
        }

        private void homeBtn_Click(object sender, RoutedEventArgs e) {
            this.turnOnHomeScreen();
        }

        private void turnOffHomeScreen() {
            this.homeGrid.Visibility = Visibility.Hidden;
        }

        private void turnOnHomeScreen() {
            this.homeGrid.Visibility = Visibility.Visible;
            this.scrollView.Visibility = Visibility.Hidden;
            this.scrollView.Visibility = Visibility.Visible;
        }
    }
}
