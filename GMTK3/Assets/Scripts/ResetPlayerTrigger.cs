using UnityEngine;

public class ResetPlayerTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.Instance.TeleportToLastCheckpoint();
        }
    }
}
