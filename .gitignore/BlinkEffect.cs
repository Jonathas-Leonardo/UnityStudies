using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkEffect : MonoBehaviour {

    public bool isVisible;

	// Use this for initialization
	void Start () {
        //rend = GetComponent<Renderer>();
        isVisible = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(Mathf.PingPong(Time.time, 1) > .5f)
        {
            isVisible = true;
        }
        else
        {
            isVisible = false;
        }
	}
}
