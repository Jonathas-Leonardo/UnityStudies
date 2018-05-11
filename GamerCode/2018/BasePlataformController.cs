using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlataformController : MonoBehaviour {

    public Rigidbody rb;
    public GameObject moveDir;

    public RayCaster rayLeft, rayRight;
    public RayCaster rayCenter, rayCenterJump;
    public RayCaster rayFront, backFront;   

    public float walk, jump;
    public float gravity;

    [Header("Ground Info")]
    public bool isGround;

    // Use this for initialization
    void Start()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Incline"));
    }

    private void Update()
    {

        isGround = (rayLeft.isCheck || rayRight.isCheck);

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (rayCenterJump.isCheck || isGround)
            {
                rb.AddForce(Vector3.up * jump * Time.fixedDeltaTime, ForceMode.VelocityChange);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(moveDir.transform.right * walk * Time.fixedDeltaTime, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-moveDir.transform.right * walk * Time.fixedDeltaTime, ForceMode.Acceleration);
        }

        if (!isGround && !rayCenter.isCheck)
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
    }

}
