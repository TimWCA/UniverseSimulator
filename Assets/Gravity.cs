using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gravity : MonoBehaviour
{
    /// <summary>
    /// Список массивных объектов
    /// </summary>
    private GameObject[] gravityObject;

    /// <summary>
    /// Гравитационная постоянная G * 100 000 000
    /// </summary>
    private float g = 6.6743e-03f;

    /// <summary>
    /// Rigidbody данного массивного объекта
    /// </summary>
    private Rigidbody rb;

    /// <summary>
    /// Список Rigidbody объектов GravityObject
    /// </summary>
    private List<Rigidbody> gravityObjectRBs = new List<Rigidbody>();

    /// <summary>
    /// Список Gravity объектов GravityObject
    /// </summary>
    private List<Gravity> gravityObjectGavities = new List<Gravity>();

    /// <summary>
    /// Начальный импульс для объекта
    /// </summary>
    public float impulse = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Получаем Rigidbody текущего объекта
        Vector3 impulseDirection; // Направление вектора
        impulseDirection.x = 0;
        impulseDirection.y = 0;
        impulseDirection.z = 1;
        rb.AddForce(impulseDirection * impulse, ForceMode.Impulse); // Задаём начальный импульс
    }


    void Update()
    {
        gravityObject = GameObject.FindGameObjectsWithTag("GravityObject"); // Инициализируем список массивных объектов по тегу GravityObject
        // Инициализируем список Rigidbody
        foreach (GameObject obj in gravityObject)
        {
            if (!gravityObjectRBs.Contains(obj.GetComponent<Rigidbody>()))
            {
                gravityObjectRBs.Add(obj.GetComponent<Rigidbody>());
            }
        }
    }

    void FixedUpdate()
    {
        foreach (Rigidbody obj in gravityObjectRBs)
        {
            if ((obj != rb) && (obj != null))
            {
                Vector3 direction = (transform.position - obj.position).normalized; // Направление силы тяжести
                float distance = (transform.position - obj.position).magnitude; // Расстояние до объекта
                float gravForce = g * (rb.mass * obj.mass) / MathF.Pow(distance * 10000, 2); // Сила тяжести по формуле F = GMm/d^2
                obj.AddForce(direction * gravForce); // Применяем силу

            }
        }
    }
}
