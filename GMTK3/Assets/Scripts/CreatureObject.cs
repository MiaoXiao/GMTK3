using UnityEngine;

public class CreatureObject : MonoBehaviour
{
    GameObject player;
    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void OnMouseDown()
    {
        GameManager.Instance.CollectCreature(this);
        gameObject.SetActive(false);
    }
}
