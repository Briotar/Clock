using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private DigitalClock _digitalClock;

    private int _currentHour;
    private int _currentMinute;

    public void OnAlarmButton()
    {
        _currentHour = _digitalClock.CurrentHour;

        _digitalClock.HoursChanched += (hours) =>
        {
            SetHour(hours);
            CheckTime();
        };

        _digitalClock.MinutsChanched += (minuts) =>
        {
            SetMinute(minuts);
            CheckTime();
        };
    }

    private void OnDisable()
    {
        _digitalClock.HoursChanched -= (hours) =>
        {
            SetHour(hours);
            CheckTime();
        };

        _digitalClock.MinutsChanched -= (minuts) =>
        {
            SetMinute(minuts);
            CheckTime();
        };
    }

    private void SetHour(int hour)
    {
        _currentHour = hour;
    }

    private void SetMinute(int minute)
    {
        _currentMinute = minute;
    }

    protected int GetHour()
    {
        return _currentHour;
    }

    protected int GetMinute()
    {
        return _currentMinute;
    }

    protected virtual void CheckTime()
    {
    }
}