using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimScript : MonoBehaviour
{
    private bool zooming;
    public float zoomAmount;
    private float defaultFov;
    public GameObject crosshair;

    // Start is called before the first frame update
    void Start()
    {
        defaultFov = Camera.main.GetComponent<Camera>().fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            zooming = true;
            crosshair.SetActive(true);
        }
        else
        {
            zooming = false;
            crosshair.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        // Zoom in
        if (zooming && Camera.main.GetComponent<Camera>().fieldOfView > zoomAmount)
        {
            Camera.main.GetComponent<Camera>().fieldOfView -= 1;

        }

        if (zooming && Camera.main.GetComponent<Camera>().fieldOfView == zoomAmount)
        {
            zooming = false;
        }

        // Zoom out
        if (zooming == false && Camera.main.GetComponent<Camera>().fieldOfView < defaultFov)
        {
            Camera.main.GetComponent<Camera>().fieldOfView += 1;
        }
    }
}
