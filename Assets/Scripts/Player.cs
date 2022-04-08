using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{

    private RaycastHit _hit;
    private PlayerInput m_playerInput;

    public event System.Action EndTurnEvent; 

    //[System.NonSerialized] public bool _isStep;

    private NavMeshAgent _navMeshAgent;
    public bool HasTurn { get; private set; }


    private void Start()
    {
        m_playerInput = GetComponent<PlayerInput>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (m_playerInput.TurnControls.EndTurnPressed)
            EndTurn();
    }


    public void StartTurn()
    {
        HasTurn = true;
    }

    private void EndTurn()
    {
        if (HasTurn)
        {
            EndTurnEvent?.Invoke();
            HasTurn = false;
        }
    }
}
