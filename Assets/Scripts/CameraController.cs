using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public new Camera camera;
    public GameObject target;

    public float   cameraDistance;
    public Vector3 cameraDirection;
    public Vector3 targetAnchor;

    public float minimumDistance;
    public float maximumDistance;

    public void Update()
    {
        // Control camera distance using the mouse wheel.
        // Todo: Implement proper smoothing with varying speed depending on the distance.
        this.cameraDistance += Input.GetAxis("Mouse ScrollWheel") * -1000.0f * Time.deltaTime;
        this.cameraDistance = Mathf.Clamp(this.cameraDistance, this.minimumDistance, this.maximumDistance);
    }

    public void LateUpdate()
    {
        // Calculate position of the camera.
        Vector3 targetPosition = this.target.transform.position + this.targetAnchor;

        this.camera.transform.position = targetPosition;
        this.camera.transform.rotation = Quaternion.Euler(this.cameraDirection);
        this.camera.transform.Translate(0.0f, this.cameraDistance, 0.0f);

        // Rotate camera towards the target.
        Vector3 targetOffset = targetPosition - this.camera.transform.position;

        this.camera.transform.rotation = Quaternion.LookRotation(targetOffset.normalized);
    }
}
