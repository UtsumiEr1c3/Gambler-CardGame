using CardGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Special5 : MonoBehaviour
{
    public GameManager manager;
    public SinNumber sinNum;

    public Deck deck;

    public void LoadValue()
    {
        GameObject GameManager = GameObject.Find("GameManager");
        manager = GameManager.GetComponent<GameManager>();
    }
    public void Patch()//将上面两类绑定
    {
        GameObject gameObject = GameObject.Find("SinBar");
        sinNum = gameObject.GetComponent<SinNumber>();
        gameObject = GameObject.Find("Deck");
        deck = gameObject.GetComponent<Deck>();
    }

    private void Start()
    {
        LoadValue();
        Patch();
    }

    private void OnMouseDown()
    {
        Power();
    }

    void Power()
    {
        SceneManager.LoadScene("Night");
    }
}
