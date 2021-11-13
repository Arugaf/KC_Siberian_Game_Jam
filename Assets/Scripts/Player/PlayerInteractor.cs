using Items;
using UnityEngine;

namespace Player {
    public class PlayerInteractor : MonoBehaviour {
        private InteractableItem _item;
        [SerializeField] PlayerInventory _inventory;
        [SerializeField] InventoryUI _inventoryUI;

        [SerializeField] private RectTransform courtTime;

        public void Start() {
            if (_inventory == null) {
                Debug.Log("oh no");
            }
        }

        public void Update() {
            if (_inventory.IsFull()) {
                courtTime.gameObject.SetActive(true);
            }
            
            if (!Input.GetKeyDown("e") || !_item) {
                return;
            }

            var item = _item.GetComponent<Item>();
            if (_inventory.AddItem(item.itemName, item)) {
                _inventoryUI.ChangeItem(item.itemSprite);
                _item.DestroyItem();
            }
        }

        public void OnTriggerEnter(Collider other) {
            _item = other.GetComponent<InteractableItem>();
        }

        public void OnTriggerExit(Collider other) {
            _item = null;
        }
    }
}
