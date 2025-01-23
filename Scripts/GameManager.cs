using CardGame;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool IsTutorial;

    public int sinNumber = 0;//记录罪恶值
    public string SceneName;

    public List<Card> Assetscards = new List<Card>();//总普通卡组
    public List<GameObject> AssetsSpecialCards = new List<GameObject>();//特殊卡组
    public int SpecialCardsNum = 0;
    private void Start()//持续存在
    {
        DontDestroyOnLoad(this.gameObject);
        InitializeDeck();
        ShuffleDeck();
        IsTutorial = true;
    }
    private void Update()
    {
        GetSceneName();
        BackDoor();
    }
    public void GetSceneName()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneName = scene.name;
    }    
    void InitializeDeck()// 初始化牌组，创建52张标准扑克牌
    {
        foreach (Card.Suit suit in Enum.GetValues(typeof(Card.Suit)))
        {
            foreach (Card.Rank rank in Enum.GetValues(typeof(Card.Rank)))
            {
                Assetscards.Add(new Card(suit, rank));
            }
        }
    }
    void ShuffleDeck()
    {
        System.Random rng = new System.Random();
        int n = Assetscards.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card value = Assetscards[k];
            Assetscards[k] = Assetscards[n];
            Assetscards[n] = value;
        }
    }
    public void AddCard(Card.Suit suit, Card.Rank rank)
    {
        Assetscards.Add(new Card(suit, rank));
    }
    public void AddSpecialCards()
    {
        SpecialCardsNum++;
        sinNumber += 20;
    }

    public void BackDoor()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("开始游戏界面");
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            sinNumber = 0;
        }
    }
        
}
