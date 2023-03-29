using UnityEngine;
using UnityEngine.UI;

public class ChooseAlarm : MonoBehaviour
{
    [SerializeField] private Button _chooseButton;
    [SerializeField] private GameObject _choosePanel;
    [SerializeField] private GameObject _digitalAlarmClock;
    [SerializeField] private GameObject _analogAlarmClock;
    [SerializeField] private GameObject _alarmClock;

    public void OnChooseAlarmButton()
    {
        _chooseButton.gameObject.SetActive(false);
        _choosePanel.SetActive(true);
    }

    public void OnDigitalAlarm()
    {
        _choosePanel.SetActive(false);
        _digitalAlarmClock.SetActive(true);

    }

    public void OnAnalogAlarm()
    {
        _choosePanel.SetActive(false);
        _analogAlarmClock.SetActive(true);
        _alarmClock.SetActive(true);
    }
}