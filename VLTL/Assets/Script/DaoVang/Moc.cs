using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moc : MonoBehaviour
{
    public float min_Z = -70f, max_Z = 70f;
    public int rotate_speed = 1;
    private float rotate_angle;

    public float move_sp = 2f;

    public float max_y = 5f;
    public float max_x = 9f;
    private Vector3 initial_pos;

    private Transform _Vang;
    private int _Weight;
    private int _Money=0;
    private bool flag;
    public Text Score;
    public List<GameObject> spawnO;

    public enum PodState
    {
        ROTATION,
        SHOOT,
        REWIND
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
                if(Input.GetMouseButton(0))
                {
                    podState = PodState.SHOOT;
                }

                rotate_angle += rotate_speed;

                if (rotate_angle>max_Z || rotate_angle<min_Z)
                {
                    rotate_speed *= -1;
                }
                transform.rotation = Quaternion.AngleAxis(rotate_angle, Vector3.forward);
                break;

            case PodState.SHOOT:
                transform.Translate(Vector3.down * move_sp * Time.deltaTime);
                if (Mathf.Abs(transform.position.x) > max_x || Mathf.Abs(transform.position.y) < max_y)
                    podState = PodState.REWIND;
                break;

            case PodState.REWIND:
                transform.Translate(Vector3.up *( move_sp-_Weight) * Time.deltaTime);
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
        print(pos_y);
        pos = new Vector3(pos_x,pos_y, -3.3f);
        Instantiate(toSpawn, pos, Quaternion.identity);

    }    
    //void Rotate()
    //{
    //    if (!can_rotate) return;
    //    if(rotate_right)
    //    {
    //        rotate_angle += rotate_speed * Time.deltaTime;
    //    }
    //    else
    //    {
    //        rotate_angle -= rotate_speed * Time.deltaTime;
    //    }
    //    transform.rotation = Quaternion.AngleAxis(rotate_angle, Vector3.forward);

    //    if (rotate_angle >= max_Z )
    //    {
    //        rotate_right = false;
    //    }    
    //    else if (rotate_angle<=min_Z)
    //    {
    //        rotate_right = true;
    //    }    
    //}    
    //void GetInput()
    //{
    //    if(Input.GetMouseButton(0))
    //    {
    //        if(can_rotate)
    //        {
    //            can_rotate = false;
    //            moveDown = true;
    //        }    
    //    }    
    //}  
    //void MoveRope()
    //{
    //    if (can_rotate) return;
    //    if (!can_rotate)
    //    {
    //        Vector3 temp = transform.position;
    //        if (moveDown)
    //        {
    //            temp -= transform.up * Time.deltaTime*move_sp;
    //        }
    //        else
    //        {
    //            temp += transform.up * Time.deltaTime*move_sp;
    //        }
    //        transform.position = temp;
    //        if (temp.y <= min_y)
    //        {
    //            moveDown = false;
    //        }
    //        if (temp.y >= initial_y)
    //        {
    //            can_rotate = true;
    //            move_sp = intial_move_sp;
    //        }
    //    }
    //}    

}
