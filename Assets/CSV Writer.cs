using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVWriter : MonoBehaviour
{
    string filename = "";

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
