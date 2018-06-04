using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class makeLightChangeToMyColor : MonoBehaviour {


	public GameObject lightToChange;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		lightToChange.GetComponent<Light>().color = gameObject.GetComponent<Renderer>().material.color;
	}
}
