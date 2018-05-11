using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlataformController2 : MonoBehaviour {

    public Rigidbody rb;

    public RayCaster rayLeft, rayRight;
    public RayCaster rayCenter, rayCenterJump;
    public RayCaster rayFront, backFront;

    public GameObject moveDir;

    public float walk, jump;
    public float gravity;

    bool isRight;
    float flipValue;

    [Header("Ground Info")]
    public bool isGround;

    // Use this for initialization
    void Start()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Incline"));
    }

    private void Update()
    {

        //MakeFlip();

        isGround = (rayLeft.isCheck || rayRight.isCheck);

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (rayCenterJump.isCheck || isGround)
            {
                rb.AddForce(Vector3.up * jump * Time.fixedDeltaTime, ForceMode.VelocityChange);
            }
        }

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    isRight = true;
        //}

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    isRight = false;
        //}

        //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        //{
        //    rb.AddForce(transform.right * walk * Time.fixedDeltaTime, ForceMode.Acceleration);
        //}

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(moveDir.transform.right * walk * Time.fixedDeltaTime, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-moveDir.transform.right * walk * Time.fixedDeltaTime, ForceMode.Acceleration);
        }

        if (!isGround && !rayCenter.isCheck)// || !rayFront.isCheck)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y - gravity * Time.fixedDeltaTime, rb.velocity.z);
        }

        if (rayFront.isCheck || backFront.isCheck)
        {
            moveDir.transform.rotation = Quaternion.FromToRotation(Vector3.up, rayCenter.getRayHit().normal);
        }
        else
        {
            moveDir.transform.rotation = Quaternion.identity;
        }

        if (rayLeft.isCheck || rayRight.isCheck)
        {
            //girar o corpo para o normal 
        }


        //else if (!rayCenter.isCheck && rayCenterJump){
        //    Debug.Log("vish");
        //    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y - gravity * 20 *  Time.fixedDeltaTime, rb.velocity.z);
        //}

        if (rayFront.isCheck)
        {

        }

    }

    public void MakeFlip()
    {
        flipValue = (isRight) ? 0 : 180;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, flipValue, transform.eulerAngles.z);
    }

}
