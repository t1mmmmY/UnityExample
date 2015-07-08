using UnityEngine;
using System.Collections;

public class CharacterUserControl : MonoBehaviour 
{
    [SerializeField] CharacterController characterController;
    [SerializeField] Transform cameraPivot;
    bool isGameStarted = false;

    void OnEnable()
    {
        StartAnimation.onEndAnimation += OnStartGame;
    }

    void OnDisable()
    {
        StartAnimation.onEndAnimation -= OnStartGame;
    }

    void OnStartGame()
    {
        isGameStarted = true;
    }

    void LateUpdate()
    {
        if (!isGameStarted)
        {
            return;
        }

#if !UNITY_IOS && !UNITY_ANDROID
        float horizontal = Input.GetAxis("Horizontal");
        characterController.ChangeSpeed(horizontal);
#endif

        if (cameraPivot.rotation != characterController.transform.rotation)
        {
            RotateCharacter();
        }
        
    }


    void RotateCharacter()
    {
        characterController.transform.rotation = cameraPivot.rotation;
    }

}
