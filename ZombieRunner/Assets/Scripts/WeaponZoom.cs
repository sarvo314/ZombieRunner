using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomedInFOV;
    [SerializeField] float zoomedOutFOV = 62f;
    [SerializeField] float zoomedInSensitivity;
    [SerializeField] float zoomedOutSensitivity = 23f;

    RigidbodyFirstPersonController fpsController;

    public static bool zoomedIn;

    private void Start()
    {
        //fpsCamera = GetComponent<Camera>();
        fpsController = FindObjectOfType<RigidbodyFirstPersonController>();
        zoomedIn = false;

        //zoomedOutFOV = 62f;
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
    public void CamToggle(float zoom = 92f, float sensitivity = 5.7f)
    {
        zoomedIn = !zoomedIn;
        fpsCamera.fieldOfView = zoom;
        fpsController.mouseLook.XSensitivity = sensitivity;
        fpsController.mouseLook.YSensitivity = sensitivity;
    }
}
