using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public GameObject baiTap;
    public GameObject LT;
    public void loadcans()
    {
        baiTap.SetActive(true);
        LT.SetActive(false);

    }
    public void loadScene1 ()
    {
        SceneManager.LoadScene(1);
    }
    public void loadScene2()
    {
        SceneManager.LoadScene(2);
    }
  
}
