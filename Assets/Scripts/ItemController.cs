using UnityEngine;

public class ItemController : MonoBehaviour
{
    private readonly int DECREASE_TIME = 10;
    private readonly int ADD_TIME = 5;
    public float speed;
    public float scale;
    private GameObject gameManager;
    private GameManager gameManagerComponent;
    private ItemState state;

    // Start is called before the first frame update
    void Start()
    {
        state = GetComponent<ItemState>();
        gameManager = GameManager.GetGameObject();
        gameManagerComponent = GameManager.GetInstance();
        Vector3 defaultSize = transform.localScale;
        transform.localScale = new Vector3(defaultSize.x * scale, defaultSize.y * scale, defaultSize.z * scale);
    }

    // Update is called once per frame
    void Update()
    {
        state.Move(speed);
    }

    void OnTriggerEnter2D(Collider2D c) {
        if (gameManagerComponent.level >= state.GetLevel()) {
            gameManagerComponent.size += state.GetSize();
            gameManagerComponent.itemGetSound.PlayOneShot(gameManagerComponent.itemGetSound.clip);
            gameManagerComponent.comboCount++;
            if (gameManagerComponent.comboCount == 10) {
                gameManagerComponent.time += ADD_TIME;
                gameManagerComponent.comboSound.PlayOneShot(gameManagerComponent.comboSound.clip);
            } else if (gameManagerComponent.comboCount == 20) {
                gameManagerComponent.time += ADD_TIME * 3;
                gameManagerComponent.comboSound.PlayOneShot(gameManagerComponent.comboSound.clip);
            } else if (gameManagerComponent.comboCount == 30) {
                gameManagerComponent.time += ADD_TIME * 4;
                gameManagerComponent.comboCount = 0;
                gameManagerComponent.comboSound.PlayOneShot(gameManagerComponent.comboSound.clip);
            }
            var effect = (GameObject)Resources.Load ("Prefabs/Effects/ItemGetEffect");
            effect.transform.position = transform.position;
            Destroy(Instantiate(effect),effect.GetComponent<ParticleSystem>().main.duration);
        } else {
            gameManagerComponent.time -= DECREASE_TIME;
            gameManagerComponent.damageSound.PlayOneShot(gameManagerComponent.damageSound.clip);
            gameManagerComponent.comboCount = 0;
        }
        Destroy(gameObject);
    }
}
