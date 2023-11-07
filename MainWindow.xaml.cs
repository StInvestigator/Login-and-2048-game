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
            foreach (KeyValuePair<int,Brush> item in cards)
            {
                Card v = new Card();
                v.Width = 131;
                v.Height = 127;
                v.UniformCornerRadius = 30;
                v.FontSize = 40;
                v.VerticalContentAlignment = VerticalAlignment.Center;
                v.HorizontalContentAlignment = HorizontalAlignment.Center;
                v.Background = item.Value;
                if(Math.Pow(2, item.Key)==1) v.Content = " ";
                else v.Content = Math.Pow(2,item.Key).ToString();
                MainPanel.Children.Add(v);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Up) 
            {
                cards.MoveAllUp();
            }
            else if (e.Key == Key.Down)
            {
                cards.MoveAllDown();
            }
            else if (e.Key == Key.Right)
            {
                cards.MoveAllRight();
            }
            else if (e.Key == Key.Left)
            {
                cards.MoveAllLeft();
            }
            UpdateTheScore();
            cardsToUI();
            if (cards.Is2048)
            {
                MessageBox.Show("You won!!!!! Congratulations!! (The game will restart when you click OK)", "The end", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                cards = new ActualCardsPlacement();
                TBcurScore.Text = "0";
                cardsToUI();
            }
            else if (!cards.GenerateStarter())
            {
                MessageBox.Show("You lose. Try again","The end", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                cards = new ActualCardsPlacement();
                TBcurScore.Text = "0";
                cardsToUI();
            }
        }

        void UpdateTheScore()
        {
            try
            {
                int score = cards.CalculateScore();
                TBcurScore.Text = score.ToString();
                if (score > Convert.ToInt32(TBbestScore.Text))
                {
                    TBbestScore.Text = score.ToString();
                }
            }
            catch
            {

            }
        }
    }
}
