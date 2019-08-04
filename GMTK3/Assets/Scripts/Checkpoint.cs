using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private Vector3 SpawnOffset = new Vector3(0, 1, 0);

    public Vector3 GetCheckpointPos()
    {
        return transform.position + SpawnOffset;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //@@@ Audio queue
        GameManager.Instance.ActiveCheckpoint = this;

        //@@@ Animation?
        gameObject.GetComponent<Animator>().SetInteger("State", 1);
    }
}
