using UnityEngine;
using System.Collections;

public class FollowPath : MonoBehaviour {

    public GameObject path;
    public Vector3[] nodepoints;
    public int current_path;

    public float speed;
    public bool isFront;
    public bool isLoop;

	// Use this for initialization
	void Start () {

        current_path = 0;

        //if (path.GetComponent<RadiusPath>() != null)
        //{
        //    nodepoints = path.GetComponent<RadiusPath>().nodepoints;
        //}
        //else if (path.GetComponent<LinePath>() != null) {
        //    nodepoints = path.GetComponent<LinePath>().nodepoints;
        //}
        //else if ((path.GetComponent<BezierPath>() != null))
        //{
        //    nodepoints = path.GetComponent<BezierPath>().nodepoints;
        //}

        if (nodepoints.Length > 0)
        {
            transform.position = nodepoints[0];
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (nodepoints.Length > 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                moveToNext();
                print("A key");
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                moveToPrev();
                print("S key");
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                moveToFirst();
                print("D key");
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                moveToLast();
                print("F key");
            }

            moveToPosition(nodepoints[current_path]);

            if (transform.position == nodepoints[current_path])
            {

                if (isFront) {
                    if (current_path < nodepoints.Length - 1)
                    {
                        moveToNext();
                    }else if(current_path == nodepoints.Length - 1 && isLoop){
                        moveToFirst();
                    }
                }

                if (!isFront) {
                    if (current_path > 0)
                    {
                        moveToPrev();
                    }
                    else if (current_path == 0 && isLoop) {
                        moveToLast();
                    }
                }
            }
        }
	}

    void moveToFirst() {
        current_path = 0;
    }

    void moveToPrev() {
        current_path--;
    }

    void moveToNext()
    {
        current_path++;
    }

    void moveToLast()
    {
        current_path = nodepoints.Length - 1;
    }

    void moveToPosition(Vector3 pos)
    {
        transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
    }

}
