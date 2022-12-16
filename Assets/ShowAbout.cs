using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Forms;

public class ShowAbout : MonoBehaviour
{
    public void onClick()
    {
        MessageBox.Show("Universe Simulator версии 1.0.0\n" +
            "Программа для симуляции поведения планетарной системы.\n \n" +
            "© Вихрянов Т. Д., 2022\n" +
            "Распространяется по лицензии MIT (см. файл License.txt в папке установки). \n \n" +
            "Текстуры звёзд, планет и небесной сферы взяты с сайта https://cosmos-online.ru/textures.\n" +
            "Иконка программы взята с сайта https://www.flaticon.com/ru/free-icons/ (автор — Freepic).", "О программе");
    }
}
