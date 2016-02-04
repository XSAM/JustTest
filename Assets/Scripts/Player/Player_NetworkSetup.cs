using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class Player_NetworkSetup : NetworkBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	   if(isLocalPlayer)
       {
            GetComponent<Player_Movement>().enabled = true;
        }
	}
	
}
