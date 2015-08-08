using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public string name;
	public bool useMainCamera = true;

	// Use this for initialization
	void Start () 
	{
		if (useMainCamera)
			gameObject.GetComponent<Canvas>().worldCamera = Camera.main;
	}
	
	// Update is called once per frame
}
