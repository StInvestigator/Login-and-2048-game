using System;
using System.Collections.Generic;
using System.Globalization;
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



namespace Login_and_2048_game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public static List<string> errors;
        public string Name { get; set; }
        public string Password { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            errors = new List<string>();
            errors.Add("Field is required");
            PrintErrors();
            DataContext = this;
        }

        private void PropertyChanged(object sender, TextChangedEventArgs e)
        {
            Name = TBLogin.Text;
        }

        private void PropertyChanged2(object sender, TextChangedEventArgs e)
        {
            Password = TBPassword.Text;
            PrintErrors();
        }

        public void PrintErrors()
        {
            SPPV1.Children.Clear();
            SPPV2.Children.Clear();
            SPPV3.Children.Clear();
            Label lab;
            int count = 0;
            foreach (var item in errors)
            {
                count++;
                lab = new Label();
                lab.Foreground = new SolidColorBrush(Colors.Red);
                lab.Content = item;
                lab.FontSize = 15;
                if (count <= 6 && count > 4) SPPV3.Children.Add(lab);
                if (count <= 4 && count > 2) SPPV2.Children.Add(lab);
                if (count<=2) SPPV1.Children.Add(lab);
            }
        }
    }
}
