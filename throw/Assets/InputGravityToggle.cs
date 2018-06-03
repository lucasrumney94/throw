using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputGravityToggle : MonoBehaviour {
	
	public GlowBallSpawner glowSpawner;

	private SteamVR_TrackedObject trackedObject;
	
	private SteamVR_Controller.Device Controller
	{
		get { return SteamVR_Controller.Input((int)trackedObject.index); }
	}
	
	void Awake()
	{
		trackedObject = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// 4
		if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
		{
			glowSpawner.GravityOn();
		}

		// 5
		if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
		{
			glowSpawner.GravityOff();
		}
	}
}
