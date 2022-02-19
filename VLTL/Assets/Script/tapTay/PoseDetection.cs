using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PoseDetection : MonoBehaviour
{
    // Start is called before the first frame update
    public string khuy, vai;
    void Awake()
    {
        var psi = new ProcessStartInfo();
        psi.FileName = @"C:\\users\\trant\\appdata\\local\\programs\\python\\python39\\python.exe";
        // 2) provide script and arguments
        var script = @"F:\WorkSpace\GitHub\DoAn\VLTL\Assets\Script\PythonCode\khungxuong.py";
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
            vai = process.StandardOutput.ReadLine();
            khuy = process.StandardOutput.ReadLine();
        }
    }

    // Update is called once per frame
    void Update()
    {
        print(vai);
    }
}
