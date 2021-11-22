using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;

public class ReadArduino : MonoBehaviour
{
    // Start is called before the first frame update
    public string [] data;
    public float speed;
    public static ReadArduino instance;
    SerialPort Sp = new SerialPort("COM4", 115200);
    void Start()
    {
        Sp.Open();
        instance = this;
    }
    // Update is called once per frame
    IEnumerator readData()
    {
        data = Sp.ReadLine().Split(',');
        speed = float.Parse(data[0]);
        yield return new WaitForSeconds(0.5f);       
    }    
    void Update()
    {
        StartCoroutine(readData());
       // print(data[0]);
    }
}
