using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;

public class WorldTimeGetter : MonoBehaviour
{
    [SerializeField] private string[] _urls;

    private string _currentHour;
    private string _currentMinute;

    public static WorldTimeGetter Instance;
    public string CurrentHour => _currentHour;
    public string CurrentMinute => _currentMinute;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(GetRealTime(_urls[0]));
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

        Debug.Log("Data: " + data);

        ParseTime(data);
    }

    private void ParseTime(string data)
    {
        string time = Regex.Match(data, @"\d{2}:\d{2}:\d{2}").Value;
        string[] parsedTime = time.Split(':');

        _currentHour = parsedTime[0];
        _currentMinute = parsedTime[1];

        Debug.Log(_currentHour);
        Debug.Log(_currentMinute);
    }
}