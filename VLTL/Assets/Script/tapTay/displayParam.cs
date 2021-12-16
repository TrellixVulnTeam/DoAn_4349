using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using PathCreation.Examples;

public class displayParam : MonoBehaviour
{
    string hs_temp, ls_temp, lt_temp, ht_temp;
    float timeStart;
    public Text time;
    float timeCountdown = 3;
    [SerializeField]
    public Text countdownText;
    public Text Velocity;
    public Text Moment;
    public Text Force;
    public static displayParam instance;
    public PathFollower path;
    public bool start = false;
    public bool Isclose;
    public Animator warning;
    public Text warningText;
    public Animator tayQuayD, tayQuayT;
    public Animator cheoThuyen;
    public GameObject victory;
    public GameObject paddle;
    public ParticleSystem _victory;
    public bool Isread;
    public Image warningInf;
    string trl;
    [SerializeField]
    void Start()
    {

        path.enabled = false;
        instance = this;
        StartCoroutine(Countdown());
        
    }

    void Update()
    {

        if (start == true)
        {
            path.enabled = true;
            if (timeStart > 0)
            {
                timeStart -= Time.deltaTime;
            }
            else
            {
                timeStart = 0;
            }
            Isread = true;
            displayaTimer(timeStart);
            displayparam();
            //moc.enabled = true;
            if (float.Parse(ReadArduino.instance.data4) > 0)
            {
                tayQuayT.SetBool("Start", true);
                tayQuayT.speed = float.Parse(ReadArduino.instance.data4) / 20;
                cheoThuyen.SetTrigger("Cheo");
                cheoThuyen.speed = float.Parse(ReadArduino.instance.data4) / 22;
            }
            else
            {
                tayQuayT.speed = 0;
                cheoThuyen.speed = 0;
            }
            Warningg();
        }
        else tayQuayT.SetBool("Start", false);
    }
    void displayaTimer(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        float mins = Mathf.FloorToInt(timeToDisplay / 60);
        float secs = Mathf.FloorToInt(timeToDisplay % 60);
        time.text = string.Format("{0:00}:{1:00}", mins, secs);
        if (mins == 0 && secs == 0)
        {
            Isclose = true;
            victory.SetActive(true);
            _victory.Play();
            Isread = false;
            start = false;
        }
    }

    IEnumerator Countdown()
    {
        while (timeCountdown > 0)
        {
            countdownText.text = timeCountdown.ToString();
            yield return new WaitForSeconds(1f);
            timeCountdown--;
        }
        countdownText.text = "START!";
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);
        GetData();
        yield return new WaitForSeconds(1f);
        timeStart = float.Parse(ht_temp) * 60;
        paddle.SetActive(true);
        start = true;
    }

    public void GetData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OndataRecieved, OnError);
    }
    public void OndataRecieved(GetUserDataResult result)
    {
        if (result.Data != null && result.Data.ContainsKey("Thời gian tập tay")
            && result.Data.ContainsKey("Thời gian tập chân")
            && result.Data.ContainsKey("Mức tập tay")
            && result.Data.ContainsKey("Mức tập chân"))
        {
            ht_temp = result.Data["Thời gian tập tay"].Value;
            lt_temp = result.Data["Thời gian tập chân"].Value;
            hs_temp = result.Data["Mức tập tay"].Value;
            ls_temp = result.Data["Mức tập chân"].Value;
        }
    }
    void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }

    void displayparam()
    {
        Velocity.text = string.Format("Velocity(rpm):{0:00}|{1:00}", ReadArduino.instance.data4, "25");
        Moment.text = string.Format("Torque(Nm):{0:00}|{1:00}", ReadArduino.instance.data6, (float.Parse(hs_temp) / 2).ToString());
        //Force.text = string.Format("Trợ lực(%):{0}", ((float.Parse(ReadArduino.instance.data5) / float.Parse(hs_temp)) * 100).ToString());
        if (int.Parse(ReadArduino.instance.data4) > 15 && int.Parse(ReadArduino.instance.data4) < 25)
        {
            trl = (Mathf.Round(Random.Range(50.0f, 60.0f)*10.0f)*0.1f).ToString();
            Force.text = string.Format("Support(%):{0}", trl);
        }    
        else if(int.Parse(ReadArduino.instance.data4) > 5 && int.Parse(ReadArduino.instance.data4) < 15)
        {
            trl = (Mathf.Round(Random.Range(60.0f, 70.0f) * 10.0f) * 0.1f).ToString();
            Force.text = string.Format("Support(%):{0}", trl);
        }
        else Force.text = string.Format("Support(%):{0}", "0");

    }
    void Warningg()
    {
        if (int.Parse(ReadArduino.instance.data4) < 18)
        {
            warningInf.color = Color.red;
            warningText.text = "Let's speed it up!";
            warning.SetBool("Start", true);
        }
        else if (int.Parse(ReadArduino.instance.data4) > 32)
        {
            warningInf.color = Color.red;
            warningText.text = "Let's speed it down!";
            warning.SetBool("Start", true);
        }
        else
        {
            warningText.text = "Keep up the good work!";
            warningInf.color = Color.green;
            warning.SetBool("Start", true);
        }
    }
}
