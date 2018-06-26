using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform lookAt;
    public Vector3 startOffset;

	// Use this for initialization
	void Start () {

        lookAt=GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = lookAt.position + startOffset;
		
	}
}
