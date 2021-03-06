﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Sprite nomalSprite;
    public Sprite damageSprite;
    
    private GameObject gameManager;
    private GameManager gameManagerComponent;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private float speed;
    private GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer.sprite = nomalSprite;
        speed = 0.125f;
        background = GameObject.Find("BackGroundHolder");
        gameManager = GameManager.GetGameObject();
        gameManagerComponent = GameManager.GetInstance();
        gameManagerComponent.itemGetEvent.AddListener(ChangeToNomalSprite);
        gameManagerComponent.damageEvent.AddListener(ChangeToDamageSprite);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 topLeft = gameManagerComponent.mainCamera.ScreenToWorldPoint(Vector3.zero);
        Vector3 bottomRight = gameManagerComponent.mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        if (transform.position.x < topLeft.x && x < 0) {
            x = 0;
        }
        if (transform.position.y < topLeft.y && y < 0) {
            y = 0;
        }
        if (transform.position.x > bottomRight.x && x > 0) {
            x = 0;
        }
        if (transform.position.y > bottomRight.y && y > 0) {
            y = 0;
        }
        transform.Translate(x * speed, y * speed, 0);
        background.transform.Translate(x * -speed / 20, y * -speed / 25, 0);
        if (Input.GetKeyDown(KeyCode.Z)) {
            UseBomb();
        }
    }

    private void ChangeToDamageSprite() {
        animator.enabled = false;
        spriteRenderer.sprite = damageSprite;
    }

    private void ChangeToNomalSprite() {
        animator.enabled = true;
        spriteRenderer.sprite = nomalSprite;
    }

    private void UseBomb() {
            gameManagerComponent.useBombEvent.Invoke();
            gameManagerComponent.bombSound.PlayOneShot(gameManagerComponent.bombSound.clip);
            var effect = (GameObject)Resources.Load ("Prefabs/Effects/BombEffect");
            effect.transform.position = transform.position;
            Destroy(Instantiate(effect),effect.GetComponent<ParticleSystem>().main.duration);

            double newSize = gameManagerComponent.size * 0.5;
            gameManagerComponent.size = (int) newSize;
            gameManagerComponent.updateSizeEvent.Invoke();
    }
}
