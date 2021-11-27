using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO.Ports;
using System;

public class LoadScene : MonoBehaviour
{
    public GameObject baiTap;
    public GameObject LT;
    public Animator loader;
    public Button btn1, btn2;
    public Text msText;
    string[] ports = SerialPort.GetPortNames();
    SerialPort Sp = new SerialPort();
    public void loadcans()
    {
        baiTap.SetActive(true);
        LT.SetActive(false);

    }
    public void loadScene1 ()
    {
        try
        {
            Sp.PortName = ports[0];
            Sp.BaudRate = 115200;
            Sp.Open();
            msText.text="";
        }
        catch (Exception ex)
        {
            msText.text = "Vui lòng kết nối với thiết bị tập!";
        }
        if (Sp.IsOpen)
        {
            StartCoroutine(load(1));
            Sp.Close();
        }
    }
    public void loadScene2()
    {
        try
        {
            Sp.PortName = ports[0];
            Sp.BaudRate = 115200;
            Sp.Open();
            msText.text = "";
        }
        catch (Exception ex)
        {
            msText.text = "Vui lòng kết nối với thiết bị tập!"; Debug.Log("sdasd");
        }
        if (Sp.IsOpen)
        {
            StartCoroutine(load(3));
            Sp.Close();
        }
    }

   IEnumerator load(int index)
    {
        loader.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(index);
    }    
}
