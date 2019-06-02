using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGeneretor : MonoBehaviour
{
    private List<GameObject> items = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        var prefab = (GameObject)Resources.Load ("Prefabs/SampleItem");
        StartCoroutine(GenerateItem(prefab));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator GenerateItem(GameObject prefab) 
    {
        while(true) {
            var sample = Instantiate (prefab);
            sample.transform.parent = transform;
            sample.transform.Translate(0, Random.Range(-4f, 4f), 0);
            items.Add(sample);
            
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