using System;

namespace CardGame
{
    // ��ʾһ���˿��Ƶ���
    public class Card
    {
        // �����˿��Ƶ����ֻ�ɫ
        public enum Suit { Clubs, Diamonds, Spades, Hearts }

        // �����˿��Ƶ�13�ֵ�������Ace��1����King��13��
        public enum Rank { Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }

        // ��ȡ�����ÿ��ƵĻ�ɫ
        public Suit CardSuit { get; private set; }

        // ��ȡ�����ÿ��Ƶĵ���
        public Rank CardRank { get; private set; }

        // ���캯��������һ�ž���ָ����ɫ�͵������˿���
        public Card(Suit suit, Rank rank)
        {
            CardSuit = suit;
            CardRank = rank;
        }

        // ��дToString���������ؿ��Ƶ��ַ�����ʾ
        public override string ToString()
        {
            return $"{CardRank} of {CardSuit}";
        }
    }
}