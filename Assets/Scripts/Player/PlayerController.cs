using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(PlayerAnimator))]
public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float smooth;
    private float speed;

    [Header("Rotation")]
    [SerializeField] private Transform body;
    [SerializeField] private float bodySpeedRotation;

    private PlayerAnimator playerAnimator;
    private Rigidbody _rigidBody;
    private Camera _camera;

    private const string horizontalInput = "Horizontal";
    private const string verticalInput = "Vertical";

    private bool isMove;
    private float state;

    private void Start()
    {
        _camera = Camera.main;
        _rigidBody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<PlayerAnimator>();

        speed = walkSpeed;
    }

    private void Update()
    {
        IsRun(Input.GetKey(KeyCode.LeftShift));

        playerAnimator.SetState(state);
    }

    private void FixedUpdate()
    {
        Move();

        if (isMove)
        {
            BodyRotation();
        }
    }

    private void Move()
    {
        float moveX = Input.GetAxis(horizontalInput);
        float moveZ = Input.GetAxis(verticalInput);

        isMove = Mathf.Abs(moveX) + Mathf.Abs(moveZ) > 0;

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        _rigidBody.MovePosition(transform.position + move * speed * Time.deltaTime);

        playerAnimator.AnimMove(moveX, moveZ);
    }

    private void IsRun(bool _value)
    {
        speed = Mathf.LerpUnclamped(speed, _value ? runSpeed : walkSpeed, smooth * Time.deltaTime);
        state = Mathf.LerpUnclamped(state, _value ? 1 : 0, smooth * Time.deltaTime);
    }

    private void BodyRotation()
    {
        Vector3 viewDirection = transform.position - new Vector3(_camera.transform.position.x, transform.position.y, _camera.transform.position.z);

        body.forward = Vector3.Slerp(body.forward, viewDirection.normalized, Time.deltaTime * bodySpeedRotation);
    }
}
