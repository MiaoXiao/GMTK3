using UnityEngine;

public class CreatureObject : MonoBehaviour
{
    public void OnMouseDown()
    {
        GameManager.Instance.CollectCreature(this);
        gameObject.SetActive(false);
    }
}
