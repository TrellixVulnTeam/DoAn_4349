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
    SerialPort Sp = new SerialPort("COM3", 115200);
    public Button btn1, btn2;
    public Text msText;
    bool open;
    private void Awake()
    {
       
    }
    private void Update()
    {
        
    }
    public void loadcans()
    {
        baiTap.SetActive(true);
        LT.SetActive(false);

    }
    public void loadScene1 ()
    {
        StartCoroutine(load(1));
    }
    public void loadScene2()
    {
        StartCoroutine(load(3));
    }

   IEnumerator load(int index)
    {
        loader.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(index);
    }    
}
