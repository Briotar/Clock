using System;
using UnityEngine;

public class DigitalAlarmInput : MonoBehaviour
{
    private int _alarmMinute = -1;
    private int _alarmHour = -1;

    private bool _isHourEntered = false;
    private bool _isMinuteEntered = false;

    public int AlarmHour => _alarmHour;
    public int AlarmMinute => _alarmMinute;

    private void CheckIsAlarmReady()
    {
        if(_isHourEntered && _isMinuteEntered)
        {
            Debug.Log("Будьник готов!" + _alarmHour + " " + _alarmMinute);
        }
    }

    public void OnMinuteEntered(string minute)
    {
        if (Int32.TryParse(minute, out _alarmMinute))
        {
            Debug.Log(_alarmMinute);
            _isMinuteEntered = true;
            CheckIsAlarmReady();
        }
        else
        {
            Debug.Log("Неверный ввод!");
        }
    }

    public void OnHourEntered(string hour)
    {
        if(Int32.TryParse(hour, out _alarmHour))
        {
            Debug.Log(_alarmHour);
            _isHourEntered = true;
            CheckIsAlarmReady();
        }
        else
        {
            Debug.Log("Неверный ввод!");
        }
    }
}