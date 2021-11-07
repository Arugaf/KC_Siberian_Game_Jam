using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitItems(List<int> IDs, List<string> sprites) {
        for(var i = 0; i< IDs.Count; i++)
        {
            var image = Resources.Load<Sprite>(sprites[i]);
            items[i].GetComponent<Image>().sprite = image;
        }
    }

    public void DeleteItem(int index) {
        items[index].SetActive(false);
    }
}
