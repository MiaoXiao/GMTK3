using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableBlock : MonoBehaviour
{

    [SerializeField]
    private bool IsStatic;
    [SerializeField]
    private Sprite HoverEmpty;
    [SerializeField]
    private Sprite ClickEmpty;
    [SerializeField]
    private Sprite HoverClick;
    [SerializeField]
    private Sprite ClickClick;

    void Awake(){

    }

    // Update is called once per frame
    void Update(){

    }

    void OnMouseDown(){
        if (IsStatic == true){
            return;
        }
        else{
            GameObject.Destroy(this.gameObject);
        }
    }

}
