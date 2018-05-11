using UnityEngine;
using System.Collections;


public class LinePath : MonoBehaviour {

    public Color linecolor = Color.yellow;
    public Color wcubecolor = Color.white;

    public bool isClose;

    Vector3 sizeGizmo = new Vector3(.1f,.1f,.1f);

    public Vector3[] nodepoints;

    void OnDrawGizmos()
    {

        for (int i = 0; i < nodepoints.Length; i++)
        {
            Gizmos.color = wcubecolor;
            Gizmos.DrawWireCube(nodepoints[i], sizeGizmo);

            Gizmos.color = linecolor;

            if (i + 1 < nodepoints.Length)
            {
                Gizmos.DrawLine(nodepoints[i], nodepoints[i+1]);
            }
        }

        if (isClose)
        {
            Gizmos.DrawLine(nodepoints[nodepoints.Length-1], nodepoints[0]);
        }

        //UnityEditor.Handles.Label(nodepoints[0], "startLine");
    }
}
