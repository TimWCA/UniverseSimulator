using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class SaveToFile : MonoBehaviour
{
    [System.Serializable]
    public class Objects
    {
        public List<GravityObject> obj = new();
    }

    [System.Serializable]
    public class GravityObject
    {
        public float diameter;
        public float distance;
        public float mass;
        public float impulse;
        public string name;
        public string color;
    }

    public static void onClick()
    {
        var sfd = new SaveFileDialog();
        sfd.Filter = "JSON file (*.json)|*.json";
        sfd.Title = "Сохранить как...";

        if (sfd.ShowDialog() == DialogResult.OK)
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("GravityObject");
            Objects objects = new();
            foreach (GameObject obj in gameObjects)
            {
                objects.obj.Add(new GravityObject()
                {
                    diameter = obj.GetComponent<CreateObject>().diameter,
                    distance = obj.GetComponent<CreateObject>().distance,
                    mass = obj.GetComponent<CreateObject>().mass,
                    impulse = obj.GetComponent<CreateObject>().impulse,
                    color = obj.GetComponent<CreateObject>().color,
                    name = obj.name
                });
            }
            File.Create(sfd.FileName).Close();
            File.WriteAllText(sfd.FileName, JsonConvert.SerializeObject(objects));
        }
        else MessageBox.Show("Файл не сохранён!");
    }

    
}
