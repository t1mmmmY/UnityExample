using UnityEngine;
using System.Collections;

public class RotateBySwipe : MonoBehaviour 
{
    [SerializeField] Transform target;
    [SerializeField] float rotationTime = 1.0f;
    bool moving = false;
    bool isGameStarted = false;

    void OnEnable()
    {
        InputController.onSwipeHorizontal += RotateHorizontal;
        StartAnimation.onEndAnimation += OnStartGame;
    }

    void OnDisable()
    {
        InputController.onSwipeHorizontal -= RotateHorizontal;
        StartAnimation.onEndAnimation -= OnStartGame;
    }

    void OnStartGame()
    {
        isGameStarted = true;
    }

    void RotateHorizontal(float horizontalInput)
    {
        if (moving || !isGameStarted)
        {
            return;
        }

        moving = true;

        int angle = horizontalInput > 0 ? 90 : -90;

        Hashtable hash = new Hashtable();
        hash.Add("amount", Vector3.up * angle);
        hash.Add("time", rotationTime);
        hash.Add("easytype", iTween.EaseType.easeInBack);
        hash.Add("oncomplete", "OnFinishRotating");
        hash.Add("oncompletetarget", this.gameObject);

        iTween.RotateAdd(target.gameObject, hash);
    }

    void OnFinishRotating()
    {
        moving = false;
    }
}
