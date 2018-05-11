using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translator : MonoBehaviour {

    public float velx, vely, velz;

    public enum MOVETYPE { NOTHING , AXIS , TRANSLATE };
    public MOVETYPE movetype;

    // Update is called once per frame
    void Update () {

        if(movetype == MOVETYPE.TRANSLATE)
        {
            MoveTranslate(velx,vely,velz);
        }

        if(movetype == MOVETYPE.AXIS)
        {
            MoveAxis(velx, vely, velz);
        }
    }

    void MoveAxis(float x, float y, float z)
    {
        transform.position += new Vector3(x, y, z);
    }

    void MoveTranslate(float x, float y, float z)
    {
        transform.Translate(x* Time.deltaTime,y*Time.deltaTime,z*Time.deltaTime);
    }
}
