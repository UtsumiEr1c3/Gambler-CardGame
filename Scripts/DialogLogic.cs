using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogLogic : MonoBehaviour
{
    public bool IsTutorial = true;
    //UI文本
    public TMP_Text UITextMeshPro;

    //角色图片集合
    public List<Sprite> sprites;

    //文本索引
    int index;

    //名字对应图片
    Dictionary<string, Sprite> spriteDictionary = new Dictionary<string, Sprite>();

    //档期对话索引值
    public int dialogIndex;

    //对话内容
    Dictionary<int, string> AllText = new Dictionary<int, string>();

    public GameObject button;
    public GameManager manager;

    public void LoadValue()
    {
        GameObject GameManager = GameObject.Find("GameManager");
        manager = GameManager.GetComponent<GameManager>();
        
    }

    //更新文本
    public void UpdateText(string text)
    {
        UITextMeshPro.text = text;
    }
    private void LoadTutorial()
    {        
        AllText[0] = "你有你的欲望，他有他的欲望，打牌，就是互相交换的过程。";
        AllText[1] = "一张牌能够满足对面多个委托时候，你可以只用一张牌。";
        AllText[2] = "注意，每回合出牌次数有限，如果你的出牌回数使用完毕了，会直接进入下一轮。";
        AllText[3] = "同样，你的手牌也是有限的，当你的手牌打完了，却还没有完成委托的时候，我建议你直接进入下一轮。";
        AllText[4] = "强行去掠夺他人的欲望只会让你自己的罪恶白白增加。";


        AllText[5] = "去尝试和别人交换欲望吧。";
        AllText[6] = "在回合的任意时候，你都可以点击这个按钮，进入下一个环节。";


        AllText[7] = "好了，你已经是个合格的交互者了，现在该你去完成其他人的欲望了。";
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
    //显示当前文本
    public void ShowDialogRow(int index)
    {
        UpdateText(AllText[index]);
    }
    //点击继续按钮
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
