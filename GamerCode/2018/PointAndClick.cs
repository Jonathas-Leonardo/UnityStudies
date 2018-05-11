using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndClick : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;
    Camera cam;
    Vector3 hitPosition;
    public LayerMask lm;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(hitPosition,.2f);
    }

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);

        if (Physics.Raycast(ray, out hit, 100, lm))
        {
            hitPosition = hit.point;
        }

        //objTarget.transform.position = hitPosition;
    }

    public Vector3 GetHitPosition()
    {
        return hitPosition;
    }

}
