using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowDescription : MonoBehaviour
{
    public GameObject Description;

    public bool IsSelected = false;
    public RectTransform RT;
    [SerializeField] public int SelectTrans = 100; // 上下移动偏移值
    [SerializeField] public float ScaleTrans = 1.2f; // 鼠标移动到上面时放大的值

    public void Start()
    {
        RT = GetComponent<RectTransform>();
    }

    //public void OnMouseDown()
    //{
    //    IsSelected = !IsSelected; // 切换选中状态
    //    if (IsSelected)
    //    {
    //        RT.anchoredPosition = new Vector2(RT.anchoredPosition.x, RT.anchoredPosition.y + SelectTrans); // 选中则上移
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
