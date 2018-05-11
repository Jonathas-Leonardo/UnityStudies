using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {

    public GameObject target;
    public float time;
    public bool isFollow;

    public bool followX, followY, followZ;
    Vector3 vec;

    public Vector3 offset;
	
	// Update is called once per frame
	void Update () {
        
        if (target != null)
        {
            if (isFollow)
            {
                if (followX)
                {
                    vec = new Vector3(target.transform.position.x, vec.y, vec.z);
                }

                if (followY)
                {
                    vec = new Vector3(vec.x, target.transform.position.y, vec.z);
                }

                if (followZ)
                {
                    vec = new Vector3(vec.x, vec.y, target.transform.position.z);
                }

                transform.position = Vector3.Lerp(transform.position, vec+offset, time);
            }

        }

    }
}
