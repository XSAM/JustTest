using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class Player_SyncPosition : NetworkBehaviour 
{
    [SyncVarAttribute]private Vector3 syncPosition;

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
            transform.position = Vector3.Lerp(transform.position, syncPosition, lerpRate + Time.deltaTime);
        }
    }
    
    [CommandAttribute]
    void CmdProvidePositionToServer(Vector3 position)
    {
        syncPosition = position;
    }
    
    [ClientCallbackAttribute]
    void TransmitPosition()
    {
        if(isLocalPlayer)
        {
            CmdProvidePositionToServer(transform.position);
        }
    }
}
