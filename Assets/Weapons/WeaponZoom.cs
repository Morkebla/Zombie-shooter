using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    bool zoomedInView = false;
    [SerializeField]float zoom = 30f;
    [SerializeField]float zoomOut = 60f;
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = 0.5f;

    Camera FPSCamera;
    RigidbodyFirstPersonController FPScontroler;

    private void OnDisable()
    {
        ZoomOut();
    }

    private void Start()
    {
        FPScontroler = GetComponentInParent<RigidbodyFirstPersonController>();
        FPSCamera = Camera.main;
    }
    private void Update()
    {
        WeaponZoomIn();
    }
    private void WeaponZoomIn()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInView == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomIn()
    {
        zoomedInView = true;
        FPSCamera.fieldOfView = zoom;
        FPScontroler.mouseLook.XSensitivity = zoomInSensitivity;
        FPScontroler.mouseLook.YSensitivity = zoomInSensitivity;
    }

    private void ZoomOut()
    {
        zoomedInView = false;
        FPSCamera.fieldOfView = zoomOut;
        FPScontroler.mouseLook.XSensitivity = zoomOutSensitivity;
        FPScontroler.mouseLook.YSensitivity = zoomOutSensitivity;
    }
}
