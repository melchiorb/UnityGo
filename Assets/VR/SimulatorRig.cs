using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class BoolEvent: UnityEvent<bool> {}

public class SimulatorRig : MonoBehaviour {
	public Camera cam;
	public GameObject gaze;

	public float speedH = 4.0f;
	public float speedV = 4.0f;

	private float yaw = 0.0f;
	private float pitch = 0.0f;

	private bool trackCamera = false;
	public BoolEvent trackEvent;

	private bool triggerPressed = false;
	public BoolEvent triggerEvent;

	// Use this for initialization
	void Start () {
		gaze.SetActive(trackCamera);

		trackEvent.Invoke(trackCamera);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.LeftAlt)) {
			trackCamera = !trackCamera;

			gaze.SetActive(trackCamera);

			trackEvent.Invoke(trackCamera);
		}
		
		if(Input.GetMouseButtonDown(0)) {
			triggerPressed = true;
			triggerEvent.Invoke(triggerPressed);
		} else if(Input.GetMouseButtonUp(0)) {
			triggerPressed = false;
			triggerEvent.Invoke(triggerPressed);
		}

		if(trackCamera) {
			yaw += speedH * Input.GetAxis("Mouse X");
			pitch -= speedV * Input.GetAxis("Mouse Y");

			cam.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
		}
	}
}
