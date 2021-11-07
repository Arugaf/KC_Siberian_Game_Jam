using UnityEngine;

namespace Player {
    public class PlayerScaler : MonoBehaviour {
        [SerializeField] private Transform player;
        private float _playerScaleX;
        private float _playerScaleY;
        private float _playerScaleZ;

        [SerializeField] private Transform nearBoundary;
        [SerializeField] private Transform furtherBoundary;

        [Range(0.001f, 1f)] [SerializeField] private float scaleFactor = 0.5f;

        public void Start() {
            var playerScale = player.localScale;
            _playerScaleZ = playerScale.z;

            var uniformDistributionValue =
                GetUniformDistribution(furtherBoundary.position.z, nearBoundary.position.z, player.position.z);

            var playerScaleFactors =
                Vector2.Lerp(new Vector2(scaleFactor, scaleFactor), Vector2.one, uniformDistributionValue);

            _playerScaleX = playerScaleFactors.x / playerScale.x;
            _playerScaleY = playerScaleFactors.y / playerScale.y;
        }

        public void Update() {
            var uniformDistributionValue =
                GetUniformDistribution(furtherBoundary.position.z, nearBoundary.position.z, player.position.z);

            player.localScale = Vector3.Lerp(
                new Vector3(scaleFactor / _playerScaleX, scaleFactor / _playerScaleY, _playerScaleZ),
                new Vector3(1f / _playerScaleX, 1f / _playerScaleY, _playerScaleZ),
                uniformDistributionValue);
        }

        private static float GetUniformDistribution(float a, float b, float x) {
            return (x - a) / (b - a);
        }
    }
}
