using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField]
    private float _distanceToFullFade = 100f;

    [SerializeField]
    private float _distanceToStartFade = 1000f;

    [SerializeField]
    private Color _closestToCreature = Color.black;

    [SerializeField]
    private Color _furthestFromCreature = Color.white;

    private SpriteRenderer _background;

    private void Awake()
    {
        if (_distanceToStartFade < _distanceToFullFade) Debug.LogError("DistanceToStartFade should be greater than distanceToFullFade. Otherwise problems will occur.");
        _background = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float shortestDistance = GameManager.Instance.GetDistanceToClosestCreature();
        if (shortestDistance > _distanceToStartFade) _background.color = _furthestFromCreature;
        else if (shortestDistance < _distanceToFullFade) _background.color = _closestToCreature;
        else
        {
            float percentage = (shortestDistance - _distanceToFullFade) / (_distanceToStartFade - _distanceToFullFade);
            _background.color = Color.Lerp(_furthestFromCreature, _closestToCreature, percentage);
        }
    }
}
