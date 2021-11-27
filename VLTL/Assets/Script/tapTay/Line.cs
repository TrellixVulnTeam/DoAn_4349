using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    // Start is called before the first frame update
    private LineRenderer lineRenderer;
    [SerializeField] private Transform start;
    Vector3 _Start;
    Vector3 _Stop;

    void Start()
    {
        _Start = start.position;

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, _Start);
        lineRenderer.SetPosition(1, transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(1, transform.position);
    }
}
