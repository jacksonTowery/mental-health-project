using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine.UI;

public class Activities : MonoBehaviour
{
    GameObject Text;
    private void Start()
    {
        Text = GameObject.Find("Activity").transform.GetChild(1).gameObject.transform.GetChild(2).gameObject;
    }
    // Start is called before the first frame update
    void Update()
    {

    }
    public void Walk()
    {
        Text.transform.GetComponent<Text>().text = "Walk for: " + UnityEngine.Random.Range(10, 59) + " Minutes";
    }

    public void Exercise()
    {
        string[] exercises = new string[3]
        {
            "Sit-ups",
            "push-Ups",
            "Squats"
        };
        Text.transform.GetComponent<Text>().text = "Do " + UnityEngine.Random.Range(1, 4) + " sets of " + UnityEngine.Random.Range(8, 16) + " " + exercises[(int)UnityEngine.Random.Range(0, 2)];

    }

    public void Yoga()
    {
        string[] exercises = new string[3]
        {
            "Balasana",
            "TreePose",
            "Downward Dog"
        };
        Text.transform.GetComponent<Text>().text = "Do " + exercises[(int)UnityEngine.Random.Range(0, 2)] + UnityEngine.Random.Range(5, 10) + " Times " ;
    }
}
