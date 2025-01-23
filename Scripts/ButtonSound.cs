using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public Button yourButton; // 引用你的按钮
    public AudioClip clickSound; // 引用按钮点击的音频剪辑
    private GameObject soundPlayer; // 用于播放音效的临时游戏对象

    void Start()
    {
        // 获取按钮组件，并注册点击事件
        if (yourButton != null)
        {
            yourButton.onClick.AddListener(PlayClickSound);
        }

        // 创建临时游戏对象用于播放音效
        soundPlayer = new GameObject("SoundPlayer");
        soundPlayer.AddComponent<AudioSource>();
    }

    // 播放按钮点击音效的方法
    void PlayClickSound()
    {
        if (clickSound != null)
        {
            // 从临时游戏对象的AudioSource组件中播放音效
            soundPlayer.GetComponent<AudioSource>().PlayOneShot(clickSound);
        }
    }

    private void OnDestroy()
    {
        // 在销毁脚本时销毁临时游戏对象
        Destroy(soundPlayer);
    }
}