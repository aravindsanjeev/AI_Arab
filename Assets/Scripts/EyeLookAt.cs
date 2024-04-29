using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLookAt : MonoBehaviour
{
    public Transform targetCamera; // Reference to the camera's Transform
    public Transform leftEye; // Reference to the left eye's Transform
    public Transform rightEye; // Reference to the right eye's Transform
    public float rotationValue =180;
    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (targetCamera != null && leftEye != null && rightEye != null)
        {
            /*
            // Calculate the direction from the eyes to the camera
            Vector3 direction = targetCamera.position - leftEye.position;

            // Calculate the rotation based on the direction
            Quaternion rotation = Quaternion.LookRotation(direction);

            // Apply the rotation to both eyes
            leftEye.rotation = rotation;
            rightEye.rotation = rotation;

            */

            leftEye.LookAt(targetCamera);
            rightEye.LookAt(targetCamera);
            leftEye.localRotation = Quaternion.Euler(0, rotationValue, 0);
            rightEye.localRotation = Quaternion.Euler(0, rotationValue, 0);
        }
    }
}
