using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 180f;
    public float jumpSpeed = 5f;


    private new Rigidbody rigidbody;
    private float movementValue;
    private float turnValue;

    //private Vector3 movement;
    private Quaternion turn;
    private bool isFirstMove = true;
    private float firstTime = 100f;
    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform.position = new Vector3(5f, 1f, 0f);
        transform.Rotate(new Vector3(0f, 160f, 0f));
    }

    void Update()
    {
        movementValue = Input.GetAxis("Vertical");
        turnValue = Input.GetAxis("Horizontal");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Turn();
        Jump();
    }

    void Move()
    {
        Vector3 zeroTemp = new Vector3(0f, 0f, 0f);
        Vector3 movement = transform.forward * movementValue * moveSpeed * Time.deltaTime;
        //模拟50ms网络延迟不加优化的行走状态
        if (isFirstMove && movement != zeroTemp)
        {
            firstTime = Time.realtimeSinceStartup;
            isFirstMove = false;
        }
        if (firstTime + 0.1f <= Time.realtimeSinceStartup)
        {
            //Debug.Log("DelayTime:" + (Time.realtimeSinceStartup - firstTime));
            //Debug.Log("FirstTime:"+firstTime);
            rigidbody.MovePosition(rigidbody.position + movement);
            isFirstMove = true;
            firstTime = 2000f;
            
        }

    }

    void Turn()
    {
        turn = Quaternion.Euler(new Vector3(0f, turnValue, 0f) * turnSpeed * Time.deltaTime);

        rigidbody.MoveRotation(rigidbody.rotation * turn);
    }

    void Jump()
    {
        if (Input.GetButton("Jump"))
        {
            rigidbody.velocity = transform.up * jumpSpeed;
        }
    }
}
