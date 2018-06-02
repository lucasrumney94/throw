using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectGoal : MonoBehaviour 
{

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Ball"))
		{
			Debug.Log("Basket Made!");
			Vector3 newPosition = 3*Random.insideUnitSphere;
			newPosition.y = 0.1f;
			transform.parent.position = newPosition;
			other.transform.position = Vector3.up;
		}
	}
}
