using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Court : MonoBehaviour
{
    G g;
    // Start is called before the first frame update
    void Start()
    {
        g = FindObjectOfType<G>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeState()
    {
        g.currState = GameState.Ending;
        g.sceneController.SwitchScene(g.currState);
    }
}
