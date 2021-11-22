using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using PlayFab;
using PlayFab.ClientModels;

public class PlayerProfile : MonoBehaviour
{
    public InputField namee;
    public InputField phone;
    public InputField age;
    public Toggle nam;
    public Toggle nu;
    [HideInInspector] public string _name;
    [HideInInspector] public string _phone;
    [HideInInspector] public string _age="";
    [HideInInspector] public string _sex;
    public Button save;
    [HideInInspector] string sex;
    int a;

    public Text messText;
    public InputField FIM;
    public InputField HS;
    public InputField LS;
    public GameObject lieuTrinh;
    public GameObject profile;
    [HideInInspector] public string _FIM;
    [HideInInspector] public string _HS;
    [HideInInspector] public string _LS;
    [HideInInspector] private string HL, TH, LL, TL;
    public Text handLevel;
    public Text timeHand;
    public Text ledLevel;
    public Text timeLeg;

    public Animator loading;

    void Start()
    {
      
    }
    void Update()
    {
        if (nam.isOn)
        {
            sex = "Nam";
        }
        else sex = "Nữ";
        _name = namee.text;
        _phone = phone.text;
        _age = age.text;
        _sex = sex;
        _FIM = FIM.text;
        _HS = HS.text;
        _LS = LS.text;
        // check();
    }

    public bool isNumberic(string input)
    {
        return int.TryParse(input, out a);
    }
    public void check()
    {
        if (_name == "" || _phone == "" || _age == "" || _FIM == "" || _HS == "" || _LS == "")
        {
            save.interactable = false;
            return;
        }
          else { messText.text = ""; save.interactable = true; }

        if (!Regex.Match(_name, @"^[A-Z][a-zA-Z]+\s+[A-Z][a-zA-Z]+\s+[A-Z][a-zA-Z]*$").Success)
        {
            messText.text = "Tên không hợp lệ!";
            save.interactable = false;
            return;
        }
          else { messText.text = ""; save.interactable = true; }

        if (!Regex.Match(_age, @"^[0-9]{2}$").Success)
        {
            messText.text = "Tuổi không hợp lệ!";
            save.interactable = false;
            return;
        }
          else { messText.text = ""; save.interactable = true; }

        if (!Regex.Match(_phone, @"^[0]{1}[0-9]{9}$").Success)
        {
            messText.text = "Số điện thoại không hợp lệ!";
            save.interactable = false;
            return;
        }
        else { messText.text = ""; save.interactable = true; }
      
        if (!Regex.Match(_FIM, @"^[0-9]{3}$").Success)
        {
            messText.text = "FIM không hợp lệ!";
            save.interactable = false;
            return;
        }
          else { messText.text = ""; save.interactable = true; }

        if (!Regex.Match(_HS, @"^[0-5]{1}$").Success)
        {
            messText.text = "Sức cơ tay không hợp lệ!";
            save.interactable = false;
            return;
        }
          else { messText.text = ""; save.interactable = true; }

        if (!Regex.Match(_LS, @"^[0-5]{1}$").Success)
        {
            messText.text = "Sức cơ chân không hợp lệ!";
            save.interactable = false;
            return;
        }
          else { messText.text = ""; save.interactable = true; }
    }    
    public void Fuzzy()
    {
        StartCoroutine(Loadding());
    }
    IEnumerator Loadding()
    {
        loading.SetTrigger("Start");
        yield return new WaitForSeconds(4f);

        string[] names = new string[] { _FIM, _HS, _LS, _age };
        using (StreamWriter sw = new StreamWriter(@"F:\DoAn\VLTL\Assets\Data\Data.txt"))
        {

            foreach (string s in names)
            {
                sw.WriteLine(s);
            }
        }

        var psi = new ProcessStartInfo();
        psi.FileName = @"C:\\users\\trant\\appdata\\local\\programs\\python\\python39\\python.exe";
        // 2) provide script and arguments
        var script = @"F:\DoAn\VLTL\Assets\Script\PythonCode\Fuzzy.py";
        psi.Arguments = $"\"{script}\"";
        // 3) process configuration
        psi.UseShellExecute = false;
        psi.CreateNoWindow = true;
        psi.RedirectStandardOutput = true;
        psi.RedirectStandardError = true;
        // 4) execute process and get output
        var errors = "";
        using (var process = Process.Start(psi))
        {
            errors = process.StandardError.ReadToEnd();
            TH = process.StandardOutput.ReadLine();
            HL = process.StandardOutput.ReadLine();
            LL = process.StandardOutput.ReadLine();
            TL = process.StandardOutput.ReadLine();
        }

        
        profile.SetActive(false);
        lieuTrinh.SetActive(true);
        // saveProfile();
        timeHand.text = TH;
        handLevel.text = HL;
        ledLevel.text = LL;
        timeLeg.text = TL;

    }
    void OnError(PlayFabError error)
    {
      print(error.GenerateErrorReport());
    }
    public void saveProfile()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"Sức cơ chân",_LS},
                {"Sức cơ tay",_HS},
                {"FIM",_FIM},
                {"Giới tính",_sex},
                {"Số điện thoại",_phone},
                {"Tên + tuổi ",_name + " + " +_age},
                {"Thời gian tập tay",TH},
                {"Thời gian tập chân",TL},
                {"Mức tập tay",HL},
                {"Mức tập chân",LL},
            }
        };
        PlayFabClientAPI.UpdateUserData(request, Ondatasend, OnError);
    }
    void Ondatasend(UpdateUserDataResult result)
    {
        print("lưu ok");
    }
}
