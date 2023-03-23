using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Tooltip("Offset of the camera from the Target's pivot ex. move camera up from players feet")]
    public Vector3 LookAtOffset = new Vector3(-25, 0, 0);
    //TODO: This doesn't currently work, since it rotates around because of the lookat function. Find a fix for this or a different solution
    [Tooltip("Allows for fine tuning of camera position, ex. move to the side of characters head for over the shoulder view")]
    public Vector3 SideToSideOffset = new Vector3(0, 0, 0);
    public GameObject Target;
    [SerializeField]
    private float springConst = 30f;
    private float dampingConst;

    private float hDist;
    private float vDist;

    private Vector3 velocity;
    private Vector3 actualPosition;


    private void Start()
    {
        hDist = Target.transform.position.z - transform.position.z; //Horizontal offset from target
        vDist = transform.position.y - Target.transform.position.y; //Vertical offset from target

        dampingConst = 2.0f * Mathf.Sqrt(springConst);
        actualPosition = Target.transform.position - Target.transform.forward * hDist + Target.transform.up * vDist;
        velocity = Vector3.zero;
    }

    private void Update()
    {
        Vector3 idealPosition = Target.transform.position - Target.transform.forward * hDist + Target.transform.up * vDist;
        Vector3 displacement = actualPosition - idealPosition;
        Vector3 springAcceleration = (-springConst * displacement) - (dampingConst * velocity);
        velocity += springAcceleration * Time.deltaTime;
        actualPosition += velocity * Time.deltaTime;
        transform.position = actualPosition + SideToSideOffset;
        transform.LookAt(Target.transform);
        transform.rotation *= Quaternion.Euler(LookAtOffset); //offset the camera angle to not be aimed at the players feet
    }
}
