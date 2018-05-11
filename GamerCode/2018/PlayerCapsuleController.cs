using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCapsuleController : MonoBehaviour {

    Rigidbody rb;
    RaycastHit hitGround;

    public float walk;
    public float dash;

    public bool isWalk;
    public bool isGround;

    public float currentTime;
    public float dashTime;

    public LayerMask layerSolid;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentTime = 0;
        isWalk = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();

        if (!isGround)
        {
            CallGravity();
        }

        if (isWalk)
        {
            DoWalk();
            if (currentTime > Time.time)
            {
                DoDash();
            }
        }
    }

    public void DoDash()
    {
        Vector3 vec = new Vector3(transform.forward.x * dash * Time.fixedDeltaTime, rb.velocity.y, transform.forward.z * dash * Time.fixedDeltaTime);
        rb.AddForce(vec, ForceMode.VelocityChange);
    }

    public void DoWalk()
    {
        rb.velocity = new Vector3(transform.forward.x * walk * Time.fixedDeltaTime, rb.velocity.y, transform.forward.z * walk * Time.fixedDeltaTime);
    }

    public void SetCurrentTime()
    {
        currentTime = Time.time + dashTime;
    }

    public void StopVelocity()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
    }

    public void CheckGround()
    {
        isGround = Physics.SphereCast(transform.position, .7f, -Vector3.up, out hitGround, .4f, layerSolid);
        //Debug.DrawRay(transform.position - new Vector3(0,.7f, 0), -Vector3.up*.4f,Color.blue, .1f);
    }

    public void CallGravity()
    {
        rb.velocity -= Vector3.up * -Physics.gravity.y * Time.fixedDeltaTime;
    }

    public void RotateToTarget(Vector3 target)
    {
        Vector3 relativePos = target - transform.position;
        Quaternion rot = Quaternion.LookRotation(relativePos);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Target")
        {
            isWalk = false;
            StopVelocity();
        }
    }
}
