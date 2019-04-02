using System;
using System.Collections.Generic;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Player cooper = new Player("Cooper");
            Deck deck = new Deck();
            cooper.Draw(deck);
            Console.WriteLine(cooper.hand[0].stringVal + cooper.hand[0].suit);
            Console.WriteLine(cooper.Discard(0));
            Console.WriteLine(cooper.Discard(5));
            // Console.WriteLine(deck.Deal().stringVal);
            // Console.WriteLine("Cards in Deck: "+ deck.cards.Count);
            // deck.Reset();
            // Console.WriteLine("Cards in Deck: "+ deck.cards.Count);
            // deck.Shuffle();
            // foreach(Card card in deck.cards)
            // {
            //     Console.WriteLine("Card: "+ card.stringVal + " " + card.suit + " " + card.val);
            // }
            
        }
    }

    class Card
    {
        public string stringVal;
        public string suit;
        public int val;
        public Card(string sVal, string type, int value)
        {
            stringVal = sVal;
            suit = type;
            val = value;
        }
    }
    class Deck
    {
        string[] suits = {"Clubs", "Diamonds", "Hearts", "Spades"};
        string[] values = {"Ace", "Two", "Three", "Four","Five", "Six", "Seven", "Eight","Nine", "Ten", "Jack", "Queen", "King"};
        public List<Card> cards = new List<Card>();

        public Deck()
        {
            Reset();
        }

        public List<Card> Reset()
        {
            cards.Clear();
            int start = 0;
            while(start < suits.Length)
            {
                for(int i = 0; i < values.Length; i++)
                {
                    cards.Add(new Card(values[i], suits[start], i+1));
                }
                start++;
            }
            return cards;
        }

        public List<Card> Shuffle()
        {
            Random rand = new Random();
            Card temp;

            for(int i = 0; i < cards.Count; i++){
                int num = rand.Next(0, cards.Count-1);
                temp = cards[i];
                cards[i] = cards[num];
                cards[num] = temp;
            }
            return cards;
        }

        public Card Deal()
        {
            if(cards.Count > 0)
            {
            Card dealt = cards[cards.Count-1];
            cards.RemoveAt(cards.Count-1);
            return dealt;
            }
            else
            {
                return null;
            }
            
        }
    }
    class Player
    {
        public string name;
        public List<Card> hand = new List<Card>();

        public Player(string Name)
        {
            name = Name;
        }

        public Card Draw(Deck deck)
        {
            Card card = deck.Deal();
            hand.Add(card);
            return card;
        }

        public Card Discard(int idx)
        {
            if(idx >= 0 && idx <= hand.Count-1)
            {
                Card card = hand[idx];
                hand.RemoveAt(idx);
                return card;
            }
            else
            {
                return null;
            }
        }
    }
}
