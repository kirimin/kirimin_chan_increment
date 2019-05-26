using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.1f;
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
