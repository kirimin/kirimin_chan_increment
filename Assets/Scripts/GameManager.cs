using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameObject GetGameObject() 
    {
        return GameObject.Find("GameManager");
    }

    public static GameManager GetInstance() 
    {
        return GetGameObject().GetComponent<GameManager>();
    }

    public float time;
    private GameObject timerText;

    public int level;
    public int size;
    private GameObject sizeText;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GameObject.Find("TimerText");
        time = 60;
        level = 0;
        sizeText = GameObject.Find("SizeText");
        size = 1;
    }

    // Update is called once per frame
    void Update()
    {
        time = time - Time.deltaTime;
        timerText.GetComponent<Text>().text = ((int)time).ToString();
        sizeText.GetComponent<Text>().text = size.ToString() + "byte";
    }
}
