using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private float elapseTime;
    
    private int _minute;
    public int hours = 8;

    public float timeLapse = 4f;
    public static Timer _instance;
    [HideInInspector] public bool isEnded;
    
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        
    }
    void Update()
    {
        if (!isEnded)
        {
            
        
            elapseTime += Time.deltaTime;

            if (_minute >= 60)
            {
                hours++;
                _minute = 0;
            }
        
            if (elapseTime >= timeLapse)
            {
                _minute += 15;
                elapseTime %= timeLapse;
            
            }
        
            timerText.text = $"{hours:00}:{_minute:00}";
        
        }
    }
}
