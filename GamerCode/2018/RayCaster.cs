using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour {

    Ray ray;
    RaycastHit rayHit;

    public float rayLength;
    public LayerMask layerMask;
    public enum RAY_DIRECTION { X, Y, Z };
    public RAY_DIRECTION rayDirection;

    [Space(10)]
    public bool isCheck;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (rayDirection == RAY_DIRECTION.X)
        {
            ray = new Ray(transform.position, transform.right);
        }

        if (rayDirection == RAY_DIRECTION.Y)
        {
            ray = new Ray(transform.position, transform.up);
        }

        if (rayDirection == RAY_DIRECTION.Z)
        {
            ray = new Ray(transform.position, transform.forward);
        }

        Debug.DrawLine(ray.origin, ray.origin + ray.direction * rayLength, Color.blue);

        isCheck = (Physics.Raycast(ray, out rayHit, rayLength, layerMask));    
    }

    public RaycastHit getRayHit()
    {
        return rayHit;
    }
}
