using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class ReadArduino : MonoBehaviour
{
    // Start is called before the first frame update
    string recived;
    string [] recivedSplit;
    [HideInInspector] public string data1, data2, data3, data4, data5, data6;
    public float speed;
    public static ReadArduino instance;
    int y;
    string[] ports = SerialPort.GetPortNames();
    SerialPort Sp = new SerialPort();
    void Awake()
    {
        if (Sp.IsOpen) Sp.Close();
        Sp.PortName = ports[0];
        Sp.BaudRate = 115200;
        Sp.Open();
        instance = this;
        StartCoroutine(readData());
        y = SceneManager.GetActiveScene().buildIndex;
    }
    // Update is called once per frame
    IEnumerator readData()
    {
        while(true)
        {
            yield return new WaitForSeconds(.2f);
            if (Sp.IsOpen)
            {
                recived = Sp.ReadExisting();
                string[] temp;
                if (recived.Count() > 0)
                {
                    temp = recived.Split('|');

                    if (temp.Count() > 0)
                    {
                        if (temp[0] != "")
                        {
                            string[] temp1 = temp[0].Split(',');
                            if (temp1.Count() == 8)
                            {
                                if (temp1[0] == "@" && temp1[7] == "#")
                                {
                                    data1 = temp1[1];
                                    data2 = temp1[2];
                                    data3 = temp1[3];
                                    data4 = temp1[4];
                                    data5 = temp1[5];
                                    data6 = temp1[6];
                                    print(data4);
                                }
                            }
                        }
                    }
                }
            }
            if (y==1)
            {
                if (DisplayParam.instance.Isclose == true) Sp.Close();
            }
            else if(y==3)
            {
                if (displayParam.instance.Isclose == true) Sp.Close();
            }
            
        }        
    }    
    void Update()
    {
    }
}
