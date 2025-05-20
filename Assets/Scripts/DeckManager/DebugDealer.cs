using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDealer : MonoBehaviour
{
    public CardStack dealer;
    public CardStack player;

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 256, 28), "Hit me")) //gives card to player
        {
            player.Push(dealer.Pop());
        }
    }
}
