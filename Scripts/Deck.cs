using UnityEngine;
using System;
using System.Collections.Generic;

namespace CardGame
{
    // ����һ���˿��Ƶ��࣬�̳���MonoBehavior�Ա���Unity��ʹ��
    public class Deck : MonoBehaviour
    {
        // �洢���Ƶ��б�
        public List<Card> Assetscards = new List<Card>();
        private List<Card> cards;

        //���������Ƶ��б�
        public List<GameObject> AssetsSpecialCards = new List<GameObject>();
        public List<GameObject> specialCards;

        public GameObject goToBeAdd;
        // ���ԣ���ȡʣ�࿨������
        public int RemainingCards => cards.Count;

        public GameManager manager;

        private void Start()
        {
            LoadValue();
            CopyDeck();
        }

        public void LoadValue()
        {
            GameObject GameManager = GameObject.Find("GameManager");
            manager = GameManager.GetComponent<GameManager>();
        }        

        public void CopyDeck()//����������ת��ʹ������
        {
            cards = new List<Card>(manager.Assetscards);
            specialCards = new List<GameObject>();
            for (int i = 0; i < manager.SpecialCardsNum; i++)
            {
                specialCards.Add(AssetsSpecialCards[UnityEngine.Random.Range(0,AssetsSpecialCards.Count)]);
            }
        }


        // ��ȡһ�ſ���
        public Card DrawCard()
        {
            if (cards.Count > 0)
            {
                Card drawnCard = cards[0];
                cards.RemoveAt(0);
                return drawnCard;
            }
            return null; // �������Ϊ�գ�����null
        }       
        
    }
}