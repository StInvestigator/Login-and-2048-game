using Login_and_2048_game.Core;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Login_and_2048_game.Domain
{
    public class ActualCardsPlacement : IEnumerable
    {
        List<KeyValuePair<int, Brush>> list;
        GameValues values = new GameValues();
        bool is2048;

        public bool Is2048
        {
            get { return is2048; }
        }

        public ActualCardsPlacement()
        {
            is2048 = false;
            list = new List<KeyValuePair<int, Brush>>();
            for (int i = 0; i < 16; i++)
            {
                list.Add(values.elementAt(0));
            }
            for (int i = 0; i < 4; i++)
            {
                GenerateStarter();
            }
        }

        void NextValue(int index)
        {
            List<KeyValuePair<int, Brush>> newList = new List<KeyValuePair<int, Brush>>();
            for(int i = 0;i < 16;i++) 
            {
                if (i != index) newList.Add(list[i]);
                if (i == index) newList.Add(values.elementAt(list[i].Key+1));
            }
            list = newList;
        }

        void NextValue(int startIndex, int endIndex)
        {
            List<KeyValuePair<int, Brush>> newList = new List<KeyValuePair<int, Brush>>();
            for (int i = 0; i < 16; i++)
            {
                if (i != startIndex && i != endIndex) newList.Add(list[i]);
                if (i == endIndex) newList.Add(values.elementAt(list[i].Key + 1));
                if (list[i].Key + 1 == 11) is2048 = true;
                if (i == startIndex) newList.Add(values.elementAt(0));
            }
            list = newList;
        }

        public bool GenerateStarter()
        {
            List<int> empty = new List<int>();
            for (int i = 0; i<16;i++)
            {
                if (list[i].Key == 0) empty.Add(i);
            }
            Random rand = new Random();
            if (empty.Count == 0) return false;
            int index = empty.ElementAt(rand.Next(0, empty.Count-1));
            int val = rand.Next(1, 4);
            NextValue(index);
            if (val == 3)
            {
                NextValue(index);
            }
            return true;
        }

        public void Reset()
        {
            list.Clear();
            for (int i = 0; i < 16; i++)
            {
                list.Add(values.elementAt(11));
            }
        }

        public KeyValuePair<int, Brush> elementAt(int ind)
        {
            return list.ElementAt(ind);
        }

        public IEnumerator GetEnumerator() => list.GetEnumerator();

        void Move(int startIndex, int endIndex)
        {
            List<KeyValuePair<int, Brush>> newList = new List<KeyValuePair<int, Brush>>();
            for (int i = 0; i < 16; i++)
            {
                if (i != startIndex && i!= endIndex) newList.Add(list[i]);
                if (i == endIndex) newList.Add(list[startIndex]);
                if (i == startIndex) newList.Add(values.elementAt(0));
            }
            list = newList;
        }

        public void MoveAllUp()
        {
            for (int i = 4; i > 1; i--)
            {
                for (int j = 4; j < i * 4; j++)
                {
                    if (list[j].Key != 0)
                    {
                        if (list[j - 4].Key == 0)
                        {
                            Move(j, j - 4);
                        }
                        else if (list[j - 4].Key == list[j].Key)
                        {
                            NextValue(j, j - 4);
                        }
                    }
                }
            }
        }

        public void MoveAllDown()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 11; j >= i * 4; j--)
                {
                    if (list[j].Key != 0)
                    {
                        if (list[j + 4].Key == 0)
                        {
                            Move(j, j + 4);
                        }
                        else if (list[j + 4].Key == list[j].Key)
                        {
                            NextValue(j, j + 4);
                        }
                    }
                }
            }
        }

        public void MoveAllRight()
        {
            for (int k = 0; k < 4; k++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = i * 4 + 2; j >= i * 4; j--)
                    {
                        if (list[j].Key != 0)
                        {
                            if (list[j + 1].Key == 0)
                            {
                                Move(j, j + 1);
                            }
                            else if (list[j + 1].Key == list[j].Key)
                            {
                                NextValue(j, j + 1);
                            }
                        }
                    }
                }
            }
        }

        public void MoveAllLeft()
        {
            for (int k = 0; k < 4; k++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = i * 4 + 1; j < i * 4 + 4; j++)
                    {
                        if (list[j].Key != 0)
                        {
                            if (list[j - 1].Key == 0)
                            {
                                Move(j, j - 1);
                            }
                            else if (list[j - 1].Key == list[j].Key)
                            {
                                NextValue(j, j - 1);
                            }
                        }
                    }
                }
            }
        }

        public int CalculateScore()
        {
            int score = 0;
            foreach (var item in list)
            {
                if(item.Key!=0) score += Convert.ToInt32(Math.Pow(2, item.Key));
            }
            return score;
        }

    }
}
