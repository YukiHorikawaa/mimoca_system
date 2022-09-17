using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class jsonConvert : MonoBehaviour
{
    public SensingData sensingData;
    public string strFile;
    // Start is called before the first frame update
    void Start()
    {
        string inputString = Resources.Load<TextAsset>(this.strFile).ToString();
        Debug.Log(inputString);
        sensingData = JsonUtility.FromJson<SensingData>(inputString);
        Debug.LogFormat("latitude:{0}, longitude:{1}, altitude:{2}", sensingData.location[0].latitude, sensingData.location[0].longitude, sensingData.location[0].altitude);
        Debug.LogFormat("gyroVal.Count:{0}, gyroVal.x:{1}", sensingData.sensorData.Count, sensingData.sensorData[0].gyroVal.x);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
