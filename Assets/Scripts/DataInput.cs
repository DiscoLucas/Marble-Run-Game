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
    /// <summary>
    /// When the UI button is clicked, isCollecting becomes true.
    /// collectionTime is subtracted by time untill it reaches 0.
    /// And then sends the data list to <see cref="CSVWriter"/>
    /// </summary>
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
                collectionTime = startCollectionTime; // Resets the CollectionTime to it's initial value
                isCollecting = false; // Stops the loop from collecting data
                CSVWriter.WriteCSV(dataInput); // sends the list of data to the CSVwriter class
                dataInput.Clear(); // Clears the list
            }
        }
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
    /// <summary>
    /// Toggles isCollecting for button click.
    /// When UI the button is clicked, the bool should become true when clicked.
    /// FixedUpdate() runs its routine when true.
    /// </summary>
    public void StartCollecting()
    {
        isCollecting = !isCollecting;
        Debug.Log("isCollecting" + isCollecting);
    }
}
