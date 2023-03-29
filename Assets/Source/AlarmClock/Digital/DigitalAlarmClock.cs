using UnityEngine;

public class DigitalAlarmClock : Alarm
{
    [SerializeField] private DigitalAlarmInput _digitalAlarmInput;

    protected override void CheckTime()
    {
        int currHour = GetHour();
        int currMinute = GetMinute();

        //Debug.Log("Hour on lock:" + currHour);
        //Debug.Log("Minute on lock:" + currMinute);

        if (currHour == _digitalAlarmInput.AlarmHour && currMinute == _digitalAlarmInput.AlarmMinute)
        {
            Debug.Log("DIGITAL Alarm!!!!!!!!!!");
        }
    }
}