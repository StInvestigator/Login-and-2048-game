using Login_and_2048_game.Domain;
using MaterialDesignThemes.Wpf;
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

namespace Login_and_2048_game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ActualCardsPlacement cards;
        public MainWindow()
        {
            cards = new ActualCardsPlacement();
            InitializeComponent();
            cardsToUI();
        }

        void cardsToUI()
        {
            MainPanel.Children.Clear();
            foreach (KeyValuePair<int,Card> item in cards)
            {
                MainPanel.Children.Add(item.Value);   
            }
        }
    }
}
