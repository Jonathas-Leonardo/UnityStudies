using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosController : MonoBehaviour {

    public enum GIZMOTYPE { SPHERE, CUBE, MESH }
    public GIZMOTYPE GizmoType;
    public Color gizmosColor = Color.white;
    public float radius = 0.2f;

    public GameObject[] gizmos;

    void OnDrawGizmos()
    {
        if (gizmos != null)
        {
            foreach (GameObject obj in gizmos)
            {
                Vector3 pos = obj.transform.position;

                if (GizmoType == GIZMOTYPE.SPHERE)
                {
                    Gizmos.color = gizmosColor;
                    Gizmos.DrawWireSphere(pos, radius);
                }
                else if (GizmoType == GIZMOTYPE.CUBE)
                {
                    Gizmos.color = gizmosColor;
                    Gizmos.DrawWireCube(pos, new Vector3(radius, radius, radius));
                }
                else if (GizmoType == GIZMOTYPE.MESH)
                {
                    Gizmos.color = gizmosColor;
                    Gizmos.DrawWireCube(pos, GetComponent<MeshRenderer>().bounds.size);
                }
            }
        }
    }
}
