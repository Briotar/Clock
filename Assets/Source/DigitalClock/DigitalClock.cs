using System;
using UnityEngine;

public class DigitalClock : MonoBehaviour
{
    private int _currentHours;
    private int _currentMinuts;
    private float _currentSeconds = 0;

    public event Action<int> HoursChanched;
    public event Action<int> MinutsChanched;

    private void Start()
    {
        WorldTimeGetter.Instance.TimeChecked += (hours, minuts) =>
        {
            SetStartTime(hours, minuts);
        };
    }

    private void OnDisable()
    {
        WorldTimeGetter.Instance.TimeChecked -= (hours, minuts) =>
        {
            SetStartTime(hours, minuts);
        };
    }

    private void Update()
    {
        if(_currentSeconds >= 0.05)
        {
            _currentSeconds = 0;
            _currentMinuts++;

            MinutsChanched.Invoke(_currentMinuts);

            if (_currentMinuts >= 59)
            {
                _currentMinuts = 0;
                _currentHours++;

                HoursChanched.Invoke(_currentHours);

                if (_currentHours > 23)
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
        }
    }

    private void SetStartTime(string hours, string minuts)
    {
        _currentHours = Int32.Parse(hours);
        _currentMinuts = Int32.Parse(minuts);

        MinutsChanched.Invoke(_currentMinuts);
        HoursChanched.Invoke(_currentHours);
    }
}