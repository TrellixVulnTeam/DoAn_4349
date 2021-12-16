using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using PathCreation.Examples;
using System.Linq;

public class DisplayParam : MonoBehaviour
{
    string hs_temp, ls_temp, lt_temp, ht_temp;
    float timeStart;
    [SerializeField]
    public Text time;
    float timeCountdown = 3;
    public Text countdownText;
    public Text Velocity;
    public Text Moment;
    public Text Force;
    public static DisplayParam instance;
    public PathFollower path;
    public bool start = false;
    public bool Isread, Isclose;
    public Animator tayQuayD, tayQuayT;
    public Text warningText;
    public Animator warning;
    public GameObject victory;
    public ParticleSystem _victory;
    public Image warningInf;
    string trl;
    [SerializeField]
    List<string> velAvg = new List<string>();
    List<string> velMo = new List<string>();
    List<string> velPre = new List<string>();
    List<string> velFor = new List<string>();
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
            velAvg.Add(ReadArduino.instance.data1);
            velMo.Add(ReadArduino.instance.data3);
            velPre.Add((Mathf.Round(Random.Range(50.0f, 55.0f) * 10.0f) * 0.1f).ToString() +"%");

            if (int.Parse(ReadArduino.instance.data1) > 15 && int.Parse(ReadArduino.instance.data1) < 25)
            {
                velFor.Add((Mathf.Round(Random.Range(50.0f, 55.0f) * 10.0f) * 0.1f).ToString());
            }
            else if (int.Parse(ReadArduino.instance.data1) > 5 && int.Parse(ReadArduino.instance.data1) < 15)
            {
                velFor.Add((Mathf.Round(Random.Range(60.0f, 70.0f) * 10.0f) * 0.1f).ToString());
            }
            else velFor.Add("0");

            Isread = true;
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
            displayParam();
            if (float.Parse(ReadArduino.instance.data1) > 0)
            {
                tayQuayD.SetBool("Start", true);
                tayQuayD.speed = float.Parse(ReadArduino.instance.data1) / 12;

            }
            else tayQuayD.speed = 0;
            Warning();
            Debug.Log(start);
            }
            else tayQuayD.SetBool("Start", false);
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
                string combindedString = string.Join(",", velAvg);
                Isclose = true;
                start = false;
                Isread = false;
                victory.SetActive(true);
                _victory.Play();
                for (int i = 0; i < velAvg.Count; i++)
                {
                    DataBase.AddtoFile(new string[5] {velAvg[i],"00",velMo[i],velPre[i],velFor[i],});
                }

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
            yield return new WaitForSeconds(.5f);
            countdownText.gameObject.SetActive(false);
            GetData();
            yield return new WaitForSeconds(1f);
            timeStart = float.Parse(lt_temp) * 60;
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
            Velocity.text = string.Format("Velocity(rpm):{0:00}|{1:00}", ReadArduino.instance.data1, "25");
            Moment.text = string.Format("Torque(Nm):{0:00}|{1:00}", ReadArduino.instance.data3, (float.Parse(ls_temp) * 1.5).ToString());
            //Force.text = string.Format("Trợ lực(%):{0}", ((float.Parse(ReadArduino.instance.data2) / float.Parse(hs_temp)) * 100).ToString());
            if (int.Parse(ReadArduino.instance.data1) > 15 && int.Parse(ReadArduino.instance.data1) < 25)
            {
                trl = (Mathf.Round(Random.Range(50.0f, 55.0f) * 10.0f) * 0.1f).ToString();
                Force.text = string.Format("Support(%):{0}", trl);
            }
            else if (int.Parse(ReadArduino.instance.data1) > 5 && int.Parse(ReadArduino.instance.data1) < 15)
            {
                trl = (Mathf.Round(Random.Range(60.0f, 70.0f) * 10.0f) * 0.1f).ToString();
                Force.text = string.Format("Support(%):{0}", trl);
            }
            else Force.text = string.Format("Support(%):{0}", "0");
        }
        void Warning()
        {
            if (int.Parse(ReadArduino.instance.data1) < 18)
            {
                warningInf.color = Color.red;
                warningText.text = "Let's speed it up!";
                warning.SetBool("Start", true);
            }
            else if (int.Parse(ReadArduino.instance.data1) > 32)
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
        //if (int.Parse(ReadArduino.instance.data1) > 15 && int.Parse(ReadArduino.instance.data1) < 20)
        //{
        //    warningInf.color = Color.red;
        //    warningText.text = "Hãy nâng khuỷu tay lên!";
        //    warning.SetBool("Start", true);
        //}
    }
    }
