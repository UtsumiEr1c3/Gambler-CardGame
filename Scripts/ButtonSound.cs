using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public Button yourButton; // ������İ�ť
    public AudioClip clickSound; // ���ð�ť�������Ƶ����
    private GameObject soundPlayer; // ���ڲ�����Ч����ʱ��Ϸ����

    void Start()
    {
        // ��ȡ��ť�������ע�����¼�
        if (yourButton != null)
        {
            yourButton.onClick.AddListener(PlayClickSound);
        }

        // ������ʱ��Ϸ�������ڲ�����Ч
        soundPlayer = new GameObject("SoundPlayer");
        soundPlayer.AddComponent<AudioSource>();
    }

    // ���Ű�ť�����Ч�ķ���
    void PlayClickSound()
    {
        if (clickSound != null)
        {
            // ����ʱ��Ϸ�����AudioSource����в�����Ч
            soundPlayer.GetComponent<AudioSource>().PlayOneShot(clickSound);
        }
    }

    private void OnDestroy()
    {
        // �����ٽű�ʱ������ʱ��Ϸ����
        Destroy(soundPlayer);
    }
}