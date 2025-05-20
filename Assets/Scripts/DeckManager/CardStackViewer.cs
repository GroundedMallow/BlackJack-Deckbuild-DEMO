using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardStack))]
public class CardStackViewer : MonoBehaviour
{
    CardStack _deck;
    Dictionary<int, GameObject> fetchedCards; //int kvl
    int lastCount;

    public Vector3 start;
    public GameObject cardPrefab;
    public float cardOffset;
    public bool faceUp = false;

    void Start()
    {
        fetchedCards = new Dictionary<int, GameObject>();
        _deck = GetComponent<CardStack>();
        ShowCards();
        lastCount = _deck.CardCount;

        _deck.CardRemoved += _deck_CardRemoved;
    }
    void _deck_CardRemoved(object sender, CardRemovedEventArgs e)
    {
        if (fetchedCards.ContainsKey(e.CardIndex))
        {
            Destroy(fetchedCards[e.CardIndex]); //removes deck from card, adds to hand
            fetchedCards.Remove(e.CardIndex);
        }
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
        if (fetchedCards.ContainsKey(cardIndex))
        {
            return;
        }

        GameObject cardCopy = (GameObject)Instantiate(cardPrefab);
        cardCopy.transform.position = position;

        CardModel cardModel = cardCopy.GetComponent<CardModel>();
        cardModel.cardIndex = cardIndex;
        cardModel.ToggleFace(faceUp);

        SpriteRenderer spriteRenderer = cardCopy.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = positionIndex;

        fetchedCards.Add(cardIndex, cardCopy);
    }
}
