using System;

namespace CardGame
{
    // 表示一张扑克牌的类
    public class Card
    {
        // 定义扑克牌的四种花色
        public enum Suit { Clubs, Diamonds, Spades, Hearts }

        // 定义扑克牌的13种点数，从Ace（1）到King（13）
        public enum Rank { Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }

        // 获取或设置卡牌的花色
        public Suit CardSuit { get; private set; }

        // 获取或设置卡牌的点数
        public Rank CardRank { get; private set; }

        // 构造函数，创建一张具有指定花色和点数的扑克牌
        public Card(Suit suit, Rank rank)
        {
            CardSuit = suit;
            CardRank = rank;
        }

        // 重写ToString方法，返回卡牌的字符串表示
        public override string ToString()
        {
            return $"{CardRank} of {CardSuit}";
        }
    }
}