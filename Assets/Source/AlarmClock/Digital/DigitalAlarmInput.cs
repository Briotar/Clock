using System;
using UnityEngine;
using TMPro;

public class DigitalAlarmInput : MonoBehaviour
{
    [SerializeField] private TMP_Text _alarmText;

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
            _alarmText.text = "Будильник прозвонит в " + _alarmHour + ":" + _alarmMinute;
        }
    }

    public void OnMinuteEntered(string minute)
    {
        if (Int32.TryParse(minute, out _alarmMinute))
        {
            if(_alarmMinute < 0 || _alarmMinute > 59)
            {
                Debug.Log("Неверный ввод!");
                return;
            }
            else
            {
                Debug.Log(_alarmMinute);
                _isMinuteEntered = true;
                CheckIsAlarmReady();
            }
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
            if(_alarmHour < 0 || _alarmHour > 23)
            {
                Debug.Log("Неверный ввод!");
                return;
            }
            else
            {
                Debug.Log(_alarmHour);
                _isHourEntered = true;
                CheckIsAlarmReady();
            }
        }
        else
        {
            Debug.Log("Неверный ввод!");
        }
    }

    public void AlarmOff()
    {
        _alarmMinute = -1;
        _alarmHour = -1;
    }
}