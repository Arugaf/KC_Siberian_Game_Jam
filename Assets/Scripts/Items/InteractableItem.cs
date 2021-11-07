using UnityEngine;

namespace Items {
    public class InteractableItem : MonoBehaviour {
        [SerializeField] private Collider targetCollider;

        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Sprite onTriggerSprite;
        private Sprite _oldSprite;

        [SerializeField] private RectTransform thoughtsObject;

        public void Start() {
            _oldSprite = spriteRenderer.sprite;
        }

        public void OnTriggerEnter(Collider other) {
            if (other != targetCollider) {
                return;
            }

            thoughtsObject.gameObject.SetActive(true);
            spriteRenderer.sprite = onTriggerSprite;
        }

        public void OnTriggerExit(Collider other) {
            thoughtsObject.gameObject.SetActive(false);
            spriteRenderer.sprite = _oldSprite;
        }

        public void DestroyItem() {
            thoughtsObject.gameObject.SetActive(false);
            Destroy(transform.parent.gameObject);
        }
    }
}
