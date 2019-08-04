using UnityEngine;

public class CreatureObject : MonoBehaviour
{
    GameObject player;

    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player") {
            GameManager.Instance.CollectCreature(this);
            gameObject.SetActive(false);
        }
    }

}
