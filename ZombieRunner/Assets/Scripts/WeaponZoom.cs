using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomedInFOV;
    [SerializeField] float zoomedOutFOV;

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
                CamToggle(zoomedOutFOV);
            }
            else
            {
                CamToggle(zoomedInFOV);
            }
        }
    }
    void CamToggle(float zoom)
    {
        zoomedIn = !zoomedIn;
        fpsCamera.fieldOfView = zoom;
    }
}
