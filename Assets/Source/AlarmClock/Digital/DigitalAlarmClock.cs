using UnityEngine;

public class DigitalAlarmClock : Alarm
{
    [SerializeField] private DigitalAlarmInput _digitalAlarmInput;
    [SerializeField] private AudioSource _audioSource;

    protected override void CheckTime()
    {
        int currHour = GetHour();
        int currMinute = GetMinute();

        if (currHour == _digitalAlarmInput.AlarmHour && currMinute == _digitalAlarmInput.AlarmMinute)
            _audioSource.Play();
    }
}