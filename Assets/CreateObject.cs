using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateObject : MonoBehaviour
{
    /// <summary>
    /// ������ �� �������, ������� ����� �����������
    /// </summary>
    public GameObject Object;

    /// <summary>
    /// ������ �� ��������� ���� � ����������� ������� �� ������������
    /// </summary>
    public GameObject distanceInputField;

    /// <summary>
    /// ���������� ������� �� ������
    /// </summary>
    public float distance;

    /// <summary>
    /// ������ �� ��������� ���� � ������ ������� �� ������������
    /// </summary>
    public GameObject massInputField;

    /// <summary>
    /// ����� �������
    /// </summary>
    public float mass;

    /// <summary>
    /// ������ �� ��������� ���� � ��������� ��������� �� ������������
    /// </summary>
    public GameObject impulseInputField;

    /// <summary>
    /// ��������� ������� �������
    /// </summary>
    public float impulse;

    /// <summary>
    /// ������ �� ��������� ���� � ��������� �� ������������
    /// </summary>
    public GameObject diameterInputField;

    /// <summary>
    /// ������� �������
    /// </summary>
    public float diameter;

    /// <summary>
    /// ������ �� ������ � ������ �� ������������
    /// </summary>
    public GameObject colorDropDown;

    /// <summary>
    /// ���� �������
    /// </summary>
    public string color;

    /// <summary>
    /// ����������� �� ���������� �� �����?
    /// </summary>
    public bool fromFile = false;

    /// <summary>
    /// ��������� ��� ��������� ���� �������
    /// </summary>
    public Material[] materials;

    /// <summary>
    /// ����� ��������� �������
    /// </summary>
    public void setObjectParams()
    {
        Rigidbody rigidbody = Object.GetComponent<Rigidbody>(); // ��������� Rigidbody �������
        Gravity gravity = Object.GetComponent<Gravity>();

        if (!fromFile)
        {
            Text distanceText = distanceInputField.GetComponent<Text>(); // ��������� Text ���� ��� ����������
            Text massText = massInputField.GetComponent<Text>(); // ��������� Text ���� ��� �����
            Text impulseText = impulseInputField.GetComponent<Text>(); // ��������� Text ���� ��� ���������� ��������
            Text radiusText = diameterInputField.GetComponent<Text>(); // ��������� Text ���� ��� �������
            Text colorLabel = colorDropDown.GetComponent<Text>(); // ��������� Text ����������� ������


            if (float.TryParse(distanceText.text, out distance)
                && float.TryParse(massText.text, out mass)
                && float.TryParse(impulseText.text, out impulse)
                && float.TryParse(radiusText.text, out diameter))
            {
                color = colorLabel.text;
                rigidbody.mass = mass; // ����� ����� �������
                gravity.impulse = impulse; // ����� ��������� �������
                Object.transform.localScale = new Vector3(diameter, diameter, diameter);
            }
        }
        else
        {
            rigidbody.mass = mass; // ����� ����� �������
            gravity.impulse = impulse; // ����� ��������� �������
            Object.transform.localScale = new Vector3(diameter, diameter, diameter);
        }

        if (name == "Star" || name == "Star(Clone)")
        {
            var light = transform.GetChild(0);
            switch (color)
            {
                case "������":
                    GetComponent<MeshRenderer>().material = materials[0];
                    light.gameObject.GetComponent<Light>().color = Color.white;
                    break;
                case "�������":
                    GetComponent<MeshRenderer>().material = materials[1];
                    light.gameObject.GetComponent<Light>().color = new Color(1, .5f, .5f);
                    break;
                case "�������":
                    GetComponent<MeshRenderer>().material = materials[2];
                    light.gameObject.GetComponent<Light>().color = new Color(.6f, .95f, 1);
                    break;
            }
        }

        if (name == "Planet" || name == "Planet(Clone)")
        {
            switch (color)
            {
                case "��������":
                    GetComponent<MeshRenderer>().material = materials[0];
                    break;
                case "������":
                    GetComponent<MeshRenderer>().material = materials[1];
                    break;
                case "�����":
                    GetComponent<MeshRenderer>().material = materials[2];
                    break;
                case "����":
                    GetComponent<MeshRenderer>().material = materials[3];
                    break;
                case "������":
                    GetComponent<MeshRenderer>().material = materials[4];
                    break;
                case "������":
                    GetComponent<MeshRenderer>().material = materials[5];
                    break;
                case "����":
                    GetComponent<MeshRenderer>().material = materials[6];
                    break;
                case "������":
                    GetComponent<MeshRenderer>().material = materials[7];
                    break;
                case "����":
                    GetComponent<MeshRenderer>().material = materials[8];
                    break;
            }

        }

    }

    public void onClick()
    {
        setObjectParams();
        Instantiate(Object, new Vector3(distance, 0, 0), new Quaternion(0, 0, 0, 0)).SetActive(true); // ������ ������ �� ���������� distance � ������� ���������
    }

    public void OnMouseDown()
    {
        fromFile = false;
        setObjectParams();
    }
}
