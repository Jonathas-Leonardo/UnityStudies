using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosPosition : MonoBehaviour {

    public GIZMOTYPE GizmoType;
    public Color gizmosColor = Color.white;
    public float radius = 0.2f;

    public Vector3[] position;

    void OnDrawGizmos()
    {
        foreach (Vector3 pos in position)
        {
            if (GizmoType == GIZMOTYPE.SPHERE)
            {
                Gizmos.color = gizmosColor;
                Gizmos.DrawWireSphere(transform.position + pos, radius);
            }
            else if (GizmoType == GIZMOTYPE.CUBE)
            {
                Gizmos.color = gizmosColor;
                Gizmos.DrawWireCube(transform.position + pos, new Vector3(radius, radius, radius));
            }
            else if (GizmoType == GIZMOTYPE.MESH)
            {
                Gizmos.color = gizmosColor;
                Gizmos.DrawWireCube(transform.position + pos, GetComponent<MeshRenderer>().bounds.size);
            }
        }
    }
}
