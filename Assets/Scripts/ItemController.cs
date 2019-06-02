using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float scale;

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
        Destroy(gameObject);
    }
}
