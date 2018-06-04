using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flicker : MonoBehaviour {

	private Light myLight;

	// Use this for initialization
	void Start () 
	{
		myLight = gameObject.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		myLight.intensity = Random.Range(0.95f, 1.0f);
	}
}
