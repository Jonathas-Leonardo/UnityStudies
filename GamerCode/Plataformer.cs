using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataformer : MonoBehaviour {

    public Player playerAttr;
    public float gravity;
    public float timeJump;
    public float subtime;

    public Transform bottomCheck, frontCheck, rayNormalCheck, direction;
    public LayerMask lm_solid, lm_incline;

    public bool isGround, isIncline, isWall;
    public bool isWalkRight, isWalkLeft;
    public bool isJump, canJump;

    Rigidbody rb;
    RaycastHit hitBottom, hitFront, hitNormal;
    float rayLenght = .65f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(bottomCheck.position, bottomCheck.localScale);
        Gizmos.DrawRay(bottomCheck.position, -transform.up * rayLenght);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(frontCheck.position, frontCheck.localScale);
        Gizmos.DrawRay(frontCheck.position, frontCheck.right * rayLenght);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(rayNormalCheck.position, -rayNormalCheck.up * .8f);
    }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        canJump = true;
	}
	
	// Update is called once per frame
	void Update () {

        isIncline = (Physics.Raycast(rayNormalCheck.position, -Vector3.up, out hitNormal, .8f, lm_incline));
        isGround = (Physics.BoxCast(bottomCheck.position, bottomCheck.transform.localScale, -Vector3.up, out hitBottom, Quaternion.identity, rayLenght, lm_solid));
        isWall = (Physics.BoxCast(frontCheck.position, frontCheck.transform.localScale, frontCheck.right, out hitFront, Quaternion.identity, rayLenght, lm_solid));

        isWalkRight = (Input.GetKey(KeyCode.D) && !isWalkLeft);
        isWalkLeft = (Input.GetKey(KeyCode.A) && !isWalkRight);

        if (isIncline)
        {
            Vector3 vec = hitNormal.normal;
            direction.rotation = Quaternion.FromToRotation(Vector3.up, hitNormal.normal);
        }
        else
        {
            direction.rotation = Quaternion.identity;
        }

        if (isWall)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
            transform.position = new Vector3(hitFront.point.x - (.55f * frontCheck.right.x), transform.position.y, transform.position.z);
        }

        if (isGround)
        {
            if (direction.rotation == Quaternion.identity)// && rb.velocity.y<0)
            {
                transform.position = new Vector3(transform.position.x, hitBottom.point.y + 1.05f, transform.position.z);
            }
        }

        if(isGround || isIncline) {

            if (Input.GetKeyDown(KeyCode.S) && canJump)
            {
                isJump = true;
                canJump = false;
                timeJump = playerAttr.jump;
            }
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            isJump = false;
            canJump = true;
        }

    }

    private void FixedUpdate()
    {
        if (isWalkRight)
        {
            if (!isWall)
            {
                WalkRight();
            }
            frontCheck.eulerAngles = new Vector3(frontCheck.rotation.x, 0, frontCheck.rotation.z);
        }

        if (isWalkLeft)
        {
            if (!isWall)
            {
                WalkLeft();
            }
            frontCheck.eulerAngles = new Vector3(frontCheck.rotation.x, 180, frontCheck.rotation.z);
        }

        if (!isGround && !isIncline)
        {
           CallGravity();
        }

        if (isJump)
        {
            Jump();
        }

    }

    void TakeDamage()
    {
        playerAttr.health--;
    }

    bool CheckIsLive()
    {
        return (playerAttr.health <= 0);
    }

    void CallGravity()
    {
        rb.AddForce(Vector3.up * gravity, ForceMode.VelocityChange);
    }

    void WalkLeft()
    {
        rb.AddForce(-direction.right * playerAttr.speed, ForceMode.VelocityChange);
    }

    void WalkRight()
    {
        rb.AddForce(direction.right * playerAttr.speed, ForceMode.VelocityChange);
    }

    void Jump()
    {
        if (timeJump > 0)
        {
            timeJump -= subtime;
        }
        else
        {
            timeJump = 0;
        }
        rb.AddForce(Vector3.up * timeJump, ForceMode.VelocityChange);
    }

}
