using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableBlock : MonoBehaviour
{

    [SerializeField]
    private bool IsStatic;

    [SerializeField]
    private bool SetActiveOnStart;

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

    [SerializeField]
    List<Collider2D> colliderList;

    [Header("Audio")]

    [SerializeField]
    private AudioClip _hoverOver;
    [SerializeField]
    private AudioClip _clicked;

    private AudioSource _audioSource;

    void Awake(){
        IsClicked = false;
        spriteRen = gameObject.GetComponent<SpriteRenderer>();
        spriteRen.sprite = Empty;

        if(SetActiveOnStart == true){
            SetActive();
        }

        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){
        
    }

    void OnMouseDown(){
        if (IsStatic == true){
            return;
        }
        else{
            if (spriteRen.sprite == HoverEmpty || spriteRen.sprite == Empty)
            {
                _audioSource.PlayOneShot(_clicked);
                SetActive();
            }
            else if (spriteRen.sprite == HoverClicked || spriteRen.sprite == Clicked){
                _audioSource.PlayOneShot(_clicked);
                SetInactive();
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
                _audioSource.PlayOneShot(_hoverOver);
                Debug.Log("Hover: Change to click consequences");
                spriteRen.sprite = HoverClicked;
            }
            else if (spriteRen.sprite == Empty)
            {
                _audioSource.PlayOneShot(_hoverOver);
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

    void OnTriggerEnter2D(Collider2D other){
        IsStatic = true;
    }
    void OnTriggerExit2D(Collider2D other){
        IsStatic = false;
    }

    void SetActive(){
        Debug.Log("Clicked: Change to clicked");
        spriteRen.sprite = Clicked;
        foreach (Collider2D i in colliderList){
            i.isTrigger = false;
        }
    }

    void SetInactive(){
        Debug.Log("Clicked: Change to empty");
        spriteRen.sprite = Empty;
        foreach (Collider2D i in colliderList){
            i.isTrigger = true;
        }
    }
}
