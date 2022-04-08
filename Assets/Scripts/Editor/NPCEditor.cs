using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NPCHelper))]
public class NPCEditor : Editor
{
    private void OnSceneGUI()
    {
        NPCHelper t = target as NPCHelper;

        if (!t)
            return;

        Handles.color = Color.blue;
        Handles.DrawWireDisc(t.transform.position, Vector3.up, t.FinndtargrtRadius);

        t.FinndtargrtRadius = Handles.ScaleValueHandle(t.FinndtargrtRadius,
            t.transform.position + new Vector3(0, 0, t.FinndtargrtRadius), 
            Quaternion.identity, 1f, Handles.DotCap, 2);
    }
}
