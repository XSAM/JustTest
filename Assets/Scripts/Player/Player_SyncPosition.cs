using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class Player_SyncPosition : NetworkBehaviour 
{
    [SyncVarAttribute]private Vector3 syncPosition;
    [SyncVarAttribute]private Quaternion syncRotate;

    [SerializeField]
    private float lerpRate = 15f;

    // Update is called once per frame
    void FixedUpdate () 
	{
        TransmitPosition();
        LerpPosition();
    }
    
    void LerpPosition()
    {
        if(!isLocalPlayer)
        {
            transform.position = Vector3.Lerp(transform.position, syncPosition, lerpRate * Time.deltaTime);
            transform.rotation=syncRotate;
        }
    }

    [CommandAttribute]
    void CmdProvidePositionToServer(Vector3 position,Quaternion rotate)
    {
        syncPosition = position;
        syncRotate = rotate;
    }
    
    [ClientAttribute]
    void TransmitPosition()
    {
        if(isLocalPlayer)
        {
            //Debug.Log(transform.position);
            CmdProvidePositionToServer(transform.position,transform.rotation);
        }
    }
}
