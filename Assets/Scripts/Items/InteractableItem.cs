using UnityEngine;

namespace Items {
    public class InteractableItem : MonoBehaviour {
        [SerializeField] private Collider targetCollider;

        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Sprite onTriggerSprite;
        private Sprite _oldSprite;

        public void Start() {
            _oldSprite = spriteRenderer.sprite;
        }

        public void OnTriggerEnter(Collider other) {
            if (other != targetCollider) {
                return;
            }

            spriteRenderer.sprite = onTriggerSprite;
        }

        public void OnTriggerExit(Collider other) {
            spriteRenderer.sprite = _oldSprite;
        }

        public void DestroyItem() {
            Destroy(transform.parent.gameObject);
        }
    }
}
