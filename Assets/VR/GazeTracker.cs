using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class GameObjectEvent: UnityEvent<GameObject> {}

public class GazeTracker : MonoBehaviour {
	public GameObjectEvent GazeHitEvent;
	public GameObjectEvent GazeTriggerHitEvent;
	
	private RaycastHit hit;

	private bool tracking = false;
	private bool triggerPressed = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(tracking) {
			Camera cam = Camera.main;
			Ray ray = cam.ViewportPointToRay(new Vector3(.5f, .5f, 0));

			if(Physics.Raycast(ray, out hit)) {
				GameObject target = hit.collider.gameObject;

				if(triggerPressed) {
					GazeTriggerHitEvent.Invoke(target);
				} else {
					GazeHitEvent.Invoke(target);
				}
			}
		}
	}

	public void TrackingChanged(bool track) {
		tracking = track;
	}

	public void TriggerPressed(bool pressed) {
		triggerPressed = pressed;
	}
}
