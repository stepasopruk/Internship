using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshPathEditor : Editor
{
   [DrawGizmo(GizmoType.NotInSelectionHierarchy | GizmoType.InSelectionHierarchy)]
    static void RenderCustomGizmo(Transform objTransform, GizmoType gizmoType)
    {

        MovementInput t = objTransform.GetComponent<MovementInput>();

        if (!t)
            return;

        NavMeshAgent navMeshAgent = t.GetComponent<NavMeshAgent>();

        for (int i = 0; i + 1 < navMeshAgent.path.corners.Length; i++)
        {
            Handles.DrawLine(navMeshAgent.path.corners[i],
                navMeshAgent.path.corners[i + 1]);

            if(i + 2 == navMeshAgent.path.corners.Length)
            {
                Handles.DrawWireDisc(navMeshAgent.path.corners[i + 1], Vector3.up, 0.3f);
            }
        }
    }


}
