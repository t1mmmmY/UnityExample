using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour 
{
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody rigidbody;
    //[SerializeField] Collider[] colliders;

    [SerializeField] float maxSpeed = 10.0f;

    int speedAnimationHash = Animator.StringToHash("speed");
    int groundedAnimationHash = Animator.StringToHash("grounded");
    float speed = 0.0f;
    bool directionRight = true;
    bool characterGrounded = false;
    bool enableInput = true;

    void Update()
    {
        bool isGrounded = CheckGround();
        if (isGrounded && !characterGrounded)
        {
            SetFall(true);
        }
        else if (!isGrounded && characterGrounded)
        {
            SetFall(false);
        }

        characterGrounded = isGrounded;
    }

    bool CheckGround()
    {
        if (Physics.Raycast(transform.position, -transform.up, 10))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void SetFall(bool isGrounded)
    {
        animator.SetBool(groundedAnimationHash, isGrounded);
        enableInput = isGrounded;
    }


    public void ChangeSpeed(float newSpeed)
    {
        if (!enableInput)
        {
            return;
        }

        speed = Mathf.Clamp(newSpeed, -1.0f, 1.0f);

        if ((speed > 0 && !directionRight) || (speed < 0 && directionRight))
        {
            Flip();
        }

        Vector3 newVelocity = transform.right * speed * maxSpeed;
        newVelocity.y = rigidbody.velocity.y;
        rigidbody.velocity = newVelocity;

        animator.SetFloat(speedAnimationHash, Mathf.Abs(speed));
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x = -scale.x;
        transform.localScale = scale;

        directionRight = !directionRight;
    }
}
