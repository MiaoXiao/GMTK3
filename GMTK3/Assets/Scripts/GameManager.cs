using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private List<CreatureObject> _uncollectedCreatures = new List<CreatureObject>();

    public Checkpoint ActiveCheckpoint = null;

    private PlayerController _player;

    private void Awake()
    {
        _uncollectedCreatures = new List<CreatureObject>(FindObjectsOfType<CreatureObject>());
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
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

    }

    public void TeleportToLastCheckpoint()
    {
        if (ActiveCheckpoint == null)
        {
            _player.transform.position = new Vector2(0, 0);
        }
        else
        {
            _player.transform.position = ActiveCheckpoint.transform.position;
        }
    }

    public float GetDistanceToClosestCreature()
    {
        if (_uncollectedCreatures.Count == 0) return -1f;

        float shortest = Mathf.NegativeInfinity;
        for(int i = 0; i < _uncollectedCreatures.Count; ++i)
        {
            float currentDist = Vector2.Distance(_uncollectedCreatures[i].transform.position, _player.transform.position);
            if (currentDist < shortest)
            {
                shortest = currentDist;
            }
        }
        return shortest;
    }
}
