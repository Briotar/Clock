using System;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;

public class WorldTimeGetter : MonoBehaviour
{
    [SerializeField] private string[] _urls;
    [SerializeField] private float _ckeckClockTime = 3600;

    private string _currentHour = "";
    private string _currentMinute;
    private string _currentSecond;

    private bool _isTimeGetted = false;
    private float _currentTime = 0;

    public static WorldTimeGetter Instance;
    public event Action<string, string, string> TimeChecked;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }

    private void Start()
    {
        GetTime();
    }

    private void Update()
    {
        if(_currentTime >= _ckeckClockTime)
        {
            GetTime();
            _currentTime = 0;
        }
        else
        {
            _currentTime += Time.deltaTime;
        }
    }

    private void GetTime()
    {
        StartCoroutine(GetRealTime(_urls[0]));

        if (_isTimeGetted == false)
            StartCoroutine(GetRealTime(_urls[1]));

        if (_isTimeGetted)
            _isTimeGetted = false;
    }

    private IEnumerator GetRealTime(string url)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        string data = "";

        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError)
            Debug.Log("Error: " + webRequest.error);
        else
            data = webRequest.downloadHandler.text;

        ParseTime(data);
    }

    private void ParseTime(string data)
    {
        string time = Regex.Match(data, @"\d{2}:\d{2}:\d{2}").Value;
        string[] parsedTime = time.Split(':');

        _currentHour = parsedTime[0];
        _currentMinute = parsedTime[1];
        _currentSecond = parsedTime[2];

        if (_currentHour != "")
            _isTimeGetted = true;

        TimeChecked.Invoke(_currentHour, _currentMinute, _currentSecond);
    }
}