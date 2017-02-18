using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject m_camera;
    public GameObject m_target;

    public float   m_cameraDistance;
    public Vector3 m_cameraDirection;
    public Vector3 m_targetAnchor;

    public float m_minimumDistance;
    public float m_maximumDistance;

    void Update()
    {
        // Control camera distance using the mouse wheel.
        // Todo: Implement proper smoothing with varying speed depending on the distance.
        m_cameraDistance += Input.GetAxis("Mouse ScrollWheel") * -1000.0f * Time.deltaTime;
        m_cameraDistance = Mathf.Clamp(m_cameraDistance, m_minimumDistance, m_maximumDistance);
    }

    void LateUpdate()
    {
        // Calculate position of the camera.
        Vector3 targetPosition = m_target.transform.position + m_targetAnchor;

        m_camera.transform.position = targetPosition;
        m_camera.transform.rotation = Quaternion.Euler(m_cameraDirection);
        m_camera.transform.Translate(0.0f, m_cameraDistance, 0.0f);

        // Rotate camera towards the target.
        Vector3 targetOffset = targetPosition - m_camera.transform.position;

        m_camera.transform.rotation = Quaternion.LookRotation(targetOffset.normalized);
    }
}
