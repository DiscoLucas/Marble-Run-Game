using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInput : MonoBehaviour
{
    [Header("List for data input")]
    public List<string> dataInput = new List<string>();

    [Header("Data collection setup")]
    public float collectionTime = 5f;
    public bool isCollecting;
    public float startCollectionTime;

    public CSVWriter CSVWriter;

    /// <summary>
    /// Checks if the system has a gyroscope and enables it if it does.
    /// Also sets startCollectionTime value to collectionTime, for timer later.
    /// </summary>
    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
            startCollectionTime = collectionTime;
        }
    }

    void FixedUpdate()
    {
        if (isCollecting == true)
        {
            if (collectionTime > 0)
            {
                collectionTime = collectionTime - Time.fixedDeltaTime;
                DataCollection();
            }
            else
            {
                collectionTime = startCollectionTime;
                isCollecting = false;
                CSVWriter.WriteCSV(dataInput);
                dataInput.Clear();
            }
        }
        //Debug.Log(Input.gyro.rotationRateUnbiased);
    }

    /// <summary>
    /// Converts gyro input to a string, for easier CSV writing.
    /// </summary>
    public void DataCollection()
    {
        string x = Input.gyro.rotationRateUnbiased.x.ToString();
        string y = Input.gyro.rotationRateUnbiased.y.ToString();
        string z = Input.gyro.rotationRateUnbiased.z.ToString();
        string output = x + "," + y + "," + z;

        dataInput.Add(output);
    }

    public void StartCollecting()
    {
        isCollecting = !isCollecting;
        Debug.Log("isCollecting" + isCollecting);
    }
}
