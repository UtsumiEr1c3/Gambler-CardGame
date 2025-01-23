using CardGame;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mission : MonoBehaviour//NPC委托实现
{
    public TMP_Text m_text;

    public bool isCompleted = false;

    public Request request;

    public SinNumber sinNum;

    public Deck deck;

    public GameManager manager;

    public void LoadValue()
    {
        GameObject GameManager = GameObject.Find("GameManager");
        manager = GameManager.GetComponent<GameManager>();
    }

    [SerializeField] int DeleteValue = 10;

     public void LoadRequest()//找到生成位置
    {
        GameObject gameObject = GameObject.Find("MissionTargets");
        request = gameObject.GetComponent<Request>();
    }

    public void Patch()//将上面两类绑定
    {
        GameObject gameObject = GameObject.Find("SinBar");
        sinNum = gameObject.GetComponent<SinNumber>();
        gameObject = GameObject.Find("Deck");
        deck = gameObject.GetComponent<Deck>();
    }


    public void Start()
    {
        LoadRequest();
        Patch();
        LoadValue();
    }

    public void Update()
    {
        if(checkCard(Card.Suit.Hearts,Card.Rank.Ace))
        {
            isCompleted = true;
        }
        Disappear();
    }

    public bool checkCard(Card.Suit suit , Card.Rank rank)//检验是否有某张牌
    {
        for (int i = 0; i < request.PlayedCards.Count; i++)
        {
            if (request.PlayedCards[i].CardRank == rank)
            {
                if (request.PlayedCards[i].CardSuit == suit)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void Disappear()
    {
        if(isCompleted)
        {
            manager.sinNumber -= DeleteValue;
            Destroy(gameObject);            
        }
    }
}


