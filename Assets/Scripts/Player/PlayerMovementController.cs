using UnityEngine;

namespace Player {
    public class PlayerMovementController : MonoBehaviour {
        [SerializeField] private Animator animator;
        
        [SerializeField] private Rigidbody playerRigidbody;
        private SpriteRenderer _spriteRenderer;

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
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Update() {
            _verticalMove = Input.GetAxisRaw("Vertical");
            _horizontalMove = Input.GetAxisRaw("Horizontal");

            {
                if (_horizontalMove > 0) {
                    _spriteRenderer.flipX = false;
                }

                if (_horizontalMove < 0) {
                    _spriteRenderer.flipX = true;
                }
            }
        }

        public void FixedUpdate() {
            if (_verticalMove >= 0.1 || _verticalMove <= -0.1 || _horizontalMove >= 0.1 || _horizontalMove <= -0.1) {
                animator.SetFloat("Speed", 1);
            } else {
                animator.SetFloat("Speed", 0);
            }

            var currentPlayerVelocity = playerRigidbody.velocity;

            _playerVelocity = new Vector3(
                _horizontalMove * Time.fixedDeltaTime * horizontalVelocityMultiplier * KVelocityMultiplier,
                currentPlayerVelocity.y,
                _verticalMove * Time.fixedDeltaTime * verticalVelocityMultiplier * KVelocityMultiplier);

            playerRigidbody.velocity =
                Vector3.SmoothDamp(currentPlayerVelocity, _playerVelocity, ref _velocity, movementSmoothing);
        }
    }
}
