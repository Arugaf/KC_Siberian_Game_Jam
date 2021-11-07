using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour
{
    [SerializeField] GameObject neutralImage;
    [SerializeField] GameObject happyImage;
    [SerializeField] GameObject sadImage;

    public Emotion currentEmotion {set; get;}

    public void ChangeEmotion(Emotion _e) {
        switch (_e) {
            case Emotion.Neutral:
            break;
            case Emotion.Happy:
            break;
            default:
                Debug.LogWarning("Unknown emotion - " + _e);
            break; 
        }
    }
}
