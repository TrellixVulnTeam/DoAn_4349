using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Moc : MonoBehaviour
{
    private float min_Z = -70f, max_Z = 70f;
    public float rotate_speed = 1;
    private float rotate_angle;

    public float move_sp;
    float z1, z2;
    public float max_y = 6f;
    public float max_x = 9f;
    private Vector3 initial_pos;
    private Transform _Vang;
    private int _Weight=0;
    private int _Money=0;
    private bool flag;
    public Text Score;
    public List<GameObject> spawnO;
    public static Moc istance;
    public GameObject Ins;
    public Text insText;
    float t = 0;
    public enum PodState
    {
        ROTATION,
        SHOOT,
        REWIND,
        PREPARE
    }
    PodState podState = PodState.ROTATION;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (flag) return;
        flag = true;
        _Vang = col.transform;
        _Vang.SetParent(transform);
        _Weight = _Vang.GetComponent<Vang>().Weight;
        _Money += _Vang.GetComponent<Vang>().Money;   
        podState = PodState.REWIND;
    }
    private void Awake()
    {
        initial_pos = transform.position;
        Score.text = "$"+ _Money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        switch (podState)
        {
            case PodState.ROTATION:
                if (ReadArduino.instance.data4 != null)
                {
                    if (float.Parse(ReadArduino.instance.data4) > 0 || Input.GetMouseButtonDown(0))
                    {
                        podState = PodState.PREPARE;
                        z1 = this.transform.rotation.eulerAngles.z;
                        
                    }
                }    
                rotate_angle += rotate_speed;

                if (rotate_angle>max_Z || rotate_angle<min_Z)
                {
                    rotate_speed *= -1;
                }
                transform.rotation = Quaternion.AngleAxis(rotate_angle, Vector3.forward);
                break;

            case PodState.PREPARE:
                //print(string.Format("{0} - {1}", z1, z2));
                if (Mathf.Abs(z1-z2) > 5 || t == 0)
                {

                    print("2");
                    podState = PodState.SHOOT;
                   // Ins.SetActive(false);

                }
                else
                {
                    podState = PodState.ROTATION;
                    //Ins.SetActive(true);
                }
                break;

            case PodState.SHOOT:
                t = 1;
                z2 = z1;
                transform.Translate((Vector3.down *float.Parse(ReadArduino.instance.data4)/10)* Time.deltaTime);
                if (Mathf.Abs(transform.position.x) > max_x || Mathf.Abs(transform.position.y) < max_y)
                    podState = PodState.REWIND;
                break;

            case PodState.REWIND:
                    transform.Translate(Vector3.up *((float.Parse(ReadArduino.instance.data4)/_Weight)*5) * Time.deltaTime);
                if (Mathf.Floor(transform.position.y) == Mathf.Floor(initial_pos.y))
                {
                    if(_Vang!=null)
                    {
                        flag = false;
                        _Weight = 0;
                        Destroy(_Vang.gameObject);
                        AddMoney(_Money);
                        Spawn();
                    }    
                    transform.position = initial_pos;
                    podState = PodState.ROTATION;
                }                    
                break;
        }       
    }

    private void AddMoney(int money)
    {
        Score.text = string.Format("${0}", money);
    }
    private void Spawn()
    {
        int randomItem;
        GameObject toSpawn;
        float pos_x, pos_y;
        Vector3 pos;
        randomItem = Random.Range(0, spawnO.Count);
        toSpawn = spawnO[randomItem];
        pos_x = Random.Range(-8f, 8f);
        pos_y= Random.Range(10f, 5f);
        pos = new Vector3(pos_x,pos_y, -3.3f);
        Instantiate(toSpawn, pos, Quaternion.identity);
    }    
}
