using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CardModel : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] faces;
    public Sprite cardBack;

    public int cardIndex;

    public void ToggleFace(bool showFace){
        if(showFace){
            // Show front side
            spriteRenderer.sprite = faces[cardIndex];
        }
        else {
            //Show backside
            spriteRenderer.sprite = cardBack;
        }
    }

    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
