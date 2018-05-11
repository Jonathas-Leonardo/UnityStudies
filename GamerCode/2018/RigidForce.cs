using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidForce : MonoBehaviour {

    public Rigidbody rb;
    public float force;

    public enum AXISTYPE { X,Y,Z }
    public AXISTYPE axisType;

	// Use this for initialization
	void Start () {

        if(axisType == AXISTYPE.Z)
        {
            rb.AddForce(transform.forward * force, ForceMode.VelocityChange);
        }

        if (axisType == AXISTYPE.Y)
        {
            rb.AddForce(transform.up * force, ForceMode.VelocityChange);
        }

        if (axisType == AXISTYPE.X)
        {
            rb.AddForce(transform.right * force, ForceMode.VelocityChange);
        }

    }
}
