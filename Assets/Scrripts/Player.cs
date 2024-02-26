using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2,
    };

    public RotationAxes axes = RotationAxes.MouseXandY;
    public float sensitivityHorizontal = 9.0f;
    public float sensitivityVertical = 9.0f;
    public float minimunVertical = -45.0f;
    public float maximumVertical = 45.0f;

    private float verticalRotation = 0;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null )
            rb.freezeRotation = true;
    }

    private void Update()
    {
        if (axes == RotationAxes.MouseX)
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHorizontal, 0);
        else if (axes == RotationAxes.MouseY)
        {
            verticalRotation -= Input.GetAxis("Mouse Y") * sensitivityVertical;
            verticalRotation = Mathf.Clamp(verticalRotation, minimunVertical, maximumVertical);

            float horizontalRotation = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(verticalRotation, horizontalRotation, 0);
        }
        else
        {
            verticalRotation -= Input.GetAxis("Mouse Y") * sensitivityVertical;
            verticalRotation = Mathf.Clamp(verticalRotation, minimunVertical, maximumVertical);

            float delta = Input.GetAxis("Mouse X") * sensitivityHorizontal;
            float horizontalRotation = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(verticalRotation, horizontalRotation, 0);
        }
    }
}
