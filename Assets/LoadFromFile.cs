using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

public class LoadFromFile : MonoBehaviour
{
    public GameObject star;
    public GameObject planet;

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
    public void onClick()
    {
        var ofd = new OpenFileDialog();
        ofd.Filter = "JSON file (*.json)|*.json";
        ofd.Title = "Загрузить из файла...";

        if (ofd.ShowDialog() == DialogResult.OK)
        {
            GameObject[] GravObjs = GameObject.FindGameObjectsWithTag("GravityObject");
            foreach (var GravObj in GravObjs)
            {
                Destroy(GravObj);
            }
            Objects objects = new();
            objects = JsonConvert.DeserializeObject<Objects>(File.ReadAllText(ofd.FileName));
            foreach (GravityObject obj in objects.obj)
            {
                if (obj.name == "Planet(Clone)")
                {
                    planet.GetComponent<CreateObject>().fromFile = true;
                    planet.GetComponent<CreateObject>().name = "Planet";
                    planet.GetComponent<CreateObject>().distance = obj.distance;
                    planet.GetComponent<CreateObject>().diameter = obj.diameter;
                    planet.GetComponent<CreateObject>().mass = obj.mass;
                    planet.GetComponent<CreateObject>().impulse = obj.impulse;
                    planet.GetComponent<CreateObject>().color = obj.color;
                    planet.GetComponent<CreateObject>().onClick();
                    planet.GetComponent<CreateObject>().fromFile = false;
                }
                if (obj.name == "Star(Clone)")
                {
                    star.GetComponent<CreateObject>().fromFile = true;
                    star.GetComponent<CreateObject>().name = "Star";
                    star.GetComponent<CreateObject>().distance = obj.distance;
                    star.GetComponent<CreateObject>().diameter = obj.diameter;
                    star.GetComponent<CreateObject>().mass = obj.mass;
                    star.GetComponent<CreateObject>().impulse = obj.impulse;
                    star.GetComponent<CreateObject>().color = obj.color;
                    star.GetComponent<CreateObject>().onClick();
                    star.GetComponent<CreateObject>().fromFile = false;
                }
            }
        }
    }
}
