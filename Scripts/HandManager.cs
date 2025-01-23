using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

namespace CardGame
{
    // 管理玩家手牌的类
    public class HandManager : MonoBehaviour
    {
        public int DrawCount=0;

        // 玩家当前的手牌列表
        public List<Card> handCards = new List<Card>();

        // 引用牌组对象
        public Deck deck;

        public SinNumber sinNum;

        // 显示剩余卡牌数量的UI Text组件
        public TextMeshProUGUI remainingCardsText;

        // 用于显示手牌的Image组件列表
        public List<Image> cardImages;

        public Request request;

        public Button playButton;
        public GameManager manager;

        public void LoadValue()
        {
            GameObject GameManager = GameObject.Find("GameManager");
            manager = GameManager.GetComponent<GameManager>();
        }
        // 抽取一张卡牌并添加到手牌
        public void DrawCard()
        {
            int i = Random.Range(0, 2);
            if (deck.RemainingCards==0)
            {                
                int n = Random.Range(0, deck.specialCards.Count);
                deck.specialCards[n].SetActive(true);
                ShowDescription showDescription = deck.specialCards[n].GetComponent<ShowDescription>();
                showDescription.IsSelected = false;
                deck.specialCards.RemoveAt(n);
                DrawCount++;
            }
            else if(deck.specialCards.Count == 0)
            {
                Card drawnCard = deck.DrawCard();
                handCards.Add(drawnCard);
                UpdateHandDisplay();
                DrawCount++;
            }
            else if(i == 0) {
                Card drawnCard = deck.DrawCard();
                handCards.Add(drawnCard);
                UpdateHandDisplay();
                DrawCount++;
            }
            else
            {
                int n = Random.Range(0, deck.specialCards.Count);
                deck.specialCards[n].SetActive(true);
                ShowDescription showDescription = deck.specialCards[n].GetComponent<ShowDescription>();
                showDescription.IsSelected = false;
                deck.specialCards.RemoveAt(n);
                DrawCount++;
            }
            if(DrawCount > 10)
            {
                manager.sinNumber += 2;
            }
        }

        // 更新手牌的显示
        void UpdateHandDisplay()
        {
            for (int i = 0; i < cardImages.Count; i++)
            {
                if (i < handCards.Count)
                {
                    Card card = handCards[i];
                    string cardName = $"{card.CardRank}_of_{card.CardSuit}";
                    Sprite cardSprite = Resources.Load<Sprite>("CardImages/" + cardName);
                    if (cardSprite != null)
                    {
                        cardImages[i].sprite = cardSprite;
                        cardImages[i].gameObject.SetActive(true);


                        // Set the card in the CardLogic component
                        CardLogic cardLogic = cardImages[i].GetComponent<CardLogic>();
                        if (cardLogic != null)
                        {
                            cardLogic.SetCard(card);
                            cardLogic.IsSelected = false;
                        }
                        else
                        {
                            Debug.LogError("CardLogic component not found on card image.");
                        }
                    }
                    else
                    {
                        Debug.LogError("Card Sprite can not found: " + cardName);
                    }
                }
                else
                {
                    cardImages[i].gameObject.SetActive(false);
                }
            }
        }

        public void Patch()//将上面两类绑定
        {
            GameObject gameObject = GameObject.Find("SinBar");
            sinNum = gameObject.GetComponent<SinNumber>();
            gameObject = GameObject.Find("Deck");
            deck = gameObject.GetComponent<Deck>();
        }

        // 初始化，在Start中查找必要的组件
        void Start()
        {
            if (remainingCardsText == null)
            {
                remainingCardsText = GameObject.Find("RemainingCardsText").GetComponent<TextMeshProUGUI>();
                if (remainingCardsText == null)
                {
                    Debug.LogError("Could not find RemainingCardsText object");
                }
            }
            if (deck == null)
            {
                deck = FindObjectOfType<Deck>();
                if (deck == null)
                {
                    Debug.LogError("Could not find Deck object in the scene");
                }
            }
            Patch();
            LoadValue();


        }

        // 每帧更新剩余卡牌数量的显示
        void Update()
        {
            if (remainingCardsText != null && deck != null)
            {
                int i = deck.RemainingCards + deck.specialCards.Count;
                remainingCardsText.text = "剩余卡牌: " + i;
            }
            else
            {
                Debug.LogWarning("remainingCardsText or deck is null in HandManager");
            }
        }

        // 打出选中卡牌
        public void PlaySelectedCards()
        {
            manager.sinNumber += 2;
            List<Card> selectedCards = new List<Card>();
            foreach (var cardImage in cardImages)
            {
                CardLogic cardLogic = cardImage.GetComponent<CardLogic>();
                if (cardLogic != null && cardLogic.IsSelected)
                {
                    selectedCards.Add(cardLogic.GetCard());
                }
            }

            if (request != null)//加入到已打出的牌中
            {
                if (request.PlayedCards != null)
                {
                    request.PlayedCards.Clear();
                }
                request.PlayedCards.AddRange(selectedCards);
                request.LoadCardRanks();
                //request.ShowScore();
            }
            foreach (var card in selectedCards)//移除手牌中已选中的牌
            {
                handCards.Remove(card);
            }

            UpdateHandDisplay();
        }
    }
}
