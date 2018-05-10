using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_RotateSkyBox : MonoBehaviour {

    public float rotateSpeed;
	
	// Update is called once per frame
	void Update () {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotateSpeed);
	}
}
