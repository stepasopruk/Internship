using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TurnControls
{

    private ButtonPressListener m_buttonPressListener;
    private float f_pressTimeStamp;

    public TurnControls(ButtonPressListener endTurnButton)
    {
        m_buttonPressListener = endTurnButton;
        m_buttonPressListener.ButtonPressedEvent += OnEndTurnButtonPressed;
    }

    private void OnEndTurnButtonPressed()
    {
        f_pressTimeStamp = Time.time;
        EndTurnPressed = true;
        
    }
    public void OnInputUpdate()
    {
        if(EndTurnPressed && Time.time - f_pressTimeStamp > Time.deltaTime)
        {
            EndTurnPressed = false;
        }
    }

    public void OnInputDestroy()
    {
        m_buttonPressListener.ButtonPressedEvent -= OnEndTurnButtonPressed;
    }

    public bool EndTurnPressed { get; private set; }
}