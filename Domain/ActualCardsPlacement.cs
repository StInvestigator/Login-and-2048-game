using Login_and_2048_game.Core;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_and_2048_game.Domain
{
    public class ActualCardsPlacement : IEnumerable
    {
        List<KeyValuePair<int, Card>> list;
        GameValues values = new GameValues();

        public ActualCardsPlacement()
        {
            list = new List<KeyValuePair<int, Card>>();
            for (int i = 0; i < 16; i++) 
            {
                list.Add(values.elementAt(11));
            }
        }

        public void Add(int index, int valueIndex)
        {
            List<KeyValuePair<int, Card>> newList = list = new List<KeyValuePair<int, Card>>();
            for(int i = 0;i < 16;i++) 
            {
                if (i < index) newList.Add(list[i]);
                if (i == index) newList.Add(values.elementAt(valueIndex));
                if (i > index) newList.Add(list[i-1]);
            }
            list = newList;
        }

        public void Reset()
        {
            list.Clear();
            for (int i = 0; i < 16; i++)
            {
                list.Add(values.elementAt(11));
            }
        }

        public KeyValuePair<int, Card> elementAt(int ind)
        {
            return list.ElementAt(ind);
        }

        public IEnumerator GetEnumerator() => list.GetEnumerator();
    }
}
