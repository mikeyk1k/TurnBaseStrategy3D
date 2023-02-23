using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private const float MinFollowYOffset = 2f;
    private const float MaxFollowYOffset = 12f;
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    private CinemachineTransposer cinemachineTransposer;
    private Vector3 targetFollowOffset;
    private void Awake()
    {
        cinemachineTransposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        targetFollowOffset = cinemachineTransposer.m_FollowOffset;
    }
    private void Update()
    {
        Vector3 inputMoveDir = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            inputMoveDir.z = +1f;
        if (Input.GetKey(KeyCode.S))
            inputMoveDir.z = -1f;
        if (Input.GetKey(KeyCode.A))
            inputMoveDir.x = -1f;
        if (Input.GetKey(KeyCode.D))
            inputMoveDir.x = +1f;
        float moveSpeed = 5f;
        Vector3 moveVector = transform.forward * inputMoveDir.z + transform.right * inputMoveDir.x;
        transform.position += moveVector * moveSpeed * Time.deltaTime;
        Vector3 rotationVector = Vector3.zero;
        if (Input.GetKey(KeyCode.Q))
            rotationVector.y = +1f;
        if (Input.GetKey(KeyCode.E))
            rotationVector.y = -1f;
        float rotationSpeed = 100f;
        transform.eulerAngles += rotationVector * rotationSpeed * Time.deltaTime;
        float zoomAmount = 1f;
        if (Input.mouseScrollDelta.y > 0)
            targetFollowOffset.y -= zoomAmount;
        if (Input.mouseScrollDelta.y < 0)
            targetFollowOffset.y += zoomAmount;
        targetFollowOffset.y = Mathf.Clamp(targetFollowOffset.y, MinFollowYOffset, MaxFollowYOffset);

        float zoomSpeed = 1f;
        cinemachineTransposer.m_FollowOffset = Vector3.Lerp(cinemachineTransposer.m_FollowOffset, targetFollowOffset, zoomSpeed * Time.deltaTime);
    }
}
