using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;


//code base / instructions from https://thomasfredericks.github.io/UnityOSC/
public class ReceiveOsc : MonoBehaviour
{

    float xPosVal, yPosVal, ampVal;


    public OSC osc;
    // Start is called before the first frame update
    void Start()
    {
        osc.SetAddressHandler("/XPos", OnRecieveXPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnRecieveXPos(OscMessage msg)
    {
        xPosVal= msg.GetFloat(0);
        Vector3 position = transform.position;

        position.x = xPosVal;

        transform.position = position;

    }

    public float getX()
    {
        return xPosVal;
    }
    public float getY() { return yPosVal; }
    public float getAmp() { return ampVal; }

    
}
