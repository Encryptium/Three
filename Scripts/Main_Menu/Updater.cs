using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.IO;
using System;

public class Updater : MonoBehaviour
{
    public Text versionText;
    public GameObject updateModal;
    public GameObject updateNTF;
    // Start is called before the first frame update
    void Start()
    {
        CheckForUpdates();
    }

    void CheckForUpdates()
    {
        versionText.text = Application.version;
        // Debug.Log(Application.version); // 16
        string OS = SystemInfo.operatingSystem.ToString();
        // OS = "WEBGL";
        // Debug.Log(OS);
        string newestVersion = RetrieveNewestVersion();
        
        // Debug.Log(content);
        if (Application.version != newestVersion)
        {
            Debug.Log("Your application needs ann update. Double click on the file titled 'Updater.sh' that is located in the same directory as your game.");
            if (!OS.Contains("Mac OS") && !OS.Contains("Windows"))
            {
                Instantiate(updateNTF);
                return;
            }
            Instantiate(updateModal);
        } else {
            Debug.Log("You are up to date");
        }

        /* if (OS.Contains("Mac OS"))
        {
            Instantiate(windowsUpdateModal);
        }
        else if (OS.Contains("Windows"))
        {
            Instantiate(macOSUpdateModal);
        } */

        // macOS would be 'Mac OS X'; Windows would be Windows
        /* if (OS.Contains("Mac OS"))
        {
            Debug.Log("Updating Mac OS package.");
        }
        else if (OS.Contains("Windows"))
        {
            Debug.Log("Updating Windows package.");
        }
        else
        {
            Debug.Log("Operating System does not support online updates from the Three Entertainment Servers.");
        } */
    }
    
    string RetrieveNewestVersion() 
    {
        var client = new System.Net.WebClient();
        // WebClient client = new WebClient();
        Stream stream = client.OpenRead("https://Three.jonathan2018.repl.co/update/latest.txt");
        StreamReader reader = new StreamReader(stream);
        String content = reader.ReadToEnd();
        return content;
    }

}
