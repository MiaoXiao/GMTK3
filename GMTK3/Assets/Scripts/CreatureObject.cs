using System.Collections;
using UnityEngine;

public class CreatureObject : MonoBehaviour
{
    [SerializeField]
    private float delayF;

    GameObject player;

    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player") {
            StartCoroutine("delay");
            GetComponent<Animator>().SetInteger("State", 1);
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(delayF);
        GameManager.Instance.CollectCreature(this);
        gameObject.SetActive(false);
    }
}
