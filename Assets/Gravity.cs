using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gravity : MonoBehaviour
{
    /// <summary>
    /// ������ ��������� ��������
    /// </summary>
    private GameObject[] gravityObject;

    /// <summary>
    /// �������������� ���������� G * 100 000 000
    /// </summary>
    private float g = 6.6743e-03f;

    /// <summary>
    /// Rigidbody ������� ���������� �������
    /// </summary>
    private Rigidbody rb;

    /// <summary>
    /// ������ Rigidbody �������� GravityObject
    /// </summary>
    private List<Rigidbody> gravityObjectRBs = new List<Rigidbody>();

    /// <summary>
    /// ������ Gravity �������� GravityObject
    /// </summary>
    private List<Gravity> gravityObjectGavities = new List<Gravity>();

    /// <summary>
    /// ��������� ������� ��� �������
    /// </summary>
    public float impulse = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // �������� Rigidbody �������� �������
        Vector3 impulseDirection; // ����������� �������
        impulseDirection.x = 0;
        impulseDirection.y = 0;
        impulseDirection.z = 1;
        rb.AddForce(impulseDirection * impulse, ForceMode.Impulse); // ����� ��������� �������
    }


    void Update()
    {
        gravityObject = GameObject.FindGameObjectsWithTag("GravityObject"); // �������������� ������ ��������� �������� �� ���� GravityObject
        // �������������� ������ Rigidbody
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
                Vector3 direction = (transform.position - obj.position).normalized; // ����������� ���� �������
                float distance = (transform.position - obj.position).magnitude; // ���������� �� �������
                float gravForce = g * (rb.mass * obj.mass) / MathF.Pow(distance * 10000, 2); // ���� ������� �� ������� F = GMm/d^2
                obj.AddForce(direction * gravForce); // ��������� ����

            }
        }
    }
}
