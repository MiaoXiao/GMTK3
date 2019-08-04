using UnityEngine;

public class CreatureObject : MonoBehaviour
{
    GameObject player;

    private bool InCreature;

    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update(){
        if (Input.GetKeyDown("e") && InCreature)
        {
            player.transform.position = new Vector3(0,0,0);
            GameManager.Instance.CollectCreature(this);
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        InCreature = true;
    }

    void OnTriggerExit2D(Collider2D other){
        InCreature = false;
    }
}
