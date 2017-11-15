using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingObj1 : MonoBehaviour {

    private UDPReceive udpObject;
    private float HeartRate = 0;

    private float BeatRate = 0;
    private float Timer = 0;
    private bool ReceivedData = false;
    private bool Performed = false;
    private AudioSource source;

	// Use this for initialization
	void Start () {
        udpObject = GetComponent<UDPReceive>();
        source = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {

        HeartRate = udpObject.GetHeartRate();
        
        if (HeartRate > 0)
        {
            BeatRate =60.0f / HeartRate;
            //Debug.Log("HeartRate =" + HeartRate);
            //Debug.Log(HeartRate);
            //ReceivedData = true;
            //print("Update HR " + Timer + " BR = " + BeatRate);
        }
         
             
        //Debug.Log(BeatRate);

        if (Timer < BeatRate)
        //if (Timer < 1)
        {
            Timer += Time.deltaTime;
            //Timer += 1;
            if (!Performed)
            {
                source.Play();
                UpdateScale();
                Performed = true;
                Debug.Log("Scale");
            }
        }
        else
        {
            Timer = 0;
            ReceivedData = false;
            Performed = false;
            Debug.Log("Reset");
            //ResetScale();
        }

        //BeatRate = 0.5f;

        //if (Timer < 1)
        //{
        //    Timer += Time.deltaTime;
        //    if(!Performed)
        //        UpdateScale();
        //    Performed = true;
        //}
        //else
        //{
        //    Timer = 0;
        //    //ResetScale();
        //    Performed = false;
        //}


    }

    private void ResetScale()
    {
        float Scale = 1f;
        Vector3 Sc3 = new Vector3(Scale, Scale, Scale);

        //iTween.ScaleBy(gameObject, Sc3, BeatRate/2);
        iTween.PunchScale(gameObject, Sc3, 0.5f);
    }

    private void UpdateScale()
    {
        float Scale = 1.5f;
        Vector3 Sc3 = new Vector3(Scale, Scale, Scale);

        iTween.PunchScale(gameObject, Sc3, 0.5f);
        //iTween.PunchScale(gameObject, Sc3, BeatRate / 2);
        //iTween.PunchScale(gameObject, Sc3, 0.5f);
    }
}
