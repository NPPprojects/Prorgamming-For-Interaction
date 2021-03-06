﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

    public float facingAngle = 0;
    float x = 0;
    float z = 0;
    Vector2 unitV2;
    public GameObject camera;
    float distanceToCamera = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        x = Input.GetAxis("Horizontal") * Time.deltaTime * -100;
        z = Input.GetAxis("Vertical") * Time.deltaTime * 500;

        facingAngle += x;
        unitV2 = new Vector2(Mathf.Cos(facingAngle * Mathf.Deg2Rad), Mathf.Sin(facingAngle * Mathf.Deg2Rad));
	}


    private void FixedUpdate()
    {
        this.transform.GetComponent<Rigidbody>().AddForce(new Vector3(unitV2.x, 0, unitV2.y) * z * 3);
        
        camera.transform.position = new Vector3(-unitV2.x * distanceToCamera, distanceToCamera, -unitV2.y * distanceToCamera) + this.transform.position;
    }
}
