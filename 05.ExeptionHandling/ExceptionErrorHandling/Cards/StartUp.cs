using System;
using System.Collections.Generic;

namespace Cards
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            List<Card> cards = new List<Card>();
            for (int i = 0; i < input.Length; i++)
            {
                string[] cardData = input[i].Split();
                string face = cardData[0];
                string suit = cardData[1];
                try
                {
                    Card card = new Card(face, suit);
                    cards.Add(card);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(string.Join(" ",cards));
        }

        public class Card
        {
            HashSet<string> faces = new HashSet<string>()
        {
            "2","3","4","5","6","7","8","9","10","J","Q","K","A"
        };

            Dictionary<string, string> suits = new Dictionary<string, string>()
        {
            {"S", "\u2660" },
            {"H", "\u2665" },
            {"D", "\u2666" },
            {"C", "\u2663" },
        };

            private string face;
            private string suit;

            public Card(string face, string suit)
            {
                Face = face;
                Suit = suit;
            }

            public string Face
            {
                get => face;
                private set
                {
                    if (!faces.Contains(value))
                    {
                        throw new Exception("Invalid card!");
                    }

                    face = value;
                }
            }
            public string Suit
            {
                get => suit;
                private set
                {
                    if (!suits.ContainsKey(value))
                    {
                        throw new Exception("Invalid card!");
                    }

                    suit = suits[value];
                }
            }

            public override string ToString()
            {
                return $"[{Face}{Suit}]";
            }

        }
    }
}
