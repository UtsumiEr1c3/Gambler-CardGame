using CardGame;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mission3 : MonoBehaviour
{
    public TMP_Text m_text;

    public bool isCompleted = false;

    public Request request;

    public SinNumber sinNum;

    public Deck deck;

    [SerializeField] int DeleteValue = 10;
    public GameManager manager;

    public void LoadValue()
    {
        GameObject GameManager = GameObject.Find("GameManager");
        manager = GameManager.GetComponent<GameManager>();
    }

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
        if (request.checkFlush() && request.PlayedCards.Count >= 3)
        {
            isCompleted = true;
        }
        Disappear();
    }

    public void Disappear()
    {
        if (isCompleted)
        {
            manager.sinNumber -= DeleteValue;
            Destroy(gameObject);

        }
    }
}
