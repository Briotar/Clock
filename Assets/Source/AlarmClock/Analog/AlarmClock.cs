using UnityEngine;

[RequireComponent(typeof(AnalogAlarmTime))]
public class AlarmClock : Alarm
{
    [SerializeField] private AnalogClock _analogClock;
    private AnalogAlarmTime _analogAlarmTime;

    private void Start()
    {
        _analogAlarmTime = GetComponent<AnalogAlarmTime>();
    }

    protected override void CheckTime()
    {
        float diffHour = Mathf.Abs(_analogClock.HourHandRotation - _analogAlarmTime.HourAlarmRotation);
        float diffMinute = Mathf.Abs(_analogClock.MinuteHandRotation - _analogAlarmTime.MinuteAlarmRotation);

        if (diffHour <= 0.1f && diffMinute <= 0.1f)
        {
            Debug.Log("ALARM!!!!!!!!!!!!!!!!");
        }
    }
}