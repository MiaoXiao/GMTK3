using UnityEngine;

public class CreatureObject : MonoBehaviour
{
    GameObject player;
    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Entered trigger");
        if (Input.GetKeyDown("e") /*&& (other.gameObject.tag == "Player")*/ ){
            Debug.Log("Pressed e");
            player.transform.position.Set(0, 0, 0);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        Debug.Log("Exited");
    }

    public void OnMouseDown()
    {
        GameManager.Instance.CollectCreature(this);
        gameObject.SetActive(false);
    }
}
