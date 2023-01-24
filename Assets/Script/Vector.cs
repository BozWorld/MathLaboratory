using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector : MonoBehaviour
{
    [Range(0, 10f)]
    public float Radius = 1f;

    [Range(0, 1f)]
    public float Threshold;

    [Range(0, 10f)]
    public float Unit = 1f;

    private float dotV;

    public GameObject PointB;

    private void OnDrawGizmos()
    {
        //Exercice1();
        Exercice2();
    }

    private void pointAlongDirection()
    {
        Gizmos.DrawLine(Vector2.zero, transform.position.normalized);
        float length = transform.position.magnitude;
        float distance = Vector2.Distance(transform.position, PointB.transform.position);
        Vector2 dir = (PointB.transform.position - transform.position).normalized;
        //Gizmos.DrawLine ( Vector2.zero, Vector3.right  * distance);
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + dir);

        Vector2 offsetVec = dir * Unit;

        Gizmos.DrawSphere((Vector2)transform.position + offsetVec, 0.05f);
    }

    private void Exercice1()
    {

        Vector3 center = transform.position;

        if (PointB == null)
        {
            return;
        }

        Vector3 PointBPos = PointB.transform.position;

        float dist = Vector3.Distance(center, PointBPos);

        bool inside = dist < Radius;

        Gizmos.color = inside ? Color.green : Color.red;

        Gizmos.DrawWireSphere(center, Radius);
    }
    private void Exercice2()
    {
        Vector2 dir = PointB.transform.position - transform.position;
        dir = dir.normalized;
        Vector2 lookAt = transform.right;

        float dot = Vector2.Dot(dir, lookAt);
        dotV = dot;
        bool isLooking = dot >= Threshold;

        Gizmos.color = isLooking ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + dir);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + lookAt);


    }
    /*     private void Exercice2()
        {
            Gizmos.color = Color.white;
            Vector3 direction = transform.TransformDirection(Vector3.right)*Unit;

            RaycastHit hit;

            if(Physics.Raycast(transform.position,direction, out hit, Unit)){
                Gizmos.color = Color.red;
                //Vector3.Dot(dir, hit.normal);
            }
            Gizmos.DrawRay(transform.position,direction);
        } */

    /*     private void Exercice3 () {
            Vector2 objPos = transform.position;
            Vector2 right = transform.right;
            Vector2 up = transform.up;
        } */
}
