﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomController : MonoBehaviour
{

    private Camera cam;
    private float targetZoom;
    private float zoomFactor = 3f;
    private float zoomLerpSpeed = 10f;
    private float yVelocity = 0.0f;


    // Start is called before the first frame update
    private void Start()
    {
        cam = Camera.main;
        targetZoom = cam.orthographicSize;
    }

    // Update is called once per frame
    private void Update()
    {
        float scrollData;
        scrollData = Input.GetAxis("Mouse ScrollWheel");
        targetZoom -= scrollData * zoomFactor;
        targetZoom = Mathf.Clamp(targetZoom, 7f, 9f);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, targetZoom, ref yVelocity, Time.deltaTime * zoomLerpSpeed);
    }
}
