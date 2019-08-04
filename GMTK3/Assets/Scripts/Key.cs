using UnityEngine;

public class Key : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.Instance.numberOfKeys++;
            gameObject.SetActive(false);
        }
    }
}
