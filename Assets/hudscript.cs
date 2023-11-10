using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class hudscript : MonoBehaviour
{
	NetworkManager manager;
	void Start()
    {
		manager = GetComponent<NetworkManager>();
	}

	
	public void st()
	{
	  manager.StartHost();
		
	}
	
}
