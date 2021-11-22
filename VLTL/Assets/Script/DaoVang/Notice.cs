using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notice : MonoBehaviour
{
    public Animator notice;
 
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
            StartCoroutine(delay());    
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(3f);
        notice.SetTrigger("Notice");
        yield return new WaitForSeconds(5f);
        notice.SetTrigger("close");
    }
}
