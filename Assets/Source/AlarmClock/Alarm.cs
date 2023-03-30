using UnityEngine;

public class Alarm : MonoBehaviour
{
    private int _currentHour;
    private int _currentMinute;

    public void OnAlarmButton()
    {
        _currentHour = LocalTime.Instance.CurrentHour;

        LocalTime.Instance.HoursChanched += (hours) =>
        {
            SetHour(hours);
            CheckTime();
        };

        LocalTime.Instance.MinutsChanched += (minuts) =>
        {
            SetMinute(minuts);
            CheckTime();
        };
    }

    private void OnDisable()
    {
        LocalTime.Instance.HoursChanched -= (hours) =>
        {
            SetHour(hours);
            CheckTime();
        };

        LocalTime.Instance.MinutsChanched -= (minuts) =>
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