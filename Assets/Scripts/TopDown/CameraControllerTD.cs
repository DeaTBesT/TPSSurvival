using UnityEngine;

public class CameraControllerTD : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float speedRotation;

    [SerializeField] private bool isUseMouse2Move;

    private const string _horizontalMove = "Horizontal";
    private const string _verticalMove = "Vertical";

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Rotate();
        KeyboardMove();
        //MouseMove();
    }

    private void KeyboardMove()
    {
        float moveX = Input.GetAxis(_horizontalMove);
        float moveZ = Input.GetAxis(_verticalMove);

        Vector3 move = new Vector3(moveX, transform.position.y, moveZ);

        transform.Translate(move * speed * Time.deltaTime);
    }

    //private void MouseMove()
    //{

    //}

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
}
