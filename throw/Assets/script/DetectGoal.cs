using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectGoal : MonoBehaviour 
{

	public GameObject TaskComplete;
	public GameObject player;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Ball"))
		{
			Debug.Log("Goal!");
			GameObject g = GameObject.Instantiate(TaskComplete, transform.position, Quaternion.identity) as GameObject;
			Vector3 lookHere = new Vector3(player.transform.position.x, 0.0f, player.transform.position.z);
			g.transform.LookAt(lookHere);
			Destroy(other.gameObject);
		}
	}
}
