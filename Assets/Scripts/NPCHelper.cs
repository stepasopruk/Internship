using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHelper : MonoBehaviour
{
    public float FinndtargrtRadius = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, FinndtargrtRadius);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].GetComponent<HealthHelper>() && 
                colliders[i].GetComponent<HealthHelper>().Group != GetComponent<HealthHelper>().Group)
            {
                GetComponent<MovementInput>().target = colliders[i].transform;
            }
        }
    } 
}
