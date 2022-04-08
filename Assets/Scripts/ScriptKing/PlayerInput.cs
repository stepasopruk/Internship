using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private ButtonPressListener m_buttonPressListener;
    public TurnControls TurnControls { get; private set; }
    public MovementInput MovementInput { get; private set; }

    private void Start()
    {
        TurnControls = new TurnControls(m_buttonPressListener);
    }

    private void Update()
    {
        TurnControls.OnInputUpdate();
    }

    private void OnDestroy()
    {
        TurnControls.OnInputDestroy();
    }

}
