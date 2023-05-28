using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    int currentCameraIndex = 0;
    WebCamTexture tex;

    public RawImage display;

    public void SwamCam_Clicked()
    {
        currentCameraIndex += 1;
        currentCameraIndex %= WebCamTexture.devices.Length;
    }

    public void StartStopCam_Clicked()
    {
        if(tex != null)
        {
            display.texture = null;
            tex.Stop();
            tex = null;
        }
        else
        {
            WebCamDevice device = WebCamTexture.devices[currentCameraIndex];
            tex = new WebCamTexture(device.name);
            display.texture = tex;

            tex.Play();
        }
    }

}
