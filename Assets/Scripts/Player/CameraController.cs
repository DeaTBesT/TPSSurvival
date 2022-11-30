using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform targetFollow;

    [Header("Stats")]
    [SerializeField] private float smooth;
    [SerializeField] private float speedRotation;

    [SerializeField] private float minZoom;
    [SerializeField] private float maxZoom;

    [SerializeField] private Vector3 cameraOffset;

    private float scrollValue;

    private const string mouseScroll = "Mouse ScrollWheel";

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Follow();
        Rotate();
        ZoomIn();
    }

    private void Follow()
    {
        transform.position = Vector3.Lerp(transform.position, targetFollow.position + cameraOffset, smooth * Time.deltaTime);
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * speedRotation * -1);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up * speedRotation);
        }
    }

    private void ZoomIn()
    {
        scrollValue += Input.GetAxis(mouseScroll);
        scrollValue = Mathf.Clamp(scrollValue, maxZoom, minZoom);

        _camera.transform.localPosition = new Vector3(_camera.transform.localPosition.x, -scrollValue, scrollValue);
    }
}
