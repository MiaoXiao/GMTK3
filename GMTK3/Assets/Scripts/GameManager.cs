using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private List<CreatureObject> _uncollectedCreatures = new List<CreatureObject>();

    public Checkpoint ActiveCheckpoint = null;

    public int numberOfKeys = 0;

    [HideInInspector]
    public GameObject Player;

    [SerializeField]
    public Sprite nightmareFuel;

    private void Awake()
    {
        _uncollectedCreatures = new List<CreatureObject>(FindObjectsOfType<CreatureObject>());
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void CollectCreature(CreatureObject c)
    {
        if (_uncollectedCreatures.Contains(c))
        {
            _uncollectedCreatures.Remove(c);

            //Teleport player back to start
            ActiveCheckpoint = null;
            TeleportToLastCheckpoint();
        }

        if (_uncollectedCreatures.Count == 0)
        {
            Win();
        }
    }

    public void Win()
    {
        Player.transform.position = new Vector3(-140, -57, 0);
        Destroy(Player.GetComponent<Animator>());
        Debug.Log(nightmareFuel);
        Player.GetComponent<SpriteRenderer>().sprite = nightmareFuel;
        Player.transform.localScale = new Vector3(10, 10, 1);
    }

    public void TeleportToLastCheckpoint()
    {
        if (ActiveCheckpoint == null)
        {
            Player.transform.position = new Vector2(0, 0);
        }
        else
        {
            Player.transform.position = ActiveCheckpoint.transform.position;
        }
        Camera.main.transform.position = Player.transform.position;
    }

    public float GetDistanceToClosestCreature()
    {
        if (_uncollectedCreatures.Count == 0) return -1f;

        float shortest = Mathf.Infinity;
        for(int i = 0; i < _uncollectedCreatures.Count; ++i)
        {
            float currentDist = Vector2.Distance(_uncollectedCreatures[i].transform.position, Player.transform.position);
            if (currentDist < shortest)
            {
                shortest = currentDist;
            }
        }
        return shortest;
    }
}
