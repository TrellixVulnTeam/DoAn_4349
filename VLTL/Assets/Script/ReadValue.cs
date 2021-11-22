using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadValue : MonoBehaviour
{
    Text showValue;
    // Start is called before the first frame update
    void Start()
    {
        showValue = GetComponent<Text>();
    }

    // Update is called once per frame
    public void Read(float value)
    {
        showValue.text = Mathf.RoundToInt(value).ToString();
    }    
}
