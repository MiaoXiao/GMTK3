using UnityEngine;

public class Creature : MonoBehaviour
{
    public void OnMouseDown()
    {
        GameManager.Instance.CollectCreature(this);
        gameObject.SetActive(false);
    }
}
