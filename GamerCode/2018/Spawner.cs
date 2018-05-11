using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject gobj;
    public int currentSpawn;
    [Space(10)]
    public bool isOn;

    // Update is called once per frame
    void Update () {

        if (gobj != null) {

            if (isOn)
            {
                GameObject obj = Instantiate(gobj, transform.position, transform.rotation) as GameObject;
                obj.name = obj.name + currentSpawn;
                currentSpawn++;
                isOn = false;
            }
        }
	}
}
