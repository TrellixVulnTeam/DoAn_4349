using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public GameObject baiTap;
    public GameObject LT;
    public Animator loader;
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
