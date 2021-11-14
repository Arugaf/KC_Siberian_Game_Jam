using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour
{
    [SerializeField] GameObject neutralImage;
    [SerializeField] GameObject happyImage;
    [SerializeField] GameObject sadImage;

    public Emotion currentEmotion {set; get;}
    void ResetImages() {
        neutralImage.SetActive(false);
        happyImage.SetActive(false);
        sadImage.SetActive(false);
    }

    public void ChangeEmotion(Emotion _e) {
        ResetImages();
        switch (_e) {
            case Emotion.Neutral:
                neutralImage.SetActive(true);
            break;
            case Emotion.Happy:
                happyImage.SetActive(true);
            break;
            case Emotion.Sad:
                sadImage.SetActive(true);
            break;
            default:
                Debug.LogWarning("Unknown emotion - " + _e);
            break; 
        }
    }
}
