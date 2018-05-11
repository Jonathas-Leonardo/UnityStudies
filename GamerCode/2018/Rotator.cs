using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    public float anglex, angley, anglez;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(Vector3.forward,angle);
        Rotate(anglex,angley,anglez);
	}

    void Rotate(float x, float y, float z)
    {
        transform.Rotate(x, y, z);
    }

    void RotateByStep(int count, int step)
    {
        transform.Rotate(Vector3.up, -1);
        count++;

        if (count == step)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Round(transform.eulerAngles.y), transform.eulerAngles.z);
        }
    }
}
