using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRRig : MonoBehaviour {
	public GameObject AndroidRig = null;
	public GameObject SimulatorRig = null;

	private bool tracking = false;

	// Use this for initialization
	void Start () {
		SimulatorRig.SetActive(false);
		AndroidRig.SetActive(false);

		if(Application.isEditor) {
			SimulatorRig.SetActive(true);
		} else if(Application.platform == RuntimePlatform.Android) {
			AndroidRig.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(tracking) {

		}
	}

	public void TrackingChanged(bool track) {
		tracking = track;
	}
}
