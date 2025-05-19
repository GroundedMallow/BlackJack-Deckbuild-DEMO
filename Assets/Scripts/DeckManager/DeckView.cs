using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Deck))]
public class DeckView : MonoBehaviour
{
    Deck _deck;
    public Vector3 start;
    public float cardOffset;
    public GameObject cardPrefab;

    void Start
    {
        _deck = GetComponent<Deck>();
        ShowCards();
    }
    
    void ShowCards() {
    foreach (int i in DeckView.GetCards()) {
        float co = cardOffset * cardCount;

        GameObject cardCopy = (GameObject)Instantiate(cardPrefab);
        Vector3 temp = start + new Vector3(co, 0f);
        cardCopy.transform.position = temp;

        cardCount++;
        }
    }
}
