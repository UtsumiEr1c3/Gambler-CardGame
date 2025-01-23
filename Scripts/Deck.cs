using UnityEngine;
using System;
using System.Collections.Generic;

namespace CardGame
{
    // 管理一副扑克牌的类，继承自MonoBehavior以便在Unity中使用
    public class Deck : MonoBehaviour
    {
        // 存储卡牌的列表
        public List<Card> Assetscards = new List<Card>();
        private List<Card> cards;

        //储存特殊牌的列表
        public List<GameObject> AssetsSpecialCards = new List<GameObject>();
        public List<GameObject> specialCards;

        public GameObject goToBeAdd;
        // 属性：获取剩余卡牌数量
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

        public void CopyDeck()//将储存用牌转到使用牌中
        {
            cards = new List<Card>(manager.Assetscards);
            specialCards = new List<GameObject>();
            for (int i = 0; i < manager.SpecialCardsNum; i++)
            {
                specialCards.Add(AssetsSpecialCards[UnityEngine.Random.Range(0,AssetsSpecialCards.Count)]);
            }
        }


        // 抽取一张卡牌
        public Card DrawCard()
        {
            if (cards.Count > 0)
            {
                Card drawnCard = cards[0];
                cards.RemoveAt(0);
                return drawnCard;
            }
            return null; // 如果牌组为空，返回null
        }       
        
    }
}