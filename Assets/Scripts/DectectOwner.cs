using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DectectOwner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
