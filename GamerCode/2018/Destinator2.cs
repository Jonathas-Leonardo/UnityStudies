using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destinator2 : MonoBehaviour {

    public Transform startTf;
    public Transform endTf;

    public enum TRANSFORMTYPE { POSITION, ROTATION, SCALE, }
    [Range(0, 1)]
    public float time;
    public bool isPosition, isRotation, isScale;

    // Use this for initialization
    void Start () {        
        //startTf.position = transform.position;
        transform.position = startTf.position;
    }
	
	// Update is called once per frame
	void Update () {

        if (isPosition)
        {
            transform.position = Vector3.Lerp(startTf.position, endTf.position, time);
        }
        if (isRotation)
        {
            transform.rotation = Quaternion.Lerp(startTf.rotation, endTf.rotation, time);
        }
        if (isScale)
        {
            transform.localScale = Vector3.Lerp(startTf.localScale, endTf.localScale, time);
        }
    }
}
