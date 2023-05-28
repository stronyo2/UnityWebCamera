using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    int currentCameraIndex = 0;
    WebCamTexture tex;

    public RawImage display;

    public Text StartStopText;

    public void OnClickCameraSwitch()
    {
        currentCameraIndex += 1;
        currentCameraIndex %= WebCamTexture.devices.Length;

        if (tex != null)//start camera
        {
            StopWebcam();
            OnClickCameraOn();
        }
    }

    public void OnClickCameraOn()
    {
        if(tex != null)//start camera
        {
            StopWebcam();

            StartStopText.text = "Start Camera";
        }
        else//stop camera
        {
            WebCamDevice device = WebCamTexture.devices[currentCameraIndex];
            tex = new WebCamTexture(device.name);
            display.texture = tex;

            tex.Play();

            StartStopText.text = "Stop Camera";
        }
    }

    private void StopWebcam()
    {
        display.texture = null;
        tex.Stop();
        tex = null;
    }

}
