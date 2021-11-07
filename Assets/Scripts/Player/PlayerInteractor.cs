using Items;
using UnityEngine;

namespace Player {
    public class PlayerInteractor : MonoBehaviour {
        private InteractableItem _item;
        private PlayerInventory _inventory;

        private Crime _crimeScene;

        public void Start() {
            _inventory = FindObjectOfType<PlayerInventory>();
            _crimeScene = FindObjectOfType<Crime>();

            if (_inventory == null) {
                Debug.Log("oh no");
            }
        }

        public void Update() {
            if (Input.GetKeyDown("tab") && _inventory.IsFull()) {
                _crimeScene.ChangeState();
            }
            
            if (!Input.GetKeyDown("e") || !_item) {
                return;
            }

            var item = _item.GetComponent<Item>();
            if (_inventory.AddItem(item.itemName, item)) {
                _crimeScene.inventory.ChangeItem(item.itemSprite);
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
