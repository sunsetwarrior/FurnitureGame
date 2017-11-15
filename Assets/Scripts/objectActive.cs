using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using VRTK.Examples;

[RequireComponent(typeof(PhotonView))]
public class objectActive : Photon.MonoBehaviour
{
    public GameObject spawn;
    public GameObject thisObject;
    private static GameObject currentObject;

    public void CLicked()
    {
        //if (this.photonView.ownerId == PhotonNetwork.player.ID)
        //{
        //    Debug.Log("Not requesting ownership. Already mine.");
        //    return;
        //}

        //this.photonView.RequestOwnership();
        this.photonView.RPC("DestroyImage", PhotonTargets.AllBufferedViaServer, false);

        //only one furniture can be select at one time
        //the first one will set to immovable
        if (currentObject != null)
        {
            this.photonView.RPC("SetImmovable", PhotonTargets.AllBufferedViaServer, currentObject.name);
        }
        currentObject = PhotonNetwork.Instantiate(thisObject.name, spawn.transform.position, thisObject.transform.rotation, 0);
        this.photonView.RPC("DeleteGrab", PhotonTargets.AllBufferedViaServer, currentObject.name);

    }

    [PunRPC]
    public void DestroyImage(bool destroy)
    {
        gameObject.SetActive(destroy);
    }

    [PunRPC]
    public void SetImmovable(string thisName)
    {
        Destroy(GameObject.Find(thisName).GetComponent<VRTK.VRTK_InteractableObject>());
        Destroy(GameObject.Find(thisName).GetComponent<Rigidbody>());
    }

    [PunRPC]
    public void DeleteGrab(string thisName)
    {
        Debug.Log(GameObject.Find(thisName).GetPhotonView().ownerId);
        Debug.Log(PhotonNetwork.player.ID);
        if (GameObject.Find(thisName).GetPhotonView().ownerId != PhotonNetwork.player.ID)
        {
            Destroy(GameObject.Find(thisName).GetComponent<VRTK.VRTK_InteractableObject>());
            Destroy(GameObject.Find(thisName).GetComponent<Rigidbody>());
        }
    }
}
