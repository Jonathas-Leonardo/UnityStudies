using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetor : MonoBehaviour {

    public GameObject target;

    public enum Axis { X,Y,Z };
    public Axis axis;

    Quaternion rotation;

    // Update is called once per frame
    void Update () {
        if (target != null)
        {
            Vector3 relativePos = (target.transform.position - transform.position);

            if (axis == Axis.X)
            {
                rotation = Quaternion.LookRotation(relativePos, Vector3.right);
            }
            else if (axis == Axis.Y)
            {
                rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            }
            else if (axis == Axis.Z)
            {
                rotation = Quaternion.LookRotation(relativePos, Vector3.forward);
            }

            transform.rotation = rotation;
        }
	}
}
