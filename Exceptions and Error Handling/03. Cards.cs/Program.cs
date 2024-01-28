using System;
using System.Collections.Generic;

namespace _03._Cards.cs
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Card> deck = new List<Card>();

			string[] cards = Console.ReadLine().Split(", ");

			Card card;

			foreach (var c in cards)
			{
				string[] cardInfo = c.Split(" ", StringSplitOptions.RemoveEmptyEntries);
				try
				{
					card = new Card(cardInfo[0].ToString(), cardInfo[1].ToString());
					deck.Add(card);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}

			foreach (var c in deck)
			{
				Console.Write(c.ToString() + " ");
			}
			Console.WriteLine();
		}
	}

	public class Card
	{
		private HashSet<string> validFaces = new HashSet<string>()
		{
			"2", "3", "4", "5", "6", "7", "8",
			"9", "10", "J", "Q", "K", "A"
		};

		private HashSet<string> validSuits = new HashSet<string>()
		{
			"D", "C", "H", "S"
		};

		public Card(string face, string suit)
		{
			if (validFaces.Contains(face))
			{
				Face = face;
			}
			else
			{
				throw new ArgumentException("Invalid card!");
			}
			if (validSuits.Contains(suit))
			{
				Suit = suit;
			}
			else
			{
				throw new ArgumentException("Invalid card!");
			}
		}

		public string Face { get; private set; }
		public string Suit { get; private set; }

		public override string ToString()
		{
			switch (Suit)
			{
				case "S":
					Suit = "\u2660";
					break;
				case "H":
					Suit = "\u2665";
					break;
				case "D":
					Suit = "\u2666";
					break;
				case "C":
					Suit = "\u2663";
					break;
			}

			return $"[{Face}{Suit}]";
		}
	}
}

