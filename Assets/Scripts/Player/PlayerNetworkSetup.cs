using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	   if(isLocalPlayer)
       {
            GetComponent<PlayerMovement>().enabled = true;
        }
	}
	
}
