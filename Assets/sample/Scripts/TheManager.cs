using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheManager : MonoBehaviour
{
    public jsonConvert data;
    private int times = 0;
    private Vector3 accelerationVal;
    private List<Vector3> rotBuffer = new List<Vector3>();
    [SerializeField] private int BUFFERNUM = 5;
    public GameObject gameObject;
    [SerializeField] private float INTERVALTIME = 0.1f;
    private float INITTIME;
    private float pastTime;

    // Start is called before the first frame update
    void Start()
    {
        this.INITTIME = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if((Time.time - INITTIME) - this.pastTime > INTERVALTIME ){
            //加速度センサの値
            this.accelerationVal = data.sensingData.sensorData[times].accelerationVal;
            this.times++;
            //Arduinoなどのデータなら調整が必要
            // if(this.accelerationVal == Vector3.zero){
            //     this.accelerationVal = Vector3.zero;
            // }
            // Vector3 adjVal = this.accelerationVal - 
            Vector3 newRotation = new Vector3(
                Mathf.Atan2(this.accelerationVal.x, this.accelerationVal.z) / Mathf.PI * 180,
                0, 
                Mathf.Atan2(this.accelerationVal.y, this.accelerationVal.z) / Mathf.PI * 180
            );

            this.rotBuffer.Add(newRotation);
            if(this.rotBuffer.Count > BUFFERNUM){
                rotBuffer.RemoveAt(0);
            }
            Vector3 rotSum = Vector3.zero;
            foreach(Vector3 rot in rotBuffer){
                rotSum += rot;
            }
            Vector3 rotAverage = rotSum/rotBuffer.Count;

            this.pastTime = Time.time;
            this.gameObject.transform.rotation = Quaternion.Euler(newRotation);
            // this.gameObject.transform.rotation = Quaternion.Euler(rotAverage);
        }
    }
}
