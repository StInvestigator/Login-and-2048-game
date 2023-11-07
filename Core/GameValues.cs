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
        List<KeyValuePair<int, Brush>> cardsList;

        public KeyValuePair<int, Brush> elementAt(int ind)
        {
            return cardsList.ElementAt(ind);
        }

        public GameValues() 
        {
            cardsList = new List<KeyValuePair<int, Brush>>();
            cardsIntialization();
        }

        void cardsIntialization()
        {
            cardsList.Add(new KeyValuePair<int, Brush>(0, new SolidColorBrush(Colors.LightCyan)));
            cardsList.Add(new KeyValuePair<int, Brush>(1, new SolidColorBrush(Colors.LightYellow)));
            cardsList.Add(new KeyValuePair<int, Brush>(2, new SolidColorBrush(Colors.Khaki)));
            cardsList.Add(new KeyValuePair<int, Brush>(3, new SolidColorBrush(Colors.DarkKhaki)));
            cardsList.Add(new KeyValuePair<int, Brush>(4, new SolidColorBrush(Colors.Peru)));
            cardsList.Add(new KeyValuePair<int, Brush>(5, new SolidColorBrush(Colors.SandyBrown)));
            cardsList.Add(new KeyValuePair<int, Brush>(6, new SolidColorBrush(Colors.Chocolate)));
            cardsList.Add(new KeyValuePair<int, Brush>(7, new SolidColorBrush(Colors.Orange)));
            cardsList.Add(new KeyValuePair<int, Brush>(8, new SolidColorBrush(Colors.Coral)));
            cardsList.Add(new KeyValuePair<int, Brush>(9, new SolidColorBrush(Colors.OrangeRed)));
            cardsList.Add(new KeyValuePair<int, Brush>(10, new SolidColorBrush(Colors.Goldenrod)));
            cardsList.Add(new KeyValuePair<int, Brush>(11, new SolidColorBrush(Colors.Magenta)));
        }
    }
}
