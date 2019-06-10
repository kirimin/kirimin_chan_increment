using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGeneretor : MonoBehaviour
{
    private readonly float GENERATE_Y_RANGE = 5f;
    private readonly float SPEED_COEFFICIENT_BY_LEVEL = 0.9f;
    private readonly float SCALE_COEFFICIENT_BY_LEVEL = 0.5f;
    private readonly float GABARAGE_POSITOIN = -10f;

    private List<GameObject> items = new List<GameObject>();
    private GameObject gameManager;
    private GameManager gameManagerComponent;

    private int currentLevel;
    private Coroutine coroutine;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetGameObject();
        gameManagerComponent = GameManager.GetInstance();
        CreateCoroutine();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLevel != gameManagerComponent.level) {
            CreateCoroutine();
            currentLevel = gameManagerComponent.level;
            return;
        }
    }

    public void ClaerAllItems() {
        foreach(Transform child in gameObject.transform){
            Destroy(child.gameObject);
        }
        items.Clear();
    }

    private void CreateCoroutine() {
        var itemNameList = new List<string>();
        var prefabList = new List<GameObject>();
        itemNameList = Const.ItemConst.ItemLevels[gameManagerComponent.level];
        foreach(var itemName in itemNameList) {
            prefabList.Add((GameObject)Resources.Load ("Prefabs/" + itemName));
        }
        if (coroutine != null) {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(GenerateItem(prefabList, gameManagerComponent.level));
    }

    private IEnumerator GenerateItem(List<GameObject> prefabList, int level) 
    {
        while(true) {
            // if (level != gameManagerComponent.level) {
            //     yield break;
            // }
            var prefab = prefabList[Random.Range(0, prefabList.Count)];
            var instancedItem = Instantiate (prefab);
            var state = instancedItem.GetComponent<ItemState>();
            var SpriteRenderer = instancedItem.GetComponent<SpriteRenderer>();
            var controller = instancedItem.GetComponent<ItemController>();

            // set item position
            instancedItem.transform.parent = transform;
            instancedItem.transform.position = transform.localPosition;
            instancedItem.transform.Translate(0, Random.Range(-GENERATE_Y_RANGE, GENERATE_Y_RANGE), 0);
            //  define item state
            controller.speed = controller.speed * SPEED_COEFFICIENT_BY_LEVEL / (state.GetLevel() + 1) * (gameManagerComponent.level + 1);
            controller.scale = controller.scale * SCALE_COEFFICIENT_BY_LEVEL * (state.GetLevel() + 1) / (gameManagerComponent.level + 1);
            if (state.GetLevel() > gameManagerComponent.level) {
                SpriteRenderer.color = Const.ColorConst.RED;
            } else {
                SpriteRenderer.color = Const.ColorConst.BLUE;
            }
            items.Add(instancedItem);
            // collect gabarage items
            foreach (var item in items) {
                if (item != null && item.transform.position.x < GABARAGE_POSITOIN) {
                    Destroy(item);
                }
            }
            // waiting
            yield return new WaitForSeconds(0.3f);
        }
    }
}