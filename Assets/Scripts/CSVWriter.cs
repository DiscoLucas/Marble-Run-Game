using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;
using UnityEngine.InputSystem;


public class CSVWriter : MonoBehaviour
{
    public string filename = "";
    
    [System.Serializable]
    public class Data
    {
        public string name;
    }
    public class DataList
    {
        public Data[] data;
    }

    public DataList myDataList = new DataList();
    // Start is called before the first frame update
    void Start()
    {
        filename = Application.dataPath + "/savedData.csv";
    }



    /// <summary>
    /// Method for writing CSV file.
    /// Starts by checking if the list is less than 0, if it is, it adds a header.
    /// Afterwards, the local variable startTime is declared.
    /// Following, is a while loop that checks if
    /// </summary>
    public void WriteCSV(List<string> input)
    {


        if (input.Count > 0)
        {
            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("xAxiz; yAxis; zAxis");
            

            for (int i = 0; i < input.Count; i++)
            {
                tw.WriteLine(input[i]);
            }
            tw.Close();
        }
    }
    protected void OnGUI()
    {
        GUI.skin.label.fontSize = Screen.width / 40;

        GUILayout.Label("Orientation: " + Screen.orientation);
        GUILayout.Label("input.gyro.attitude: " + Input.gyro.attitude);
        GUILayout.Label("phone width/font: " + Screen.width + " : " + GUI.skin.label.fontSize);
    }
 

}
