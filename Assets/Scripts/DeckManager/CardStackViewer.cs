using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardStack))]
public class CardStackViewer : MonoBehaviour
{
    CardStack _deck;
    List<int> fetchedCards;
    int lastCount;

    public Vector3 start;
    public GameObject cardPrefab;
    public float cardOffset;

    void Start()
    {
        fetchedCards = new List<int>();
        _deck = GetComponent<CardStack>();
        ShowCards();
        lastCount = _deck.CardCount;
    }

    void Update()
    {
        if (lastCount != _deck.CardCount)
        {
            lastCount = _deck.CardCount;
            ShowCards();
        }
    }
    void ShowCards()
    {
        int cardCount = 0;
        if (_deck.HasCards)
        {
            foreach (int i in _deck.GetCards())
            {
                float co = cardOffset * cardCount;
                Vector3 temp = start + new Vector3(co, 0f);
                AddCards(temp, i, cardCount);

                cardCount++;
            }
        }
    }

    void AddCards(Vector3 position, int cardIndex, int positionIndex)
    {
        if (fetchedCards.Contains(cardIndex))
        {
            return;
        }
        
        GameObject cardCopy = (GameObject)Instantiate(cardPrefab);
        cardCopy.transform.position = position;

        CardModel cardModel = cardCopy.GetComponent<CardModel>();
        cardModel.cardIndex = cardIndex;
        cardModel.ToggleFace(true);

        SpriteRenderer spriteRenderer = cardCopy.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = positionIndex;

        fetchedCards.Add(cardIndex);
    }
}
