using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlaySoundOnClick : MonoBehaviour, IPointerClickHandler
{
    public AudioSource audioSource; // ���ڲ�����Ч�� AudioSource

    // ������¼�����ʱ����
    public void OnPointerClick(PointerEventData eventData)
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
