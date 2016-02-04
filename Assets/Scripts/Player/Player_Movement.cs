using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_Movement : MonoBehaviour 
{
    public float moveSpeed =10f;
    public float turnSpeed = 180f;
    public float jumpSpeed = 5f;


    private new Rigidbody rigidbody;
    private float movementValue;
    private float turnValue;

    //private Vector3 movement;
    private Quaternion turn;
    // Use this for initialization
    void Start () 
	{
        rigidbody = GetComponent<Rigidbody>();
        transform.position=new Vector3(5f, 1f, 0f);
        transform.Rotate(new Vector3(0f, 160f, 0f));
    }
    
    void Update()
    {
        movementValue = Input.GetAxis("Vertical");
        turnValue = Input.GetAxis("Horizontal");
    }
	
	// Update is called once per frame
	void FixedUpdate () 
	{
        Move();
        Turn();
        Jump();
    }
    
    void Move()
    {
        Vector3 movement = transform.forward * movementValue * moveSpeed * Time.deltaTime;
        rigidbody.MovePosition(rigidbody.position + movement);
    }
    
    void Turn()
    {
        turn = Quaternion.Euler(new Vector3(0f, turnValue, 0f) * turnSpeed * Time.deltaTime);
        
        rigidbody.MoveRotation(rigidbody.rotation * turn);
    }
    
    void Jump()
    {
        if(Input.GetButton("Jump"))
        {
            rigidbody.velocity = transform.up * jumpSpeed;
        }
    }
}
