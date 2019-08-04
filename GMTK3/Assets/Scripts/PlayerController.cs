using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float jumpVelocity;

    [SerializeField]
    public float speed;
    private float distToGround;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer spriteRen;
    
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRen = GetComponent<SpriteRenderer>();
    }

    void Update(){
        anim.SetInteger("State", 0);
        if (Input.GetKey("a")){
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - Time.deltaTime * speed, gameObject.transform.position.y, gameObject.transform.position.z);
            spriteRen.flipX = true;
            anim.SetInteger("State", 1);
        }
        if (Input.GetKey("d")){
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + Time.deltaTime * speed, gameObject.transform.position.y, gameObject.transform.position.z);
            spriteRen.flipX = false;
            anim.SetInteger("State", 1);
        }
        if (Input.GetKeyDown("w") && IsGrounded()){
            anim.SetInteger("State", 2);
            rb.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded(){
        if (rb.velocity.y < 0.1){
            if (rb.velocity.y > 0.1 * -1){
                return true;
            }
            else{
                return false;
            }
        }
        else{
            return false;
        }
    }

}
