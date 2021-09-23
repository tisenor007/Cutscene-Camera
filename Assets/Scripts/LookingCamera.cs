using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum CAMERASTYLE
{
    REGULARSHOT,
    ZOOMINSHOT,
    ROTATINGSHOT
}
public class LookingCamera : MonoBehaviour
{ 
    public GameObject target;
    public GameObject dolly;
    private Vector3 originPos;
    private Quaternion originRotation;
    private CAMERASTYLE cameraStyle;
    private int selectedCameraStyle;
    // Start is called before the first frame update
    void Start()
    {
        originPos = dolly.transform.position;
        originRotation = dolly.transform.localRotation;
        selectedCameraStyle = 1;
        cameraStyle = CAMERASTYLE.REGULARSHOT;
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraStyle == CAMERASTYLE.REGULARSHOT)
        {
            transform.LookAt(target.transform);
            dolly.transform.Translate(1 * Time.deltaTime, 0f, 0f);
        }
        else if (cameraStyle == CAMERASTYLE.ZOOMINSHOT)
        {
            dolly.transform.LookAt(target.transform);
            transform.LookAt(target.transform);
            dolly.transform.Translate(0f, 0f, 1 * Time.deltaTime);
        }
        else if (cameraStyle == CAMERASTYLE.ROTATINGSHOT)
        {
            transform.LookAt(target.transform);
            transform.Translate(1 * Time.deltaTime, 0f, 0f);
            
        }
    }
    public void SwitchStyle()
    {
        selectedCameraStyle++;
        if (selectedCameraStyle > 3)
        {
            selectedCameraStyle = 1;
        }
        if (selectedCameraStyle == 1)
        {
            dolly.transform.position = originPos;
            transform.position = originPos;
            dolly.transform.rotation = originRotation;
            transform.rotation = originRotation;
            cameraStyle = CAMERASTYLE.REGULARSHOT;
        }
        else if (selectedCameraStyle == 2)
        {
            dolly.transform.position = originPos;
            transform.position = originPos;
            dolly.transform.rotation = originRotation;
            transform.rotation = originRotation;
            cameraStyle = CAMERASTYLE.ZOOMINSHOT;
        }
        else if (selectedCameraStyle == 3)
        {
            dolly.transform.position = originPos;
            transform.position = originPos;
            dolly.transform.rotation = originRotation;
            transform.rotation = originRotation;
            cameraStyle = CAMERASTYLE.ROTATINGSHOT;
        }
    }
}
