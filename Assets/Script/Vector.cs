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

    public GameObject PointC;

    public Vector2 point;

    private void OnDrawGizmos()
    {
        //Exercice1();
        //Exercice2();
        Vector2 objPos = transform.position;
        Vector2 righ = transform.right;
        Vector2 up = transform.up;
        Vector2 objPosB = transform.position;
        Vector2 righB = transform.right;
        Vector2 upB = transform.up;
        Exercice3WorldToLocal();
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

    #region Basic vector Math
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

    private void Exercice3WorldToLocal()
    {
        
        Transform pointBPos = PointB.transform;
        Transform pointCPos = PointC.transform;
        Vector2 relPoint = pointBPos.position - pointCPos.position;
                Vector2 rightB = PointB.transform.right;
        Vector2 upB = PointB.transform.up;
        float x = Vector2.Dot ( relPoint,rightB );
        float y = Vector2.Dot ( relPoint,upB );
        pointCPos.position =  new Vector2 (x,y);
        //Vector3.Distance(pointBPos.position,Vector2.zero);
        //PointC.transform.position = ((Vector2)PointB.transform.position - Vector2.zero) + (Vector2)(point.x *PointB.transform.up + point.y*PointB.transform.right);
        DrawBasicVectors(pointBPos.position,pointCPos.right,pointCPos.up);
        Gizmos.DrawSphere(PointC.transform.position, 0.2f);
        //Vector2 length = (transform.position + ( transform.position + PointB.transform.position));
        //length = new Vector2 ( (length.x * PointB.transform.up), (length.y*PointB.transform.right));
        //objectA.position + ( pointB.position * objectA.transformUp)
    }

    private void Exercice3LocalToWorld(){
        Vector2 objPos = transform.position;
        Vector2 right = transform.right;
        Vector2 up = transform.up;
        Vector2 objPosB = PointB.transform.position;
        Vector2 rightB = PointB.transform.right;
        Vector2 upB = PointB.transform.up;
        Vector2 worldOffset = rightB*point.x + upB* point.y;
        PointC.transform.position = objPosB + worldOffset; 
        Gizmos.DrawSphere(PointC.transform.position, 0.5f);
    }

    #endregion

    #region tool

    void DrawBasicVectors(Vector2 pos , Vector2 right, Vector2 up){
        Gizmos.color = Color.red;
        Gizmos.DrawRay ( pos, right);
        Gizmos.color = Color.green;
        Gizmos.DrawRay (pos, up);
        Gizmos.color = Color.white;
    }

    #endregion
}
