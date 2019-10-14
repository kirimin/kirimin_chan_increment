using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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

    public Camera mainCamera;
    public GameObject player;
    public UnityEvent levelUpEvent;
    public UnityEvent gameoverEvent;
    public UnityEvent updateSizeEvent;
    public UnityEvent itemGetEvent;
    public UnityEvent damageEvent;
    public UnityEvent useBombEvent;
    public AudioSource itemGetSound;
    public AudioSource itemGetSound2;
    public AudioSource damageSound;
    public AudioSource comboSound;
    public AudioSource levelUpSound;
    public AudioSource bombSound;
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
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        levelUpEvent = new UnityEvent();
        levelUpEvent.AddListener(OnLevelUp);
        gameoverEvent = new UnityEvent();
        gameoverEvent.AddListener(OnGameOver);
        updateSizeEvent = new UnityEvent();
        updateSizeEvent.AddListener(OnSizeChange);
        player = GameObject.Find("kirimin-chan");
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
        itemGetSound2 = sources[4];
        damageSound = sources[1];
        levelUpSound = sources[2];
        comboSound = sources[3];
        bombSound = sources[5];
    }

    // Update is called once per frame
    void Update()
    {
        time = time - Time.deltaTime;
        timerText.text = ((int)time).ToString();
        levelText.text = level.ToString();
        nextText.text = Level.GetNext(level).ToString() + "byte";
        var currentLevel = level;
        level = Level.getLevel(size);
        if (currentLevel != level) {
            levelUpEvent.Invoke();
        }
        if (time <= 0) {
            gameoverEvent.Invoke();
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

    private void OnSizeChange() {
        sizeText.text = size.ToString() + "byte";
    }

    private void OnGameOver() {
        SceneManager.LoadScene("TitleScene");
    }
}
