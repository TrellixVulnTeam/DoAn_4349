using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vang : MonoBehaviour
{
    [SerializeField]
    private string _tag;
    [SerializeField]
    public int Money;
    public int Weight;

    private void Awake()
    {
        this.tag = _tag;
    }
}
