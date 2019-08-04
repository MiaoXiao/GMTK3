using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableBlock : MonoBehaviour
{

    [SerializeField]
    private bool IsStatic;

    //HoverEmpty is when you hover over the block when it it just a white background
    //HoverClicked is when you hover over the block when the block is revealed
    //Clicked is when the player activates the block
    //Empty is the initial stage or when the player deactivates the block
    [SerializeField]
    private Sprite HoverEmpty;
    [SerializeField]
    private Sprite Clicked;
    [SerializeField]
    private Sprite HoverClicked;
    [SerializeField]
    private Sprite Empty;

    private bool IsClicked;

    SpriteRenderer spriteRen;

    void Awake(){
        IsClicked = false;
        spriteRen = gameObject.GetComponent<SpriteRenderer>();
        spriteRen.sprite = Empty;
    }

    // Update is called once per frame
    void Update(){
        
    }

    void OnMouseDown(){
        if (IsStatic == true){
            return;
        }
        else{
            if (spriteRen.sprite == HoverEmpty)
            {
                Debug.Log("Clicked: Change to clicked");
                spriteRen.sprite = Clicked;
            }
            else if (spriteRen.sprite = HoverClicked){
                Debug.Log("Clicked: Change to empty");
                spriteRen.sprite = Empty;
            }
            else{
                return;
            }
        }
    }

    void OnMouseEnter(){
        if (IsStatic == true){
            return;
        }
        else{
            if (spriteRen.sprite == Clicked)
            {
                Debug.Log("Hover: Change to click consequences");
                spriteRen.sprite = HoverClicked;
            }
            else if (spriteRen.sprite == Empty)
            {
                Debug.Log("Hover: Change to before click");
                spriteRen.sprite = HoverEmpty;
            }
            else{
                return;
            }
        }
    }

    void OnMouseExit(){
        if (IsStatic == true){
            return;
        }
        else{
            if (spriteRen.sprite == HoverClicked)
            {
                Debug.Log("Hover: Change it back to click");
                spriteRen.sprite = Clicked;
            }
            else if (spriteRen.sprite == HoverEmpty)
            {
                Debug.Log("Hover: Change it back to empty");
                spriteRen.sprite = Empty;
            }
            else{
                return;
            }
        }
    }
}
