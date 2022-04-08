using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementKeyBoard : MovementInput
{
    protected override void UpdateMovement()
    {
        throw new System.NotImplementedException();
    }

    protected override void UpdatePosition()
    {
        RaycastHit _hit;

        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hit))
            {
                targetPoint = _hit.point;
            }
        }
    }
}
