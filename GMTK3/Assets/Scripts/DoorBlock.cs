using UnityEngine;

public class DoorBlock : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && GameManager.Instance.numberOfKeys > 0)
        {
            GameManager.Instance.numberOfKeys--;
            gameObject.SetActive(false);
        }
    }
}
