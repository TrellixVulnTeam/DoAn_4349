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
            displayaTimer(timeStart);
            displayparam();
            //moc.enabled = true;
            if (float.Parse(ReadArduino.instance.data4) > 0)
            {
                tayQuayT.SetBool("Start", true);
                tayQuayT.speed = float.Parse(ReadArduino.instance.data4) / 20;
                cheoThuyen.SetTrigger("Cheo");
                cheoThuyen.speed = float.Parse(ReadArduino.instance.data4) / 15;
            }
            else
            {
                tayQuayT.speed = 0;
                cheoThuyen.speed = 0;
            }
            Warning();
        }
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
        countdownText.text = "BẮT ĐẦU!";
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
        Velocity.text = string.Format("Vận tốc(vòng/phút):{0:00}|{1:00}", ReadArduino.instance.data4, "25");
        Moment.text = string.Format("Moment(N.m):{0:00}|{1:00}", ReadArduino.instance.data6, (float.Parse(hs_temp) / 2).ToString());
        Force.text = string.Format("Trợ lực(%):{0}", ((float.Parse(ReadArduino.instance.data5) / float.Parse(hs_temp)) * 100).ToString());
    }
    void Warning()
    {
        if (int.Parse(ReadArduino.instance.data4) < 25)
        {
            warningInf.color = Color.red;
            warningText.text = "Bạn cần tập nhanh hơn!";
            warning.SetBool("Start", true);
        }
        if (int.Parse(ReadArduino.instance.data4) > 25  && int.Parse(ReadArduino.instance.data4) < 40)
        {
            warningInf.color = Color.green;
            warningText.text = "Bạn cần tập nhanh hơn!";
            warning.SetBool("Start", false);
        }
        if (int.Parse(ReadArduino.instance.data4) > 40)
        {
            warningInf.color = Color.red;
            warningText.text = "Bạn cần tập chậm hơn!";
            warning.SetBool("Start", true);
        }
        if (int.Parse(ReadArduino.instance.data4) == 27)
        {
            warningInf.color = Color.red;
            warningText.text = "Hãy nâng khuỷu tay lên!";
            warning.SetBool("Start", true);
        }
        
    }
}
