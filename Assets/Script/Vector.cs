using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector : MonoBehaviour
{
    [Range(0,10f)]
    public float radius = 1f;

    [Range(0,10f)]
    public float unit = 1f;

    public GameObject pointB;

    private void OnDrawGizmos() {

        Gizmos.DrawLine( Vector2.zero , transform.position.normalized);
        float length = transform.position.magnitude;
        float distance = Vector2.Distance(transform.position,pointB.transform.position);
        Vector2 dir = (pointB.transform.position - transform.position).normalized;
        //Gizmos.DrawLine ( Vector2.zero, Vector3.right  * distance);
        Gizmos.DrawLine ( transform.position, (Vector2)transform.position + dir);

        Vector2 offsetVec = dir* unit;
        
        Gizmos.DrawSphere ( (Vector2)transform.position + offsetVec , 0.05f);

    }

/*     private void exercice1(){

        Vector3 center = transform.position;

        if ( player == null ) {
            return;
        }

        Vector3 playerPos = player.transform.position;

        float dist = Vector3.Distance (center, playerPos);

        bool inside = dist < radius;

        Gizmos.color = inside ? Color.green : Color.red;

        Gizmos.DrawWireSphere ( center , radius);
    } */

/*     private void exercice2()
    {
        Gizmos.color = Color.white;
        Vector3 direction = transform.TransformDirection(Vector3.right)*unit;

        RaycastHit hit;
        
        if(Physics.Raycast(transform.position,direction, out hit, unit)){
            Gizmos.color = Color.red;
            //Vector3.Dot(dir, hit.normal);
        }
        Gizmos.DrawRay(transform.position,direction);
    } */

/*     private void exercice3 () {
        Vector2 objPos = transform.position;
        Vector2 right = transform.right;
        Vector2 up = transform.up;
    } */
}
