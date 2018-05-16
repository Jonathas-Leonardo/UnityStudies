using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    public float speed;
    public float handling;
    public float brake;
    public float handBrake;
    public float reverse;

    public bool isReverse;
    public bool isGround;

    Rigidbody rb;
    public GameObject direction;
    public GameObject model;
    RaycastHit rayHit;
    float distanceOfRay;
    float distanceOfGround;
    public LayerMask lm_circuit;
    public Transform rayGround;
    public Transform rayNormal;

    //public bool isDoorOpen;

    public float gravity;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
        //distanceOfRay = (transform.position.y - rayNormal.position.y);
        //gravity= -10;
    }
	
	// Update is called once per frame
	void Update () {

        //distanceOfRay = (transform.position.y - rayNormal.position.y);
        distanceOfRay = 0.6f;
        distanceOfGround = 0.4f;

        isGround = Physics.Raycast(transform.position, -transform.up, out rayHit, distanceOfRay, lm_circuit);

        if (!isGround)
        {
            CallGravity(gravity);
        }

        ModelChange2();
        ShowRay();

        if (Input.GetKey(KeyCode.A))
        {
            Turn(-handling);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Turn(handling);
        }

        isReverse = (Input.GetKey(KeyCode.S));

        //if (isGround)
        //{
            if (Input.GetKey(KeyCode.K))
            {
                if (isReverse)
                {
                    Accellerartion(-speed);
                }
                else
                {
                    Accellerartion(speed);
                }
            }
        //}

    }

    void ShowRay()
    {
        Debug.DrawRay(transform.position, -transform.up * distanceOfGround, Color.red);
        Debug.DrawRay(transform.position, -transform.up * distanceOfRay, Color.yellow);
    }

    void ModelChange2()
    {
        if (Physics.Raycast(transform.position, -transform.up, out rayHit, distanceOfRay, lm_circuit))
        {
            Vector3 vec = rayHit.normal;
            transform.rotation = Quaternion.FromToRotation(transform.up, vec) * transform.rotation;
        }
    }

    void ModelChange()
    {
        if (Physics.Raycast(transform.position, -Vector3.up,out rayHit, distanceOfRay, lm_circuit))
        {
            Vector3 vec = rayHit.normal;
            direction.transform.rotation = Quaternion.FromToRotation(transform.up, vec) * transform.rotation;
        }
        else
        {
            direction.transform.rotation = transform.rotation;
        }

        model.transform.rotation = direction.transform.rotation;
    }

    void CallGravity(float value)
    {
        //rb.velocity = transform.up * value;
        //rb.velocity = new Vector3(rb.velocity.x, transform.up.y * value, rb.velocity.z);
        rb.AddForce(transform.up * value);
    }

    void Accellerartion(float value)
    {
        //rb.velocity = new Vector3(transform.forward.x * value, rb.velocity.y, transform.forward.z * value);
        //rb.velocity = transform.forward * value;
        rb.AddForce(transform.forward * value);
    }

    void Turn(float value)
    {
        transform.Rotate(Vector3.up, value);
        //transform.eulerAngles += transform.up * value;
        //transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + value, transform.eulerAngles.z).normalized;
    }

    void Brake(float value)
    {

    }

    void HandBrake(float value)
    {

    }

    void Nitro()
    {

    }

}
