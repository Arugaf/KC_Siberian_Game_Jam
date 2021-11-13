using System.Collections.Generic;
using Items;
using UnityEngine;

namespace Player {
    public class PlayerInventory : MonoBehaviour {
        [SerializeField] private int capacity = 5;
        
        [SerializeField] List<Item> _inventory = new List<Item>();

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

        public List<int> GetItemsID() {
            var ids = new List<int>();
            for(var i=0;i < _inventory.Count; i++) {
                ids.Add(_inventory[i].id);
            }
            return ids;
        }

        public bool IsFull() {
            return _inventory.Count >= capacity;
        }

        public void Reset() {
            _inventory = new List<Item>();
        }
    }
}
