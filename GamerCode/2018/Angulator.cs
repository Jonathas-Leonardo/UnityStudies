using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angulator : MonoBehaviour {

    public float angle;
    public float minAngle, maxAngle;
    [Space(5)]
    [Range(0, 1)]
    public float step;

    // Update is called once per frame
    void Update () {

        angle = minAngle + step * (maxAngle - minAngle);

        if (transform.parent != null)
        {
            transform.rotation = transform.parent.rotation * Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }
}
