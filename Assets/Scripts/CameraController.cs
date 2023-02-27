using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.UIElements;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private Vector3 offset;
    [SerializeField] private float zoomSpeed = 10f;
    [SerializeField] private float minZoom = 5f;
    [SerializeField] private float maxZoom = 10f;
    [SerializeField] private float pitch = 2f;
    [SerializeField] private float yawSpeed = 100f;
    

    private float _currentZoom = 10f;
    private float _currentYaw = 0f;
    // Start is called before the first frame update
    void Update()
    {
       _currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
       _currentZoom = Mathf.Clamp(_currentZoom, minZoom, maxZoom);
       _currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position - offset * _currentZoom;
        transform.LookAt(target.position + Vector3.up*pitch);
        transform.RotateAround(target.position + Vector3.up,_currentYaw);
    }
}
