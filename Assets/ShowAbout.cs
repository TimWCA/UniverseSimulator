using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Forms;

public class ShowAbout : MonoBehaviour
{
    public void onClick()
    {
        MessageBox.Show("Universe Simulator ������ 1.0.0\n" +
            "��������� ��� ��������� ��������� ����������� �������.\n \n" +
            "� �������� �. �., 2022\n" +
            "���������������� �� �������� MIT (��. ���� License.txt � ����� ���������). \n \n" +
            "�������� ����, ������ � �������� ����� ����� � ����� https://cosmos-online.ru/textures.\n" +
            "������ ��������� ����� � ����� https://www.flaticon.com/ru/free-icons/ (����� � Freepic).", "� ���������");
    }
}
