using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    public GvrTrackedController Controller;
    private float distance = 4f;

    void Start()
    {
        AirtableInterface.Instance.GetData();
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.ControllerInputDevice.GetButtonDown(GvrControllerButton.TouchPadButton))
        {
            Vector3 point = Controller.GetComponentInChildren<GvrLaserPointer>().transform.forward.normalized * distance;
            //Debug.Log("Click! Instantiating sphere at "+ point);
            
            AnnotationManager.Instance.NewAnnotation(point, "New Annotation \n\nPress here to enter text...");
        }

        if (Controller.ControllerInputDevice.GetButtonDown(GvrControllerButton.App))
        {
            VideoSwitcher.Instance.SwitchVideo();
        }
    }
}
