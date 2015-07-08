using UnityEngine;
using System.Collections;

public class StartAnimation : MonoBehaviour 
{
    [SerializeField] Animator animator;
    public static System.Action onEndAnimation;

    void Update()
    {
        if (!animator.enabled)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            FinishAnimation();
        }
    }

    void FinishAnimation()
    {
        animator.speed = 10;
    }

    public void EndAnimation()
    {
        if (onEndAnimation != null)
        {
            onEndAnimation();
        }
        animator.enabled = false;
    }
}
