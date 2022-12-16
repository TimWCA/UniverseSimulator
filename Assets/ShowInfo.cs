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
            (name == "Planet(Clone)" ? "�������" : name == "Star(Clone)" ? "������" : "") +
            "\n�������: " + transform.localScale.x +
            "\n�����: " + GetComponent<Rigidbody>().mass+
            "\n���������� �� ������: " + transform.position.magnitude;
    }
}
