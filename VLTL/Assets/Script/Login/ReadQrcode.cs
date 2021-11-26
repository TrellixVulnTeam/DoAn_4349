using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class ReadQrcode : MonoBehaviour
{
    // Start is called before the first frame update
    private WebCamTexture webCamTexture;
    private Rect screenRect;
    WebCamDevice[] devices;
    bool read;
    bool islogin;
    bool isLoading;
    string recived;
    string[] acc_pass;
    public Text QrText;
    public Text msText;
    public GameObject profile;
    public GameObject painSurvey;
    public GameObject login;
    public Animator loading;
    string st;
    void Start()
    {
        read = false;
        devices = WebCamTexture.devices;
        screenRect = new Rect(450, 150, 1000, 800);
        webCamTexture = new WebCamTexture(devices[1].name);
        webCamTexture.requestedHeight = 900;
        webCamTexture.requestedWidth = 450;

    }
    private void OnGUI()
    {
        if (islogin==false && read == true)
        {
            GUI.DrawTexture(screenRect, webCamTexture, ScaleMode.ScaleToFit);
            msText.text = "";
            QrText.text = "Di chuyển mã Qr đến vùng camera";
        }    
       
    }
    public void qrcode()
    {
       
        if (webCamTexture != null)
        {
            webCamTexture.deviceName = devices[1].name; 
            webCamTexture.Play();
            read = true;
        }
    }
    private void Update()
    {
        if (read == true)
        {
            try
            {
                IBarcodeReader barcodeReader = new BarcodeReader();
                var result = barcodeReader.Decode(webCamTexture.GetPixels32(), webCamTexture.width, webCamTexture.height);
                if (result != null)
                {
                    recived = result.Text;
                    StartCoroutine(Loadding());
                    LoginButton();
                    read = false;
                }
            }
            catch (Exception ex) { Debug.LogWarning(ex.Message); }
        }

    }
    public void LoginButton()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = recived,
            CreateAccount = false,
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnError);
    }
    void OnLoginSuccess(LoginResult result)
    {
        islogin = true;
        GetData();
    }
    void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
        QrText.text = "";
        msText.text = "Mã Qr không chính xác vui lòng thử lại!";
        loading.SetTrigger("Back");
    }
    public void GetData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OndataRecieved, OnError);
    }
    public void OndataRecieved(GetUserDataResult result)
    {
        if (result.Data == null || !result.Data.ContainsKey("FIM"))
        {
                profile.SetActive(true);
                login.SetActive(false);
        }
        else
        {
                painSurvey.SetActive(true);
                login.SetActive(false);  
        }
    }
    IEnumerator Loadding()
    {
        loading.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
    }
}
