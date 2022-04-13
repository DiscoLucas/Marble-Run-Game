using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class CSVWriter : MonoBehaviour
{
    string filename = "";
    public Button startButton;

    [System.Serializable]
    public class Data
    {
        public string name;
        public int xAxis;
        public int yAxis;
        public int zAxis;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WriteCSV()
    {
        if(myDataList.data.Length > 0)
        {
            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("name, xAxiz, yAxis, zAxis");
            tw.Close();

            tw = new StreamWriter(filename, true);

            for(int i = 0; i < myDataList.data.Length; i++)
            {
                tw.WriteLine(myDataList.data[i].name + "," +
                   myDataList.data[i].xAxis + "," +
                   myDataList.data[i].yAxis + "," +
                   myDataList.data[i].zAxis);
            }
            tw.Close();
        }
    }
}
