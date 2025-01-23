using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlaySoundOnClick : MonoBehaviour, IPointerClickHandler
{
    public AudioSource audioSource; // 用于播放音效的 AudioSource

    // 当点击事件发生时调用
    public void OnPointerClick(PointerEventData eventData)
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
