﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll : MonoBehaviour {

    [Header("Settings")]
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
    public float panSpeed = 30f;
    public float panBoarderThickness = 10f;
    private bool doMovement = true;

    private float minZ = -70f, maxZ = 60f;
    private float minX = -70f, maxX = 60f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement;

        if (!doMovement)
            return;  

        if (Input.mousePosition.y >= Screen.height - panBoarderThickness && transform.position.z <= maxZ)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.mousePosition.y <= panBoarderThickness && transform.position.z >= minZ)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.mousePosition.x >= Screen.width - panBoarderThickness && transform.position.x <= maxX)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.mousePosition.x <= panBoarderThickness && transform.position.x >= minX)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
