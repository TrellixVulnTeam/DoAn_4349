using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;


public class XiuXoa : MonoBehaviour
{
    [Header("UI")]
    public Text messageText;
    [SerializeField] public InputField usernameInput;
    public InputField passwordIput;
    public GameObject profile;
    public GameObject login;
    [SerializeField]


    public void RegisterButton()
    {
        if (passwordIput.text.Length < 6)
        {
            messageText.text = "Password too short!";
            return;
        }
        var request = new RegisterPlayFabUserRequest
        {
            Username = usernameInput.text,
            Password = passwordIput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);

    }
    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Register and Login succesfull!";
        
        login.SetActive(false);
    }

    public void LoginButton()
    {
        var request = new LoginWithPlayFabRequest
        {
            Username = usernameInput.text,
            Password = passwordIput.text
        };
        PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnError);
    }
    void OnLoginSuccess(LoginResult result)
    {
        messageText.text = ("Logged in !");
        login.SetActive(false);
        profile.SetActive(true);
    }
    void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }
}
