using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateObject : MonoBehaviour
{
    /// <summary>
    /// Ссылка на планету, которую нужно скопировать
    /// </summary>
    public GameObject Object;

    /// <summary>
    /// Ссылка на текстовое поле с расстоянием планеты от пользователя
    /// </summary>
    public GameObject distanceInputField;

    /// <summary>
    /// Расстояние объекта от центра
    /// </summary>
    public float distance;

    /// <summary>
    /// Ссылка на текстовое поле с массой планеты от пользователя
    /// </summary>
    public GameObject massInputField;

    /// <summary>
    /// Масса объекта
    /// </summary>
    public float mass;

    /// <summary>
    /// Ссылка на текстовое поле с начальным импульсом от пользователя
    /// </summary>
    public GameObject impulseInputField;

    /// <summary>
    /// Начальный импульс объекта
    /// </summary>
    public float impulse;

    /// <summary>
    /// Ссылка на текстовое поле с диаметром от пользователя
    /// </summary>
    public GameObject diameterInputField;

    /// <summary>
    /// Диаметр объекта
    /// </summary>
    public float diameter;

    /// <summary>
    /// Ссылка на список с цветом от пользователя
    /// </summary>
    public GameObject colorDropDown;

    /// <summary>
    /// Цвет объекта
    /// </summary>
    public string color;

    /// <summary>
    /// Загружается ли информация из файла?
    /// </summary>
    public bool fromFile = false;

    /// <summary>
    /// Материалы для изменения вида объекта
    /// </summary>
    public Material[] materials;

    /// <summary>
    /// Задаёт параметры объекта
    /// </summary>
    public void setObjectParams()
    {
        Rigidbody rigidbody = Object.GetComponent<Rigidbody>(); // Компонент Rigidbody планеты
        Gravity gravity = Object.GetComponent<Gravity>();

        if (!fromFile)
        {
            Text distanceText = distanceInputField.GetComponent<Text>(); // Компонент Text поля для расстояния
            Text massText = massInputField.GetComponent<Text>(); // Компонент Text поля для массы
            Text impulseText = impulseInputField.GetComponent<Text>(); // Компонент Text поля для начального импульса
            Text radiusText = diameterInputField.GetComponent<Text>(); // Компонент Text поля для радиуса
            Text colorLabel = colorDropDown.GetComponent<Text>(); // Компонент Text выпадающего списка


            if (float.TryParse(distanceText.text, out distance)
                && float.TryParse(massText.text, out mass)
                && float.TryParse(impulseText.text, out impulse)
                && float.TryParse(radiusText.text, out diameter))
            {
                color = colorLabel.text;
                rigidbody.mass = mass; // Задаём массу планеты
                gravity.impulse = impulse; // Задаём начальный импульс
                Object.transform.localScale = new Vector3(diameter, diameter, diameter);
            }
        }
        else
        {
            rigidbody.mass = mass; // Задаём массу планеты
            gravity.impulse = impulse; // Задаём начальный импульс
            Object.transform.localScale = new Vector3(diameter, diameter, diameter);
        }

        if (name == "Star" || name == "Star(Clone)")
        {
            var light = transform.GetChild(0);
            switch (color)
            {
                case "Солнце":
                    GetComponent<MeshRenderer>().material = materials[0];
                    light.gameObject.GetComponent<Light>().color = Color.white;
                    break;
                case "Красный":
                    GetComponent<MeshRenderer>().material = materials[1];
                    light.gameObject.GetComponent<Light>().color = new Color(1, .5f, .5f);
                    break;
                case "Голубой":
                    GetComponent<MeshRenderer>().material = materials[2];
                    light.gameObject.GetComponent<Light>().color = new Color(.6f, .95f, 1);
                    break;
            }
        }

        if (name == "Planet" || name == "Planet(Clone)")
        {
            switch (color)
            {
                case "Меркурий":
                    GetComponent<MeshRenderer>().material = materials[0];
                    break;
                case "Венера":
                    GetComponent<MeshRenderer>().material = materials[1];
                    break;
                case "Земля":
                    GetComponent<MeshRenderer>().material = materials[2];
                    break;
                case "Марс":
                    GetComponent<MeshRenderer>().material = materials[3];
                    break;
                case "Юпитер":
                    GetComponent<MeshRenderer>().material = materials[4];
                    break;
                case "Сатурн":
                    GetComponent<MeshRenderer>().material = materials[5];
                    break;
                case "Уран":
                    GetComponent<MeshRenderer>().material = materials[6];
                    break;
                case "Нептун":
                    GetComponent<MeshRenderer>().material = materials[7];
                    break;
                case "Луна":
                    GetComponent<MeshRenderer>().material = materials[8];
                    break;
            }

        }

    }

    public void onClick()
    {
        setObjectParams();
        Instantiate(Object, new Vector3(distance, 0, 0), new Quaternion(0, 0, 0, 0)).SetActive(true); // Создаём объект на расстоянии distance с нулевым поворотом
    }

    public void OnMouseDown()
    {
        fromFile = false;
        setObjectParams();
    }
}
