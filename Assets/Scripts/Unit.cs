using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator;
    private Vector3 _targetPosition;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float _rotateSpeed;
    private void Awake()
    {
        _targetPosition = transform.position;
    }
    private void Update()
    {
        
        float sqrStoppingDistance = 0.0001f;
        if ((_targetPosition - transform.position).sqrMagnitude > sqrStoppingDistance)
        {
            Vector3 moveDirection = (_targetPosition - transform.position).normalized;
            transform.position += MoveSpeed * Time.deltaTime * moveDirection;

            float rotateSpeed = _rotateSpeed;
            transform.forward = Vector3.Lerp(transform.forward, moveDirection,Time.deltaTime * rotateSpeed);

            unitAnimator.SetBool("IsWalking", true);
        }
        else
            unitAnimator.SetBool("IsWalking", false);
    }
    public void Move(Vector3 targetPosition)
    {
        this._targetPosition = targetPosition;
    }
}