using System;
using System.Collections.Generic;

class Program {
    public static void Main() {
        CheckCards();
    }

    private static Card CreateCard(string face, string suit) {
        return new Card(face, suit);
    }

    private static void CheckCards() {
        string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
        List<string> cards = new List<string>();

        foreach (string cardInput in input) {
            try{
                string[] cardParts = cardInput.Split();
                if (cardParts.Length != 2) throw new ArgumentException("Invalid card!");

                Card card = CreateCard(cardParts[0], cardParts[1]);
                cards.Add(card.ToString());
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        }
        
        Console.WriteLine(string.Join(" ", cards));
    }
}

class Card {
    private static readonly HashSet<string> ValidFaces = new() {
        "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A",
    };

    private static readonly Dictionary<string, string> SuitSymbols = new() {
        { "S", "\u2660" },
        { "H", "\u2665" },
        { "D", "\u2666" },
        { "C", "\u2663" },
    };
        
    public string Face { get; }
    public string Suit { get; }

    public Card(string face, string suit) {
        if (!ValidFaces.Contains(face) || !SuitSymbols.ContainsKey(suit)){
            throw new ArgumentException("Invalid card!");
        }
            
        Face = face;
        Suit = SuitSymbols[suit];
    }

    public override string ToString() => $"[{Face}{Suit}]";
}



