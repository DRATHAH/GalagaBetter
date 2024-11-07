using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceDetection : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer; // Recognizes keywords
    private Dictionary<string, Action> actions = new Dictionary<string, Action>(); // Dictionary of keywords and their associated functions
    public List<string> keywords = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        foreach(string keyword in keywords)
        {
            actions.Add(keyword, RunAction);
        }

        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
            if (!device.Contains("Oculus"))
            {
                Microphone.End(device);
                Debug.Log(Microphone.IsRecording(device));
            }
        }

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray(), ConfidenceLevel.Low);
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start(); // Starts listening to speech.
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            keywordRecognizer.Stop();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            keywordRecognizer.Start();
        }
    }

    public void UpdateKeywords(string newWord)
    {
        actions.Clear();
        foreach (string keyword in keywords)
        {
            actions.Add(keyword, RunAction);
        }

        actions.Add(newWord, RunAction);
        string[] clearString = new string[1];
        clearString[0] = "clear";
        keywordRecognizer.Dispose();

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray(), ConfidenceLevel.Low);
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start(); // Starts listening to speech.

        Debug.Log("reset");
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void RunAction()
    {
        Debug.Log("Doing stuff");
    }

    private void OnApplicationQuit()
    {
        keywordRecognizer.OnPhraseRecognized -= RecognizedSpeech;
        keywordRecognizer.Dispose();
        Debug.Log("quit");
    }
}
