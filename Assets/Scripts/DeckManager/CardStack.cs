using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CardStack : MonoBehaviour
{
    List<int> deck;
    public bool isGameDeck;

    public bool HasCards
    {
        get { return deck != null && deck.Count > 0; }
    }

    public event CardRemovedDelegate CardRemoved;
    public int CardCount
    {
        get
        {
            if (deck == null)
            {
                return 0;
            }
            else
            {
                return deck.Count;
            }
        }
    }
    public IEnumerable<int> GetCards()
    {
        foreach (int i in deck)
        {
            yield return i;
        }
    }

    public int Pop()
    {
        int temp = deck[0];
        deck.RemoveAt(0);

        if (CardRemoved != null)
        {
            CardRemoved(this, new CardRemovedEventArgs(temp));
        }
        return temp;
    }
    public void Push(int card)
    {
        deck.Add(card);
    }
    
    void Start()
    {
        deck = new List<int>(); //new deck
        if (isGameDeck)
        {
            CreateDeck();
        }
    }

    public int HandValue()
    {
        int total;
        foreach (int card in GetCards())
        {
            int cardRank = card % 13;
            if (cardRank > 8 && cardRank < 12)
            {
                cardRank += 2;
            }
            elseif(cardRank >= && cardRank < 12)
            {
                cardRank = 10;
            }
            else {
                cardRank = 11; //ace 1 or 11
            }
        }
    }
    public void CreateDeck()
    {
        for (int i = 0; i < 52; i++)
        {
            //Unshuffled
            deck.Add(i);
        }

        int n = deck.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            int temp = deck[k];
            deck[k] = deck[n];
            deck[n] = temp;
        }
    }
}
