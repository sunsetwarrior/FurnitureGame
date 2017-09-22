using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using VRTK.Examples;

public class objectActive : MonoBehaviour {
    bool isClicked = false;

	public GameObject rightController;
	public GameObject spawn;
	public GameObject thisObject;

	// Use this for initialization
	void Start () {

    }

	public void EnterP(){
		spawn = GameObject.Find ("SpawnPoint");
		if (spawn == null) {
			Debug.Log ("not found .........................................................");
		}

		if(isClicked == false){
			PhotonNetwork.Instantiate (name, spawn.transform.position, spawn.transform.rotation, 0);
		}

	}

	public void ExitP(){
		if (isClicked == false) {
			PhotonNetwork.Destroy (gameObject);
		}
	}

    public void CLicked()
    {
		PhotonNetwork.Instantiate (thisObject.name, spawn.transform.position, spawn.transform.rotation, 0);
		isClicked = true;
		rightController.GetComponent<RC_Car_Controller> ().rcCar = thisObject;
		gameObject.SetActive (false);
    }

	public void Test(){
		GameObject go = PhotonNetwork.Instantiate (thisObject.name, spawn.transform.position, spawn.transform.rotation, 0);
		isClicked = true;
		rightController.GetComponent<RC_Car_Controller> ().rcCar = go;
	}

}
