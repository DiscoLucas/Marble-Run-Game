using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInput : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
