using UnityEngine;

[RequireComponent(typeof(AlarmClock))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private AnalogClock _analogClock;
    [SerializeField] private DigitalClock _digitalClock;
    private AlarmClock _alarmClock;

    public void OnAlarmButton()
    {
        _alarmClock = GetComponent<AlarmClock>();

        _digitalClock.HoursChanched += (hours) =>
        {
            CheckTime();
        };

        _digitalClock.MinutsChanched += (minuts) =>
        {
            CheckTime();
        };
    }

    private void CheckTime()
    {
        //Debug.Log("Minute hand rotation: " + _analogClock.MinuteHandRotation);
        //Debug.Log("Alarm rotation: " + _alarmClock.MinuteAlarmRotation);

        float diffHour = Mathf.Abs(_analogClock.HourHandRotation - _alarmClock.HourAlarmRotation);
        float diffMinute = Mathf.Abs(_analogClock.MinuteHandRotation - _alarmClock.MinuteAlarmRotation);

        if (diffHour <= 0.1f && diffMinute <= 0.1f)
        {
            Debug.Log("ALARM!!!!!!!!!!!!!!!!");
        }
    }
}