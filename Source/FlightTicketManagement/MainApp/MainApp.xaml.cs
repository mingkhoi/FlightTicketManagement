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
        const int menuMarginButtonArea = 50;
        const float menuModeOpacity = 0.45f;

        const int origionalMarginTopButtonArea = 150;
        const int origionalMarginBottomButtonArea = 50;
        Thickness origionalBorderThicknessButtonArea = new Thickness(1);
        Thickness origionMarginButtonArea;

        const int controlTopLayer = 0;
        const int controlBottomLayer = -1;

        bool isMaximize = false;
        bool onHomeScreen = true;
        bool onMenuMode = false;

        List<Brush> buttonOrigionalColor = new List<Brush>();

        public MainApp() {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            foreach (var item in this.buttonGrid.Children) {
                buttonOrigionalColor.Add((item as Button).Background);
            }
            origionMarginButtonArea = this.buttonArea.Margin;
        }

        void bringToFront(UIElement control) {
            Canvas.SetZIndex(control, controlTopLayer);
        }

        void sendToBack(UIElement control) {
            Canvas.SetZIndex(control, controlBottomLayer);
        }

        void turnOnMenuMode() {
            this.sendToBack(this.userControlGrid);
            this.bringToFront(this.homeGrid);

            this.appTile.Visibility = Visibility.Hidden;
            this.userArea.Visibility = Visibility.Hidden;

            foreach (var item in this.buttonGrid.Children) {
                (item as Button).Background = Brushes.Black;

                ResourceDictionary resource = (ResourceDictionary)Application.LoadComponent(
                    new Uri("Resource/resource.xaml", UriKind.Relative));

                (item as Button).Style = (Style)resource["menuStyle"];
            }

            Thickness newMargin = this.buttonArea.Margin;
            newMargin.Top = origionalMarginTopButtonArea - menuMarginButtonArea;
            newMargin.Bottom = origionalMarginBottomButtonArea + menuMarginButtonArea;

            this.buttonArea.BorderThickness = new Thickness(0);
            this.buttonArea.Margin = newMargin;

            // activate animation on changing property 
            this.scrollView.Visibility = Visibility.Hidden;
            this.scrollView.Visibility = Visibility.Visible;
        }

        void undoMenuMode() {
            this.sendToBack(this.homeGrid);

            if (onHomeScreen) {
                this.turnOnHomeScreen();
            }
            else {
                this.bringToFront(userControlGrid);
            }
        }

        private void turnOnHomeScreen() {
            this.sendToBack(this.userControlGrid);
            this.bringToFront(this.homeGrid);

            this.homeGrid.Opacity = 1;

            this.appTile.Visibility = Visibility.Visible;
            this.userArea.Visibility = Visibility.Visible;

            int i = 0;
            foreach (var item in this.buttonGrid.Children) {
                (item as Button).Background = buttonOrigionalColor[i++];

                ResourceDictionary resource = (ResourceDictionary)Application.LoadComponent(
                    new Uri("Resource/resource.xaml", UriKind.Relative));

                (item as Button).Style = (Style)resource["tileButton"];
            }

            this.buttonArea.Margin = origionMarginButtonArea;
            this.buttonArea.BorderThickness = origionalBorderThicknessButtonArea;

            // activate animation on changing property 
            this.scrollView.Visibility = Visibility.Hidden;
            this.scrollView.Visibility = Visibility.Visible;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            
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
            this.onMenuMode = !this.onMenuMode;

            if (this.onMenuMode)
                this.turnOnMenuMode();
            else this.undoMenuMode();
        }

        private void tileBar_MouseDown(object sender, MouseButtonEventArgs e) {
            this.DragMove();
        }

        private void homeBtn_Click(object sender, RoutedEventArgs e) {
            this.turnOnHomeScreen();

            this.onHomeScreen = true;
            this.onMenuMode = false;
        }

        private void turnOffHomeScreen() {
            this.homeGrid.Visibility = Visibility.Hidden;
        }
    }
}
