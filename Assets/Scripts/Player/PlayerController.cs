using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(PlayerAnimator))]
public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float speed;

    [Header("Rotation")]
    [SerializeField] private Transform body;
    [SerializeField] private float bodySpeedRotation;

    private PlayerAnimator playerAnimator;
    private Rigidbody _rigidBody;
    private Camera _camera;

    private const string horizontalInput = "Horizontal";
    private const string verticalInput = "Vertical";

    private Vector3 point;
    private Quaternion rotationTarget;

    private void Start()
    {
        _camera = Camera.main;
        _rigidBody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    private void Update()
    {
        BodyRotation();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float moveX = Input.GetAxis(horizontalInput);
        float moveZ = Input.GetAxis(verticalInput);

        Vector3 move = Vector3.right * moveX + Vector3.forward * moveZ;
        Vector3 moveAnim = transform.right * -moveX + transform.forward * moveZ;

        _rigidBody.MovePosition(transform.position + move * speed * Time.deltaTime);

        playerAnimator.AnimMove(moveAnim.x, moveAnim.z);
    }

    private void BodyRotation()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        Plane planeGround = new Plane(Vector3.up, Vector3.zero);

        if (planeGround.Raycast(ray, out float rayLenght))
        {
            point = ray.GetPoint(rayLenght);

            rotationTarget = Quaternion.LookRotation(new Vector3(point.x - transform.position.x, 0, point.z - transform.position.z));
            _rigidBody.rotation = Quaternion.RotateTowards(transform.rotation, rotationTarget, bodySpeedRotation * Time.deltaTime);
        }
    }
}
