using CardGame;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool IsTutorial;

    public int sinNumber = 0;//��¼���ֵ
    public string SceneName;

    public List<Card> Assetscards = new List<Card>();//����ͨ����
    public List<GameObject> AssetsSpecialCards = new List<GameObject>();//���⿨��
    public int SpecialCardsNum = 0;
    private void Start()//��������
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
    void InitializeDeck()// ��ʼ�����飬����52�ű�׼�˿���
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
            SceneManager.LoadScene("��ʼ��Ϸ����");
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            sinNumber = 0;
        }
    }
        
}
