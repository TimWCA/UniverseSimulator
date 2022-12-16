using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInfo : MonoBehaviour
{
    public GameObject info;
    public void OnMouseEnter()
    {
        Text text = info.GetComponent<Text>();
        text.text =
            (name == "Planet(Clone)" ? "Планета" : name == "Star(Clone)" ? "Звезда" : "") +
            "\nДиаметр: " + transform.localScale.x +
            "\nМасса: " + GetComponent<Rigidbody>().mass+
            "\nРасстояние от центра: " + transform.position.magnitude;
    }
}
