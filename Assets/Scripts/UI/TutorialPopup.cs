using UnityEngine;

public class TutorialPopup : MonoBehaviour {
    void Update() {
        if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0) {
            Destroy(transform.gameObject);
        }
    }
}
