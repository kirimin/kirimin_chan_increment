using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] float speed;
    public float scale;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 defaultSize = transform.localScale;
        transform.localScale = new Vector3(defaultSize.x * scale, defaultSize.y * scale, defaultSize.z * scale);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D c) {
        var state = GetComponent<ItemState>();
        var gameManager = GameObject.Find("GameManager");
        var gameManagerComponent = gameManager.GetComponent<GameManager>();
        if (gameManagerComponent.level >= state.GetLevel()) {
            gameManagerComponent.size += state.GetSize();
        } else {
            gameManagerComponent.time -= 10;
        }
        Destroy(gameObject);
    }
}
