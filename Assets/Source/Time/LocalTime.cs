using System;
using UnityEngine;

public class LocalTime : MonoBehaviour
{
    [SerializeField] private int _maxSecond = 59;

    private int _maxHour = 23;
    private int _maxMinute = 60;

    private int _currentHours;
    private int _currentMinuts;
    private float _currentSeconds = 0;

    public int CurrentHour => _currentHours;
    public event Action<int> HoursChanched;
    public event Action<int> MinutsChanched;
    public event Action<float> SecondsChanched;

    public static LocalTime Instance;

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
        WorldTimeGetter.Instance.TimeChecked += (hours, minuts, seconds) =>
        {
            SetWorldTime(hours, minuts, seconds);
        };
    }

    private void OnDisable()
    {
        WorldTimeGetter.Instance.TimeChecked -= (hours, minuts, seconds) =>
        {
            SetWorldTime(hours, minuts, seconds);
        };
    }

    private void Update()
    {
        if(_currentSeconds >= _maxSecond)
        {
            _currentSeconds = 0;
            _currentMinuts++;

            MinutsChanched.Invoke(_currentMinuts);

            if (_currentMinuts >= _maxMinute)
            {
                _currentMinuts = 0;
                _currentHours++;

                MinutsChanched.Invoke(_currentMinuts);
                HoursChanched.Invoke(_currentHours);

                if (_currentHours > _maxHour)
                {
                    _currentHours = 0;
                    _currentMinuts = 0;

                    MinutsChanched.Invoke(_currentMinuts);
                    HoursChanched.Invoke(_currentHours);
                }
            }
        }
        else
        {
            _currentSeconds += Time.deltaTime;

            SecondsChanched.Invoke(_currentSeconds);
        }
    }

    private void SetWorldTime(string hours, string minuts, string seconds)
    {
        _currentHours = Int32.Parse(hours);
        _currentMinuts = Int32.Parse(minuts);
        _currentSeconds = Int32.Parse(seconds);

        MinutsChanched.Invoke(_currentMinuts);
        HoursChanched.Invoke(_currentHours);
        SecondsChanched.Invoke(_currentSeconds);
    }
}