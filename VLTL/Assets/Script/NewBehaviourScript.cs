using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject wayPoint;
    private Vector3 wayPointPos;
    private Vector3 offset;
    private Vector3 offsett;
    Transform rotation;
    public float speed;
    Quaternion offsetRotation;
    void Start()
    {
        offset = transform.position - wayPoint.transform.position;
        offsetRotation = transform.rotation * Quaternion.Inverse(wayPoint.transform.rotation);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
        transform.position = wayPoint.transform.position + offset;
        //transform.rotation = wayPoint.transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, wayPoint.transform.rotation * offsetRotation, 0.8f);
    }
}
