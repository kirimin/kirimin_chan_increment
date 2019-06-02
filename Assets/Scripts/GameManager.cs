using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float time;
    private GameObject timerText;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GameObject.Find("TimerText");
        time = 60;
    }

    // Update is called once per frame
    void Update()
    {
        time = time - Time.deltaTime;
        timerText.GetComponent<Text>().text = ((int)time).ToString();
    }
}
