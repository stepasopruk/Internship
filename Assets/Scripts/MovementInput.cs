using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class MovementInput : MonoBehaviour
{
    [System.NonSerialized] public Transform target;
    [System.NonSerialized] public Vector3 targetPoint;

    

    private void Start()
    {
        
    }

    private void Update()
    {
        UpdatePosition();
        UpdateMovement();
    }

    protected abstract void UpdatePosition();

    protected abstract void UpdateMovement();
}
