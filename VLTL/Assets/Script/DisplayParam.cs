using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class DisplayParam : MonoBehaviour
{
    string hs_temp, ls_temp, lt_temp, ht_temp;
    float timeStart=90f;
    public Text time;
    float timeCountdown = 3;
    public Text countdownText;
    public Text Velocity;
    public Text Moment;
    public Text Force;
    public static DisplayParam instance;
    bool start = false;
    void Start()
    {
       instance = this;
       StartCoroutine(Countdown());
       
    }  

    void Update()
    {   
        if (start == true)
        {
            if (timeStart > 0)
            {
                timeStart -= Time.deltaTime;
            }
            else
            {
                timeStart = 0;
            }
            displayaTimer(timeStart);
            displayParam();
        }
    }
    void displayaTimer(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay =0;
        }
        float mins = Mathf.FloorToInt(timeToDisplay / 60);
        float secs = Mathf.FloorToInt(timeToDisplay % 60);
        time.text = string.Format("{0:00}:{1:00}", mins, secs);
    }
  
    IEnumerator Countdown()
    {

        while (timeCountdown >0)
        {
            countdownText.text = timeCountdown.ToString();
            yield return new WaitForSeconds(1f);
            timeCountdown--;
        }
        countdownText.text = "GO!";
        yield return new WaitForSeconds(.5f);
        countdownText.gameObject.SetActive(false);
        //GetData();
        yield return new WaitForSeconds(1f);
       // timeStart = float.Parse(lt_temp) * 60;
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

    void displayParam()
    {
        Velocity.text = string.Format("Vận tốc(vòng/phút):{0:00}|{1:00}",ReadArduino.instance.data[0], "45");
        Moment.text = string.Format("Moment(N.m):{0:00}|{1:00}","40", (float.Parse(ls_temp)*1.5).ToString());
        Force.text = string.Format("Trợ lực(%):{0}", "40");
    }
}
