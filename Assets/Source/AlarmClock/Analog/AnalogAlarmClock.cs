using UnityEngine;

[RequireComponent(typeof(AnalogAlarmTime))]
public class AnalogAlarmClock : Alarm
{
    [SerializeField] private AnalogClock _analogClock;
    private AnalogAlarmTime _analogAlarmTime;

    private void Start()
    {
        _analogAlarmTime = GetComponent<AnalogAlarmTime>();
    }

    protected override void CheckTime()
    {
        //Debug.Log("Curr hour rotation: " + _analogClock.HourHandRotation);
        //Debug.Log("Curr minute rotation: " + _analogClock.MinuteHandRotation);

        float diffHour = Mathf.Abs(_analogClock.HourHandRotation - _analogAlarmTime.HourAlarmRotation);
        float diffMinute = Mathf.Abs(_analogClock.MinuteHandRotation - _analogAlarmTime.MinuteAlarmRotation);

        //Debug.Log((int)diffHour + "разница в часе в инте");
        //Debug.Log((int)diffMinute + "разница в минутах в инте");

        if (diffHour <= 0.1f && diffMinute <= 0.1f)
        {
            Debug.Log("ALARM!!!!!!!!!!!!!!!!");
        }
    }
}