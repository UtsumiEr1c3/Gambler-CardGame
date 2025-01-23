using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogLogic : MonoBehaviour
{
    public bool IsTutorial = true;
    //UI�ı�
    public TMP_Text UITextMeshPro;

    //��ɫͼƬ����
    public List<Sprite> sprites;

    //�ı�����
    int index;

    //���ֶ�ӦͼƬ
    Dictionary<string, Sprite> spriteDictionary = new Dictionary<string, Sprite>();

    //���ڶԻ�����ֵ
    public int dialogIndex;

    //�Ի�����
    Dictionary<int, string> AllText = new Dictionary<int, string>();

    public GameObject button;
    public GameManager manager;

    public void LoadValue()
    {
        GameObject GameManager = GameObject.Find("GameManager");
        manager = GameManager.GetComponent<GameManager>();
        
    }

    //�����ı�
    public void UpdateText(string text)
    {
        UITextMeshPro.text = text;
    }
    private void LoadTutorial()
    {        
        AllText[0] = "������������������������������ƣ����ǻ��ཻ���Ĺ��̡�";
        AllText[1] = "һ�����ܹ����������ί��ʱ�������ֻ��һ���ơ�";
        AllText[2] = "ע�⣬ÿ�غϳ��ƴ������ޣ������ĳ��ƻ���ʹ������ˣ���ֱ�ӽ�����һ�֡�";
        AllText[3] = "ͬ�����������Ҳ�����޵ģ���������ƴ����ˣ�ȴ��û�����ί�е�ʱ���ҽ�����ֱ�ӽ�����һ�֡�";
        AllText[4] = "ǿ��ȥ�Ӷ����˵�����ֻ�������Լ������װ����ӡ�";


        AllText[5] = "ȥ���Ժͱ��˽��������ɡ�";
        AllText[6] = "�ڻغϵ�����ʱ���㶼���Ե�������ť��������һ�����ڡ�";


        AllText[7] = "���ˣ����Ѿ��Ǹ��ϸ�Ľ������ˣ����ڸ���ȥ��������˵������ˡ�";
    }
    private void Awake()
    {
        
    }
    void Start()
    {
        LoadValue();
        if (manager.IsTutorial)
        {
            LoadTutorial();
            UpdateText(AllText[0]);
        }
        else
        {
            UITextMeshPro.text = "";
            button.SetActive(false);
        }
        
    }
    //��ʾ��ǰ�ı�
    public void ShowDialogRow(int index)
    {
        UpdateText(AllText[index]);
    }
    //���������ť
    public void OnChickNext()
    {
        index++;

        if (index < AllText.Count)
        ShowDialogRow(index);
        if(index >= AllText.Count)
        {
            UITextMeshPro.text = "";
            manager.IsTutorial = false;
            gameObject.SetActive(false);
            
            
        }
        

    }

}
