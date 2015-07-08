using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 shift;
    [SerializeField] float speed = 10.0f;

    //void Start()
    //{
    //    StartCoroutine("Follow");
    //}

    //IEnumerator Follow()
    //{
    //    do
    //    {
    //        iTween.MoveTo(this.gameObject, target.position + target.forward + shift, speed);
    //        yield return new WaitForSeconds(0.1f);

    //    } while (Application.isPlaying);
    //}

    void FixedUpdate()
    {
        //transform.position = Vector3.Lerp(transform.position, target.position + target.forward + shift, Time.deltaTime * speed);
        iTween.MoveUpdate(this.gameObject, target.position + target.forward + shift, speed);
    }
}
