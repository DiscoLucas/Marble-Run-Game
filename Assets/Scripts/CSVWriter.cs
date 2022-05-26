using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;
using UnityEngine.InputSystem;

// I AM THE CLINT EASTWOOD IF WRITING SPAGHETTI CODE!

public class CSVWriter : MonoBehaviour
{
    public string filename = "";
    public Button startButton;
    
    [Tooltip("Amount of time that data will be recorded for, in seconds")]
    public int collectionTime = 5;
    [Tooltip("Amount of time between each sample recorded, in miliseconds")]
    public int collectionInterval = 20;

    [System.Serializable]
    public class Data
    {
        public string name;
        //public int xAxis;
        //public int yAxis;
        //public int zAxis;
        //xAxis = -Input.gyro.rotationRateUnbiased.x;
    }
    [System.Serializable]
    public class DataList
    {
        public Data[] data;
    }

    public DataList myDataList = new DataList();
    // Start is called before the first frame update
    void Start()
    {
        filename = Application.dataPath + "/savedData.csv";
        Button btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(WriteCSV);

        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
        //InputSystem.EnableDevice(UnityEngine.InputSystem.Gyroscope.current);
    }

    // Update is called once per frame
    void Update()
    {
        var xAxis = -Input.gyro.rotationRateUnbiased.x;
        var yAxis = -Input.gyro.rotationRateUnbiased.y;
        var zAxis = -Input.gyro.rotationRateUnbiased.z;
    }
    /*
    public void RecordGyroData()
    {
        for (int i = 0; i < data.Count; i++)
        {

        }
    }
    */
    /// <summary>
    /// Method for writing CSV file.
    /// Starts by checking if the list is less than 0, if it is, it adds a header.
    /// Afterwards, the local variable startTime is declared.
    /// Following, is a while loop that checks if
    /// </summary>
    public void WriteCSV()
    {
        //var xAxis = -Input.gyro.rotationRateUnbiased.x;
        //var yAxis = -Input.gyro.rotationRateUnbiased.y;
        //var zAxis = -Input.gyro.rotationRateUnbiased.z;

        if (myDataList.data.Length > 0)
        {
            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("name, xAxiz, yAxis, zAxis");
            tw.Close();


            var startTime = DateTime.UtcNow;
            while(DateTime.UtcNow - startTime < TimeSpan.FromSeconds(collectionTime))
            {
            tw = new StreamWriter(filename, true);
                for (int i = 0; i < myDataList.data.Length; i++)
                {
                    tw.WriteLine(myDataList.data[i].name + "," +
                       //myDataList.data[i].xAxis + "," +
                       //myDataList.data[i].yAxis + "," +
                       //myDataList.data[i].zAxis);
                       -Input.gyro.rotationRateUnbiased.x + "," +
                       -Input.gyro.rotationRateUnbiased.y + "," +
                       -Input.gyro.rotationRateUnbiased.z);
                }
                tw.Close();
                System.Threading.Thread.Sleep(collectionInterval);
            }
            
        }
    }
    protected void OnGUI()
    {
        GUI.skin.label.fontSize = Screen.width / 40;

        GUILayout.Label("Orientation: " + Screen.orientation);
        GUILayout.Label("input.gyro.attitude: " + Input.gyro.attitude);
        GUILayout.Label("iphone width/font: " + Screen.width + " : " + GUI.skin.label.fontSize);
    }
 

}
