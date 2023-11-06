using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Login_and_2048_game.Core
{
    class GameValues
    {
        List<KeyValuePair<int, Card>> cardsList;

        public KeyValuePair<int, Card> elementAt(int ind)
        {
            return cardsList.ElementAt(ind);
        }

        public GameValues() 
        {
            cardsList = new List<KeyValuePair<int, Card>>();
            cardsIntialization();
        }

        void cardsIntialization()
        {
            int val = 2;
            while (val < 2049) 
            {
                KeyValuePair<int, Card> kp = new KeyValuePair<int, Card>(val, new Card());
                kp.Value.Content = kp.Key;
                kp.Value.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                kp.Value.FontSize = 25;
                kp.Value.UniformCornerRadius = 30;
                cardsList.Add(kp);
                val *= 2;
            }
            cardsList.Add(new KeyValuePair<int, Card>(-1, new Card()));
            cardsList.ElementAt(0).Value.Background = new SolidColorBrush(Colors.LightYellow);
            cardsList.ElementAt(1).Value.Background = new SolidColorBrush(Colors.Khaki); 
            cardsList.ElementAt(2).Value.Background = new SolidColorBrush(Colors.DarkKhaki);
            cardsList.ElementAt(3).Value.Background = new SolidColorBrush(Colors.Peru);
            cardsList.ElementAt(3).Value.Foreground = new SolidColorBrush(Colors.White);
            cardsList.ElementAt(4).Value.Background = new SolidColorBrush(Colors.SandyBrown);
            cardsList.ElementAt(5).Value.Background = new SolidColorBrush(Colors.Chocolate);
            cardsList.ElementAt(6).Value.Background = new SolidColorBrush(Colors.Orange);
            cardsList.ElementAt(7).Value.Background = new SolidColorBrush(Colors.Coral);
            cardsList.ElementAt(8).Value.Background = new SolidColorBrush(Colors.OrangeRed);
            cardsList.ElementAt(8).Value.Foreground = new SolidColorBrush(Colors.White);
            cardsList.ElementAt(9).Value.Background = new SolidColorBrush(Colors.Goldenrod);
            cardsList.ElementAt(10).Value.Background = new SolidColorBrush(Colors.Magenta);
            cardsList.ElementAt(10).Value.Foreground = new SolidColorBrush(Colors.White);
            cardsList.ElementAt(11).Value.Background = new SolidColorBrush(Colors.LightGoldenrodYellow);
            cardsList.ElementAt(11).Value.UniformCornerRadius = 30;
        }
    }
}
