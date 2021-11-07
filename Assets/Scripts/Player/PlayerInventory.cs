using System.Collections.Generic;
using Items;
using UnityEngine;

namespace Player {
    public class PlayerInventory : MonoBehaviour {
        [SerializeField] private int capacity = 5;
        
        private List<Item> _inventory = new List<Item>();

        public bool AddItem(string itemName, Item item) {
            if (_inventory.Count >= capacity) {
                return false;
            }
            
            _inventory.Add(item);
            Debug.Log("Added item: " + item.itemName + ' ' + item.id);
            return true;
        }

        public List<Item> GetItems() {
            return _inventory;
        }

        public bool IsFull() {
            return _inventory.Count >= capacity;
        }

        public void Reset() {
            _inventory = new List<Item>();
        }
    }
}
