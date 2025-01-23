using UnityEngine;

namespace CardGame
{
    public class CardLogic : MonoBehaviour
    {
        public bool IsSelected = false;
        public RectTransform RT;
        [SerializeField] public int SelectTrans = 100; // �����ƶ�ƫ��ֵ
        [SerializeField] public float ScaleTrans = 1.2f; // ����ƶ�������ʱ�Ŵ��ֵ

        private Card card;

        public void Start()
        {
            RT = GetComponent<RectTransform>();
        }

        public void OnMouseDown()
        {
            IsSelected = !IsSelected; // �л�ѡ��״̬
            if (IsSelected)
            {
                RT.anchoredPosition = new Vector2(RT.anchoredPosition.x, RT.anchoredPosition.y + SelectTrans); // ѡ��������
            }
            else
            {
                RT.anchoredPosition = new Vector2(RT.anchoredPosition.x, RT.anchoredPosition.y - SelectTrans);
            }
        }

        public void OnMouseEnter() // �������ȥʱ����
        {
            RT.localScale *= ScaleTrans;
        }

        public void OnMouseExit()
        {
            RT.localScale /= ScaleTrans;
        }

        public void SetCard(Card card)
        {
            this.card = card;
        }

        public Card GetCard()
        {
            return card;
        }
    }
}
