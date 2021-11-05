using UnityEngine;

public class PlayerMovementController : MonoBehaviour {
    [SerializeField] private Rigidbody playerRigidbody;

    private float _verticalMove;
    private float _horizontalMove;

    [Range(0.1f, 1f)] [SerializeField] private float verticalVelocityMultiplier = 0.1f;
    [Range(0.1f, 1f)] [SerializeField] private float horizontalVelocityMultiplier = 0.1f;
    private const float KVelocityMultiplier = 1000f;


    private Vector3 _playerVelocity;
    private Vector3 _velocity = Vector3.zero;
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;

    public void Start() {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    public void Update() {
        _verticalMove = Input.GetAxisRaw("Vertical");
        _horizontalMove = Input.GetAxisRaw("Horizontal");
    }

    public void FixedUpdate() {
        var currentPlayerVelocity = playerRigidbody.velocity;

        _playerVelocity = new Vector3(
            _horizontalMove * Time.fixedDeltaTime * horizontalVelocityMultiplier * KVelocityMultiplier,
            currentPlayerVelocity.y,
            _verticalMove * Time.fixedDeltaTime * verticalVelocityMultiplier * KVelocityMultiplier);

        playerRigidbody.velocity =
            Vector3.SmoothDamp(currentPlayerVelocity, _playerVelocity, ref _velocity, movementSmoothing);
    }
    
    // todo: camera
    // todo: scale
    // todo: inventory
    // todo: items
}
