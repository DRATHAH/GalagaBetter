using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using TMPro;
using UnityEngine;
using System;

public class Demo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI sourceDataText;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_InputField outputField;
    [SerializeField] TextMeshProUGUI saveTimeText;
    [SerializeField] TextMeshProUGUI loadTimeText;

    private IDataService DataService =  new JsonDataService();
    private bool encryptionEnabled = false;
    private long saveTime;
    private long loadTime;

    public void ToggleEncryption()
    {
        encryptionEnabled = !encryptionEnabled;
    }

    public void SerializeJson()
    {
        long startTime = DateTime.Now.Ticks;
        if (DataService.SaveData("/player-stats.json", inputField.text, encryptionEnabled))
        {
            saveTime = DateTime.Now.Ticks - startTime;
            saveTimeText.SetText($"Save Time: {(saveTime/10000f) :N4}ms");
            startTime = DateTime.Now.Ticks;
            try
            {
                string files = DataService.LoadData<string>("/player-stats.json", encryptionEnabled);
                loadTime = DateTime.Now.Ticks - startTime;
                outputField.text = "Loaded from file:\r\n" + JsonConvert.SerializeObject(files, Formatting.Indented);
                loadTimeText.SetText($"Load Time: {(loadTime / 10000f):N4}ms");
            }
            catch (Exception e)
            {
                Debug.LogError("Could not load file!");
                outputField.text = "<color=#ff0000>Error loading data!</color>";
            }
        }
        else
        {
            Debug.LogError("Could not save file!");
            outputField.text = "<color=#ff0000>Error saving data!</color>";
        }
    }
}
