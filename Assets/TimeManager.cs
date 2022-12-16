using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public GameObject slider;
    
    public void OnValueChanged()
    {
        Slider slid = slider.GetComponent<Slider>();
        Time.timeScale = slid.value;
    }
}
