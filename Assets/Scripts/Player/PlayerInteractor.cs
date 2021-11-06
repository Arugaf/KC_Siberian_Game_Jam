using System;
using Items;
using UnityEngine;

namespace Player {
    public class PlayerInteractor : MonoBehaviour {
        private InteractableItem _item = null;
        public void Update() {
            if (Input.GetKeyDown("e") && _item) {
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
