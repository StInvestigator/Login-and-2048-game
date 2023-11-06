using Login_and_2048_game.Domain;
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
            card11.Children.Add(cards.elementAt(0).Value);
            card12 = cards.elementAt(1).Value;
            card13 = cards.elementAt(2).Value;
            card14 = cards.elementAt(3).Value;

            card21 = cards.elementAt(4).Value;
            card22 = cards.elementAt(5).Value;
            card23 = cards.elementAt(6).Value;
            card24.Content = cards.elementAt(7).Value.Content;

            card31 = cards.elementAt(8).Value;
            card32 = cards.elementAt(9).Value;
            card33 = cards.elementAt(10).Value;
            card34 = cards.elementAt(11).Value;

            card41 = cards.elementAt(12).Value;
            card42 = cards.elementAt(13).Value;
            card43 = cards.elementAt(14).Value;
            card44 = cards.elementAt(15).Value;
            
        }
    }
}
