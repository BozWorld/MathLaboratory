using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercice1 : MonoBehaviour
{
    [Range(0,10f)]
    public float radius = 1f;

    [Range(0,10f)]
    public float unit = 1f;

    public Transform player;
    

    private void OnDrawGizmos() {
        exercice2();
    }

    private void exercice1(){

        Vector3 center = transform.position;

        if ( player == null ) {
            return;
        }

        Vector3 playerPos = player.position;

        float dist = Vector3.Distance (center, playerPos);

        bool inside = dist < radius;

        Gizmos.color = inside ? Color.green : Color.red;

        Gizmos.DrawWireSphere ( center , radius);
    }

    private void exercice2()
    {
        Gizmos.color = Color.blue;
        Vector3 direction = transform.TransformDirection(Vector3.right)*unit;
        Gizmos.DrawRay(transform.position,direction);
        RaycastHit hit;
        
        if(Physics.Raycast(transform.position,direction, out hit, unit)){
            Vector3 dir = player.right;
            Gizmos.color = Color.red;
            Vector3.Dot(dir, hit.normal);
        }
    }
}
