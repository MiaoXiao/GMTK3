using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float _maxCameraDistanceFromPlayer = 25f;

    [SerializeField]
    private float _smoothTime = 1f;

    private Vector3 velocity = Vector3.zero;
    private float _cameraZ;

    private Camera _camera;

    private void Awake()
    {
        _cameraZ = transform.position.z;
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldMousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 finalCameraPos = Vector2.ClampMagnitude(worldMousePos - GameManager.Instance.Player.transform.position, _maxCameraDistanceFromPlayer);
        Vector3 smoothedCameraPos = Vector3.SmoothDamp(transform.position, finalCameraPos, ref velocity, _smoothTime);
        smoothedCameraPos.z = _cameraZ;
        transform.position = smoothedCameraPos;
    }
}
