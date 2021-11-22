using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PaintScript : MonoBehaviour
{
    private void Start()
    {
        GetData();
    }
    int hs, ls, lt, ht;
    string hs_temp, ls_temp, lt_temp, ht_temp;
    public GameObject panit;
    public GameObject Bt;
    public void GetData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OndataRecieved, OnError);
    }  
    public void OndataRecieved(GetUserDataResult result)
    {
        if(result.Data != null && result.Data.ContainsKey("Thời gian tập tay") 
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
    public void btn1()
    {
        hs = int.Parse(hs_temp) + 1;
        ls = int.Parse(ls_temp) + 1;
        lt = int.Parse(lt_temp) + 5;
        ht = int.Parse(ht_temp) + 5;
        savePaint();
    }
    public void btn2()
    {
        hs = int.Parse(hs_temp);
        ls = int.Parse(ls_temp);
        lt = int.Parse(lt_temp);
        ht = int.Parse(ht_temp);
        savePaint();
    }
    public void btn3()
    {
        hs = int.Parse(hs_temp);
        ls = int.Parse(ls_temp);
        lt = int.Parse(lt_temp) - 5;
        ht = int.Parse(ht_temp) - 5;
        savePaint();
    }
    public void btn4()
    {
        hs = int.Parse(hs_temp) - 1;
        ls = int.Parse(ls_temp) - 1;
        lt = int.Parse(lt_temp) - 5;
        ht = int.Parse(ht_temp) - 5;
        savePaint();
    }
    public void btn5()
    {
        hs = int.Parse(hs_temp) - 2;
        ls = int.Parse(ls_temp) - 2;
        lt = int.Parse(lt_temp) - 5;
        ht = int.Parse(ht_temp) - 5;
        savePaint();
    }


    public void savePaint()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"Thời gian tập tay", ht.ToString()},
                {"Thời gian tập chân",lt.ToString()},
                {"Mức tập tay",hs.ToString()},
                {"Mức tập chân",ls.ToString()},
            }
        };
        PlayFabClientAPI.UpdateUserData(request, Ondatasend, OnError);
    }

    void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }
    void Ondatasend(UpdateUserDataResult result)
    {
        Debug.Log("lưu thành công");
        panit.SetActive(false);
        Bt.SetActive(true);
    }
}
