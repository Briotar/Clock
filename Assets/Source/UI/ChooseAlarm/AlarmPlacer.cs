using UnityEngine;

public class AlarmPlacer : MonoBehaviour
{
    [SerializeField] private GameObject _digitalAlarmPanel;
    [SerializeField] private GameObject _analoglAlarmPanel;
    [SerializeField] private GameObject _alarmTimePanel;
    [SerializeField] private GameObject _analogAlarmTimePanel;
    [SerializeField] private GameObject _alarmClock;

    public void OnDigitalAlarm()
    {
        _digitalAlarmPanel.SetActive(false);
        _alarmTimePanel.SetActive(true);
    }

    public void OnAnalogAlarm()
    {
        _analoglAlarmPanel.SetActive(false);
        _analogAlarmTimePanel.SetActive(true);
        _alarmClock.SetActive(false);
    }
}