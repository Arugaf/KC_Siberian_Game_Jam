using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Items {
    public class InventoryUI : MonoBehaviour {
        [SerializeField] List<Image> items;

        int _index = 0;

        public void ChangeItem(Sprite image) {
            items[_index++].sprite = image;
        }
    }
}
