using UnityEngine;

public class ItemController : MonoBehaviour
{
    private readonly int DECREASE_TIME = 10;
    private readonly int ADD_TIME = 5;
    private readonly float SPEED_COEFFICIENT_BY_LEVEL = 0.5f;
    private readonly float SCALE_COEFFICIENT_BY_LEVEL = 0.75f;
    [SerializeField] float speed;
    [SerializeField] float scale;
    private GameObject gameManager;
    private GameManager gameManagerComponent;
    private SpriteRenderer spriteRenderer;
    private ItemState state;
    private Vector3 localScale;
    private float actualSpeed;
    private float actualScale;

    public void UpdateState() {
        actualSpeed = speed * SPEED_COEFFICIENT_BY_LEVEL / (state.GetLevel() + 1) * (gameManagerComponent.level + 1);
        actualScale = scale * SCALE_COEFFICIENT_BY_LEVEL * (state.GetLevel() + 1) / (gameManagerComponent.level + 1);
        
        transform.localScale = new Vector3(localScale.x * actualScale, localScale.y * actualScale, localScale.z * actualScale);
        if (state.GetCanTakePlayerSize() > gameManagerComponent.size) {
            spriteRenderer.color = Const.ColorConst.RED;
        } else {
            spriteRenderer.color = Const.ColorConst.BLUE;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        state = GetComponent<ItemState>();
        gameManager = GameManager.GetGameObject();
        gameManagerComponent = GameManager.GetInstance();
        gameManagerComponent.updateSizeEvent.AddListener(UpdateState);

        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateState();
    }

    // Update is called once per frame
    void Update()
    {
        state.Move(actualSpeed);
    }

    void OnTriggerEnter2D(Collider2D c) {
        if (gameManagerComponent.size >= state.GetCanTakePlayerSize()) {
            gameManagerComponent.size += state.GetRewardSize();
            gameManagerComponent.updateSizeEvent.Invoke();
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
