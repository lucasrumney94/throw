using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabObject : MonoBehaviour {

	private SteamVR_TrackedObject trackedObject;
	
	private SteamVR_Controller.Device Controller
	{
		get { return SteamVR_Controller.Input((int)trackedObject.index); }
	}
	
	private GameObject collidingObject;

	private GameObject objectInHand;

	void Awake()
	{
		trackedObject = GetComponent<SteamVR_TrackedObject>();
	}
	
	private void SetCollidingObject (Collider col)
	{
		// if the player is already holding something, or the object has no rigidbody then just return
		if (collidingObject || !col.GetComponent<Rigidbody>())
		{
			return;
		}

		collidingObject = col.gameObject;
	}

	private void OnTriggerEnter(Collider other)
	{
		SetCollidingObject(other);
	}

	private void OnTriggerStay(Collider other)
	{
		SetCollidingObject(other);
	}

	private void OnTriggerExit(Collider other)
	{
		if (!collidingObject)
		{
			return;
		}

		collidingObject = null;
	}

	private void GrabObject()
	{
		objectInHand = collidingObject;
		collidingObject = null;

		var joint = AddFixedJoint();
		joint.connectedBody = objectInHand.GetComponent<Rigidbody>();

	}

	private FixedJoint AddFixedJoint()
	{
		FixedJoint fx = gameObject.AddComponent<FixedJoint>();
		fx.breakForce = 20000;
		fx.breakTorque = 20000;
		return fx;
	}

	private void ReleaseObject()
	{
		if (GetComponent<FixedJoint>())
		{
			GetComponent<FixedJoint>().connectedBody = null;
			Destroy(GetComponent<FixedJoint>());

			objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
			objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
		}

		objectInHand = null;
	}


	void Update () 
	{
		if (Controller.GetHairTriggerDown())
		{
			if (collidingObject)
			{
				GrabObject();
			}
		}

		if (Controller.GetHairTriggerUp())
		{
			if (objectInHand)
			{
				ReleaseObject();
			}
		}
	}
}
