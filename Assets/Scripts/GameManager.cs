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

    public AudioSource itemGetSound;
    public AudioSource damageSound;
    public AudioSource levelUpSound;
    public float time;
    public int level;
    public int size;

    private GameObject sizeText;
    private GameObject timerText;
    private GameObject levelText;
    private GameObject nextText;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GameObject.Find("TimerText");
        levelText = GameObject.Find("LevelText");
        sizeText = GameObject.Find("SizeText");
        nextText = GameObject.Find("NextText");
        time = 60;
        size = 1;
        level = 0;
        var sources = GetComponents<AudioSource>();
        itemGetSound = sources[0];
        damageSound = sources[1];
        levelUpSound = sources[2];
    }

    // Update is called once per frame
    void Update()
    {
        time = time - Time.deltaTime;
        timerText.GetComponent<Text>().text = ((int)time).ToString();
        sizeText.GetComponent<Text>().text = size.ToString() + "byte";
        levelText.GetComponent<Text>().text = level.ToString();
        nextText.GetComponent<Text>().text = Level.GetNext(level).ToString() + "byte";
        var currentLevel = level;
        level = Level.getLevel(size);
        if (currentLevel != level) {
            var itemGenerator = GameObject.Find("ItemGenerator");
            var generatorComponent = itemGenerator.GetComponent<ItemGeneretor>();
            generatorComponent.ClaerAllItems();
            levelUpSound.PlayOneShot(levelUpSound.clip);
        }
    }
}
