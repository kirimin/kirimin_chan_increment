using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGeneretor : MonoBehaviour
{
    private List<GameObject> items = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        var itemNameList = new List<string>();
        var prefabList = new List<GameObject>();
        itemNameList = Const.Const.ItemLevels[0];
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
            instancedItem.transform.parent = transform;
            instancedItem.transform.position = transform.localPosition;
            instancedItem.transform.Translate(0, Random.Range(-4f, 4f), 0);
            var state = instancedItem.GetComponent<ItemState>();
            var SpriteRenderer = instancedItem.GetComponent<SpriteRenderer>();
            var controller = instancedItem.GetComponent<ItemController>();
            var gameManager = GameObject.Find("GameManager");
            var gameManagerComponent = gameManager.GetComponent<GameManager>();
            if (state.GetLevel() > gameManagerComponent.level) {
                // instancedItem.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                controller.scale = 1f;
                SpriteRenderer.color = Color.red;
            } else {
                controller.scale = 0.5f;
                // instancedItem.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                SpriteRenderer.color = Color.blue;
            }
            items.Add(instancedItem);
            
            for (int i = items.Count - 1; i >= 0; i--) {
                var item = items[i];
                if (item != null && item.transform.position.x < -25f) {
                    Destroy(item);
                }
            }
            yield return new WaitForSeconds(1);
        }
    }
}