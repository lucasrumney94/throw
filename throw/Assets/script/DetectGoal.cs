using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectGoal : MonoBehaviour 
{

	public GameObject TaskComplete;
	public GameObject player;
	public GameObject AgileMasterSprite;

	private int numberOfObjectsTossed = 0;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Ball"))
		{
			Debug.Log("Goal!");
			GameObject g = GameObject.Instantiate(TaskComplete, transform.position, Quaternion.identity) as GameObject;
			Vector3 lookHere = new Vector3(player.transform.position.x, 0.0f, player.transform.position.z);
			g.transform.LookAt(lookHere);
			Destroy(other.gameObject);
			numberOfObjectsTossed++;

			if (numberOfObjectsTossed == 8)
			{
				g = GameObject.Instantiate(AgileMasterSprite, transform.position+Vector3.up, Quaternion.identity) as GameObject;
				g.transform.LookAt(player.transform.position);
			}

		}
	}
}
