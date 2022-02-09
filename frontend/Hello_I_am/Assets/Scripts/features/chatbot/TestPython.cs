using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Diagnostics;
using UnityEngine.UI;

public class TestPython : MonoBehaviour
{
    public Text test;
    public void onPython()
    {
        try {
            ProcessStartInfo start = new ProcessStartInfo();

            start.FileName = Application.dataPath + "/../Assets/Scripts/features/chatbot/python.exe";
            // 인수 전달
            start.Arguments = Application.dataPath + "/Scripts/features/chatbot/classifier.py";
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;


            Process psi = Process.Start(start);
            StreamReader reader = psi.StandardOutput;
            //UnityEngine.Debug.Log(reader.ReadLine());
            test.text = reader.ReadLine();


        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogError("Unable to launch app: " + e.Message);
        }
    }
}
