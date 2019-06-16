using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[DefaultExecutionOrder(-1)]
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

    public UnityEvent levelUpEvent;
    public AudioSource itemGetSound;
    public AudioSource damageSound;
    public AudioSource comboSound;
    public AudioSource levelUpSound;
    public float time;
    public int level;
    public int size;
    public int comboCount;

    private Text sizeText;
    private Text timerText;
    private Text levelText;
    private Text nextText;

    // Start is called before the first frame update
    void Start()
    {
        levelUpEvent = new UnityEvent();
        levelUpEvent.AddListener(OnLevelUp);
        timerText = GameObject.Find("TimerText").GetComponent<Text>();
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        sizeText = GameObject.Find("SizeText").GetComponent<Text>();
        nextText = GameObject.Find("NextText").GetComponent<Text>();
        time = 60;
        size = 1;
        level = 0;
        comboCount = 0;
        var sources = GetComponents<AudioSource>();
        itemGetSound = sources[0];
        damageSound = sources[1];
        levelUpSound = sources[2];
        comboSound = sources[3];
    }

    // Update is called once per frame
    void Update()
    {
        time = time - Time.deltaTime;
        timerText.text = ((int)time).ToString();
        sizeText.text = size.ToString() + "byte";
        levelText.text = level.ToString();
        nextText.text = Level.GetNext(level).ToString() + "byte";
        var currentLevel = level;
        level = Level.getLevel(size);
        if (currentLevel != level) {
            levelUpEvent.Invoke();
        }
    }

    private void OnLevelUp() {
            var itemGenerator = GameObject.Find("ItemGenerator");
            var generatorComponent = itemGenerator.GetComponent<ItemGeneretor>();
            generatorComponent.ClaerAllItems();
            levelUpSound.PlayOneShot(levelUpSound.clip);
            var effect = (GameObject)Resources.Load ("Prefabs/Effects/LevelUpEffect");
            effect.transform.position = transform.position;
            Destroy(Instantiate(effect),effect.GetComponent<ParticleSystem>().main.duration);
    }
}
