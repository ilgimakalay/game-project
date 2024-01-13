using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using System;
using System.Threading.Tasks;
using UnityEngine.InputSystem.HID;

public class DayNightScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hungry;
    [SerializeField] private TextMeshProUGUI energy;
    [SerializeField] private TextMeshProUGUI clock;
    [SerializeField] private TextMeshProUGUI day;
    [SerializeField] private TextMeshProUGUI agi;
    [SerializeField] private TextMeshProUGUI str;
    [SerializeField] private TextMeshProUGUI sta;

    public Button TrainStart;
    public GameObject TrainEndObject;


    public float tick;

    [SerializeField] private int minutes;
    [SerializeField] private int hours;
    [SerializeField] private int days = 1;

    private Button TrainEnd;

    //gptgptpgt
    private bool isCounting = false;
    private int n = 0;
    private int control_number = 0;

    private int _timeDifference;
    private long _timeIncrease;
    private long _currentTime;
    private long _startTime;


    private int _energyIncreaseValue = 100;
    private int _hungryIncreaseValue = 100;

    private int _strengthIncreaseValue = 1;
    private int _staminaIncreaseValue = 1;
    private int _agilityIncreaseValue = 1;


    private bool _trainContinue = false;


    private void Start()
    {
        SetEndTrainButton();
        TrainStart.onClick.AddListener(StartCounting);
        TrainEnd.onClick.AddListener(StopCounting);
    }


    private void EndTrainButtonEnabled(bool buttonState)
    {
        TrainEndObject.SetActive(buttonState);
    }

    private void StartTrainButtonEnabled(bool startButtonState)
    {
        TrainStart.enabled = startButtonState;
    }


    private void SetEndTrainButton()
    {
        TrainEnd = TrainEndObject.GetComponent<Button>();
    }


    void StopCounting()
    {
        isCounting = false;
        EndTrainButtonEnabled(false);
        StartTrainButtonEnabled(true);
    }

    void StartCounting()
    {
        isCounting = true;
        EndTrainButtonEnabled(true);
        StartTrainButtonEnabled(false);
        StartCoroutine(CountEveryFiveSeconds());
    }

    IEnumerator CountEveryFiveSeconds()
    {
        while (isCounting)
        {
            yield return new WaitForSeconds(5f);
            n++;
        }
    }

    void Update()
    {
        if (isCounting && control_number != n)
        {
            // Her 3 artışta otomatik olarak yazdır
            Debug.Log("n kac oldu: n = " + n);
            control_number = n;
        }
    }
    
    

    private void UpdateSkills()
    {
        _staminaIncreaseValue++;
        Debug.Log(_staminaIncreaseValue);
        _agilityIncreaseValue++;
        Debug.Log(_agilityIncreaseValue);
        _strengthIncreaseValue++;
        Debug.Log(_strengthIncreaseValue);
    }

    private void IncreaseNeeds()
    {
        _energyIncreaseValue++;
        _hungryIncreaseValue++;
    }

    private void DecreaseNeeds()
    {
        _energyIncreaseValue--;
        _hungryIncreaseValue--;
    }

    private void UpdateTimeText()
    {
        clock.text = string.Format("{0:00}:{1:00}", hours, minutes);
        day.text = "Day: " + days;
    }

    private void UpdateSkillsText()
    {
        agi.text = "AGI: " + _agilityIncreaseValue;
        sta.text = "STI:" + _staminaIncreaseValue;
        str.text = "STr:" + _strengthIncreaseValue;
    }

    private void UpdateNeedsText()
    {
        energy.text = "Energy:" + _energyIncreaseValue;
        hungry.text = "Hungry:" + _energyIncreaseValue;
    }
}