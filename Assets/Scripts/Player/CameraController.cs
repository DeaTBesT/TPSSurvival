using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineCameraOffset cameraOffset;

    [SerializeField] private float smooth; 
    [SerializeField] private float minZoom;
    [SerializeField] private float maxZoom;

    private float scrollValue;

    private const string mouseScroll = "Mouse ScrollWheel";

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        scrollValue = cameraOffset.m_Offset.z;
    }

    private void Update()
    {
        ZoomIn();
    }

    private void ZoomIn()
    {
        scrollValue += Input.GetAxis(mouseScroll);
        scrollValue = Mathf.Clamp(scrollValue, maxZoom, minZoom);

        Vector3 newOffset = new Vector3(cameraOffset.m_Offset.x, cameraOffset.m_Offset.y, scrollValue);

        cameraOffset.m_Offset = Vector3.Lerp(cameraOffset.m_Offset, newOffset, smooth * Time.deltaTime);
    }
}
