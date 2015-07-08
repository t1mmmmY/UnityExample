using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputController : MonoBehaviour 
{
    enum MultiplatformTouchPhase
    {
        Began,
        Stationary,
        Moved,
        Ended
    }

    class MultiplatformTouch
    {
        public Vector2 oldPosition;
        public Vector2 currentPosition;
        public Vector2 deltaPosition
        {
            get
            {
                return currentPosition - oldPosition;
            }
        }

        public MultiplatformTouchPhase phase;

        public Vector2 relativeOldPosition
        {
            get
            {
                return ConvertToRelative(oldPosition);
            }
        }

        public Vector2 relativeCurrentPosition
        {
            get
            {
                return ConvertToRelative(currentPosition);
            }
        }

        public Vector2 relativeDeltaPosition
        {
            get
            {
                return ConvertToRelative(deltaPosition);
            }
        }

        public MultiplatformTouch(Vector2 position)
        {
            oldPosition = position;
            currentPosition = position;
            phase = MultiplatformTouchPhase.Began;
        }

        public void ChangePosition(Vector2 position)
        {
            //oldPosition = currentPosition;
            currentPosition = position;

            if (currentPosition != oldPosition)
            {
                phase = MultiplatformTouchPhase.Moved;
            }
            else
            {
                phase = MultiplatformTouchPhase.Stationary;
            }
        }

        public void EndTouch()
        {
            //oldPosition = currentPosition;

            phase = MultiplatformTouchPhase.Ended;
        }

        Vector2 ConvertToRelative(Vector2 absolutePosition)
        {
            return new Vector2(absolutePosition.x / Screen.width, absolutePosition.y / Screen.height);
        }

    }

    //[Range(1, 5)]
    //[SerializeField] int maxTouches = 2;

    public static System.Action<float> onSwipeHorizontal;
    //List<MultiplatformTouch> touches;
    MultiplatformTouch touch;
    

    void Update()
    {
        if (touch != null && touch.phase == MultiplatformTouchPhase.Ended)
        {
            touch = null;
        }

        DetectTouches();
        DetectSwipe();
    }

    void DetectTouches()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touch = new MultiplatformTouch(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            if (touch != null)
            {
                touch.ChangePosition(Input.mousePosition);
            }
            else
            {
                Debug.LogWarning("Why touch == null???");
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (touch != null)
            {
                touch.EndTouch();
            }
            else
            {
                Debug.LogWarning("Why touch == null???");
            }
        }

//        Touch[] mobileTouches = Input.touches;
//        touches = new List<MultiplatformTouch>();
//        for (int i = 0; i < mobileTouches.Length; i++)
//        {
//        }

//#if UNITY_IOS || UNITY_ANDROID
//        Touch[] mobileTouches = Input.touches;

//#else

//        if (Input.GetMouseButtonDown(0))
//        {
            
//        }
//        else if (Input.GetMouseButton(0))
//        {

//        }
//        else if (Input.GetMouseButtonUp(0))
//        {

//        }
        
//#endif
    }

    void DetectSwipe()
    {
        if (touch == null)
        {
            //Debug.Log("touch == null");
            return;
        }

        if (touch.phase == MultiplatformTouchPhase.Ended)
        {
            float deltaX = touch.relativeDeltaPosition.x;
            //Debug.Log(deltaX);
            if (Mathf.Abs(deltaX) > 0.2f)
            {
                //Debug.Log("onSwipeHorizontal");
                if (onSwipeHorizontal != null)
                {
                    onSwipeHorizontal(deltaX);
                }
            }
        }
    }

}
