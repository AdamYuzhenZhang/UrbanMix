using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataReader : MonoBehaviour
{
    [SerializeField] private string m_FileName = "building.txt";
    private void Start()
    {
        ReadDataFile();
    }

    private void ReadDataFile()
    {
        string directory = "Data";
        StreamReader strReader = new StreamReader(directory + "/" + m_FileName);
        Debug.Log(directory + "/" + m_FileName);
        bool endOfFile = false;
        while (!endOfFile)
        {
            string dataString = strReader.ReadLine();
            if (dataString == null)
            {
                endOfFile = true;
                break;
            }

            string[] dataValues = dataString.Split(",");
            Debug.Log("DataString");
            Debug.Log(dataString);
        }
    }
}
