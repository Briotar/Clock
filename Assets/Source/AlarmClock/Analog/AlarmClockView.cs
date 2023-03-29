using UnityEngine;

[RequireComponent(typeof(AnalogAlarmTime))]
public class AlarmClockView : MonoBehaviour
{
    [SerializeField] private Transform _hourHand;
    [SerializeField] private Transform _minuteHand;

    private AnalogAlarmTime _alarmClock;

    private void Start()
    {
        _alarmClock = GetComponent<AnalogAlarmTime>();
    }

    public void OnAlarmButton()
    {
        _alarmClock.SetAlarmTime(_hourHand.eulerAngles.z, _minuteHand.eulerAngles.z);
    }
}