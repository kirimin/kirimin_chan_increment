using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    private GameObject gameManager;
    private GameManager gameManagerComponent;
    private int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetGameObject();
        gameManagerComponent = GameManager.GetInstance();
        currentLevel = 0;
        UpdateBackGround(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLevel != gameManagerComponent.level) {
            UpdateBackGround(gameManagerComponent.level);
            currentLevel = gameManagerComponent.level;
        }
    }

    private void UpdateBackGround(int level) {
        foreach(Transform child in gameObject.transform){
            Destroy(child.gameObject);
        }
        var prefab = (GameObject)Resources.Load ("Prefabs/background" + level);
        var background = Instantiate (prefab);
        background.transform.parent = transform;
        background.transform.position = transform.localPosition;
    }
}
