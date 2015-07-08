using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour 
{
    [SerializeField] Animator animator;
    int endGameTriggerHash = Animator.StringToHash("endGame");

    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger(endGameTriggerHash);
    }
}
