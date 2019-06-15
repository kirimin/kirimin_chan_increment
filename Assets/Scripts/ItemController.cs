using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private readonly int DECREASE_TIME = 15;
    private readonly int ADD_TIME = 1;
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
            gameManagerComponent.time += ADD_TIME;
            gameManagerComponent.itemGetSound.PlayOneShot(gameManagerComponent.itemGetSound.clip);
        } else {
            gameManagerComponent.time -= DECREASE_TIME;
            gameManagerComponent.damageSound.PlayOneShot(gameManagerComponent.damageSound.clip);
        }
        Destroy(gameObject);
    }
}
