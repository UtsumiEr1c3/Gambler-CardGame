using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;


namespace CardGame {
    public class Request : MonoBehaviour
    {
        //public TMP_Text text;//任务文本

        public List<Card> PlayedCards = new List<Card>();//已打出的牌

        public List<int> CardRanks = new List<int>();

        

        public void LoadCardRanks()//将rank单独排序便于后面检测
        {
            for (int i = 0; i < PlayedCards.Count; i++)
            {
                CardRanks.Add((int)PlayedCards[i].CardRank);//能否正常运行存疑
            }

            CardRanks.Sort();
        }

        public int checkHighCard()//返回最高牌
        {
            int Max = CardRanks[CardRanks.Count - 1];

            return Max;
        }

        public bool checkFlush()//返回是否是同花
        {
            bool IsSameColor = true;
            for (int i = 0; i < PlayedCards.Count - 1; i++)
            {
                if (PlayedCards[i].CardSuit != PlayedCards[i + 1].CardSuit)
                {
                    IsSameColor = false;
                    break;
                }                
            }

            return IsSameColor;
        }

        public bool checkPair()//检测是否存在对子
        {
            bool IsPair = false;
            for(int i = 0;i < CardRanks.Count - 1;i++)
            {
                if (CardRanks[i] == CardRanks[i + 1])
                {
                    IsPair = true;  
                    break;  
                }
            }
            return IsPair;
        }

        public bool checkThree()//检测是否存在三条
        {
            bool IsTrible = false;
            for (int i = 0; i < CardRanks.Count - 2; i++)
            {
                if (CardRanks[i] == CardRanks[i + 1])
                {
                    if(CardRanks[i] == CardRanks[i + 2])
                    {
                        IsTrible = true;
                        break;
                    }                    
                }
            }
            return IsTrible;
        }

        public bool checkFour()//检测四条
        {
            bool IsFour = false;
            for (int i = 0; i < CardRanks.Count - 3; i++)
            {
                if (CardRanks[i] == CardRanks[i + 1])
                {
                    if (CardRanks[i] == CardRanks[i + 2])
                    {
                        if(CardRanks[i] == CardRanks[i + 3])
                        {
                            IsFour = true;
                            break;
                        }                        
                    }
                }
            }

            return IsFour;
        }

        public bool checkStraight()//检测顺子
        {
            bool IsStraight = true;
            for (int i = 0; i < CardRanks.Count - 1; i++)
            {
                if (CardRanks[i] != CardRanks[i + 1] - 1)
                {
                    IsStraight = false;
                    break;
                }
            }
            return IsStraight;
        }

        public bool checkFullHouse()//检测葫芦
        {
            int trible=0;
            bool IsTrible = false;
            bool IsPair = false;
            bool IsFullHouse = false;
            for (int i = 0; i < CardRanks.Count - 2; i++)
            {
                if (CardRanks[i] == CardRanks[i + 1])
                {
                    if (CardRanks[i] == CardRanks[i + 2])
                    {
                        IsTrible = true;
                        trible = CardRanks[i];
                        break;
                    }
                }
            }
            for (int i = 0; i < CardRanks.Count - 2; i++)
            {
                if (CardRanks[i] == trible)
                {
                    continue;
                }
                if (CardRanks[i] == CardRanks[i + 1])
                {
                    IsPair = true;
                    break;
                }

            }
            if(IsPair&&IsTrible)
            {
                IsFullHouse = true;
            }

            return IsFullHouse;
        }

        //public void ShowScore()//输出当前类别
        //{
        //    if (checkFlush())
        //    {
        //        text.text += "同花";
        //    }
        //    if (checkPair())
        //    {
        //        text.text += "对子";
        //    }
        //    if (checkThree())
        //    {
        //        text.text += "三条";
        //    }
        //    if (checkFour())
        //    {
        //        text.text += "四条";
        //    }
        //    if (checkStraight())
        //    {
        //        text.text += "顺子";
        //    }
        //    if (checkFullHouse())
        //    {
        //        text.text += "葫芦";
        //    }
        //    text.text += "高牌为" + checkHighCard();
        //}









    }
}

