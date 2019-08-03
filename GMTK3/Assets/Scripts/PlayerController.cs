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
    
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        if (Input.GetKey("a")){
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - Time.deltaTime * speed, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        if (Input.GetKey("d")){
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + Time.deltaTime * speed, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        if (Input.GetKeyDown("w") && IsGrounded()){
            rb.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded(){
        if(rb.velocity.y < 0.1){
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
