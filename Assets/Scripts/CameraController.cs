using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject m_camera;
    public GameObject m_target;

    public Vector3 m_cameraOffset;
    public Vector3 m_targetOffset;

    void LateUpdate()
    {
        // Calculate position and direction of the camera.
        Vector3 targetPosition = m_target.transform.position + m_targetOffset;
        Vector3 cameraPosition = targetPosition + m_cameraOffset;
        Vector3 targetDirection = (targetPosition - cameraPosition).normalized;

        m_camera.transform.position = cameraPosition;
        m_camera.transform.rotation = Quaternion.LookRotation(targetDirection);
    }
}
