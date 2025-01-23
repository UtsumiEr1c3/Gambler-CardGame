using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;


namespace CardGame {
    public class Request : MonoBehaviour
    {
        //public TMP_Text text;//�����ı�

        public List<Card> PlayedCards = new List<Card>();//�Ѵ������

        public List<int> CardRanks = new List<int>();

        

        public void LoadCardRanks()//��rank����������ں�����
        {
            for (int i = 0; i < PlayedCards.Count; i++)
            {
                CardRanks.Add((int)PlayedCards[i].CardRank);//�ܷ��������д���
            }

            CardRanks.Sort();
        }

        public int checkHighCard()//���������
        {
            int Max = CardRanks[CardRanks.Count - 1];

            return Max;
        }

        public bool checkFlush()//�����Ƿ���ͬ��
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

        public bool checkPair()//����Ƿ���ڶ���
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

        public bool checkThree()//����Ƿ��������
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

        public bool checkFour()//�������
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

        public bool checkStraight()//���˳��
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

        public bool checkFullHouse()//����«
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

        //public void ShowScore()//�����ǰ���
        //{
        //    if (checkFlush())
        //    {
        //        text.text += "ͬ��";
        //    }
        //    if (checkPair())
        //    {
        //        text.text += "����";
        //    }
        //    if (checkThree())
        //    {
        //        text.text += "����";
        //    }
        //    if (checkFour())
        //    {
        //        text.text += "����";
        //    }
        //    if (checkStraight())
        //    {
        //        text.text += "˳��";
        //    }
        //    if (checkFullHouse())
        //    {
        //        text.text += "��«";
        //    }
        //    text.text += "����Ϊ" + checkHighCard();
        //}









    }
}

