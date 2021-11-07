using UnityEngine;

namespace Camera {
    public class CameraFollow : MonoBehaviour {
        [SerializeField] private Transform target;
        [SerializeField] private Transform leftBoundary;
        [SerializeField] private Transform rightBoundary;

        [SerializeField] private float smoothSpeed = 0.125f;
        private Vector3 _offset;

        public void Start() {
            var targetPosition = target.position;
            var position = transform.position;

            _offset = new Vector3(position.x - targetPosition.x, position.y - targetPosition.y, position.z);
        }

        public void FixedUpdate() {
            var desiredPosition = target.position + _offset;
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = new Vector3(Mathf.Clamp(smoothedPosition.x,
                    leftBoundary.position.x + 8.91f,
                    rightBoundary.position.x - 8.91f),
                smoothedPosition.y,
                transform.position.z);
        }
    }
}
