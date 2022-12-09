using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomedInFOV;
    [SerializeField] float zoomedOutFOV;
    [SerializeField] float zoomedInSensitivity;
    [SerializeField] float zoomedOutSensitivity;

    RigidbodyFirstPersonController fpsController;

    bool zoomedIn;
    private void Start()
    {
        //fpsCamera = GetComponent<Camera>();
        zoomedIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            if (zoomedIn)
            {
                CamToggle(zoomedOutFOV, zoomedInSensitivity);
            }
            else
            {
                CamToggle(zoomedInFOV, zoomedOutSensitivity);
            }
        }
    }
    void CamToggle(float zoom, float sensitivity)
    {
        zoomedIn = !zoomedIn;
        fpsCamera.fieldOfView = zoom;
        fpsController.mouseLook.XSensitivity = sensitivity;
        fpsController.mouseLook.YSensitivity = sensitivity;
    }
}
