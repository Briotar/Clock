using UnityEngine;

[RequireComponent(typeof(AlarmClock))]
public class AlarmClockView : MonoBehaviour
{
    [SerializeField] private Transform _hourHand;
    [SerializeField] private Transform _minuteHand;

    private AlarmClock _alarmClock;

    private void Start()
    {
        _alarmClock = GetComponent<AlarmClock>();
    }

    public void OnAlarmButton()
    {
        _alarmClock.SetAlarmTime(_hourHand.eulerAngles.z, _minuteHand.eulerAngles.z);
    }
}