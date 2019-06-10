using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGeneretor : MonoBehaviour
{
    private readonly float GENERATE_Y_RANGE = 4f;
    private readonly float SPEED_COEFFICIENT_BY_LEVEL = 1f;
    private readonly float SCALE_COEFFICIENT_BY_LEVEL = 0.5f;
    private readonly float GABARAGE_POSITOIN = -25f;

    private List<GameObject> items = new List<GameObject>();
    private GameObject gameManager;
    private GameManager gameManagerComponent;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetGameObject();
        gameManagerComponent = GameManager.GetInstance();
        var itemNameList = new List<string>();
        var prefabList = new List<GameObject>();
        itemNameList = Const.ItemConst.ItemLevels[gameManagerComponent.level];
        foreach(var itemName in itemNameList) {
            prefabList.Add((GameObject)Resources.Load ("Prefabs/" + itemName));
        }
        StartCoroutine(GenerateItem(prefabList));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator GenerateItem(List<GameObject> prefabList) 
    {
        while(true) {
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
            controller.speed = controller.speed / (state.GetLevel() + SPEED_COEFFICIENT_BY_LEVEL);
            controller.scale = controller.scale * (state.GetLevel() + SCALE_COEFFICIENT_BY_LEVEL);
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
            yield return new WaitForSeconds(1f);
        }
    }
}