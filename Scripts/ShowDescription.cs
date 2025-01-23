using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowDescription : MonoBehaviour
{
    public GameObject Description;

    public bool IsSelected = false;
    public RectTransform RT;
    [SerializeField] public int SelectTrans = 100; // �����ƶ�ƫ��ֵ
    [SerializeField] public float ScaleTrans = 1.2f; // ����ƶ�������ʱ�Ŵ��ֵ

    public void Start()
    {
        RT = GetComponent<RectTransform>();
    }

    //public void OnMouseDown()
    //{
    //    IsSelected = !IsSelected; // �л�ѡ��״̬
    //    if (IsSelected)
    //    {
    //        RT.anchoredPosition = new Vector2(RT.anchoredPosition.x, RT.anchoredPosition.y + SelectTrans); // ѡ��������
    //    }
    //    else
    //    {
    //        RT.anchoredPosition = new Vector2(RT.anchoredPosition.x, RT.anchoredPosition.y - SelectTrans);
    //    }
    //}

    public void OnMouseEnter()
    {
        RT.localScale *= ScaleTrans;
        Description.SetActive(true);
    }

    public void OnMouseExit()
    {
        RT.localScale /= ScaleTrans;
        Description.SetActive(false);   
    }
}
