using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SinNumber : MonoBehaviour
{
    public int sinNumber;

    public TMP_Text T_text;

    public GameObject OutofLimit;

    public GameManager manager;

    private void Start()
    {
        LoadValue();
    }

    public void LoadValue()
    {
        GameObject GameManager = GameObject.Find("GameManager");
        manager = GameManager.GetComponent<GameManager>();
        sinNumber = manager.sinNumber;
    }


    private void Update()
    {
        ShowSinNumber();
        DetectSin();
    }

    void DetectSin()
    {
        if (sinNumber >= 90)
        {
            OutofLimit.SetActive(true);    
        }
        if(sinNumber < 90)
        {
            OutofLimit.SetActive(false);
        }
    }

    void ShowSinNumber()
    {
        sinNumber = manager.sinNumber;
        T_text.text = sinNumber.ToString() + "/90";
    }
}
