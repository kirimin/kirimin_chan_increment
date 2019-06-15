using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;

    private GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.1f;
        background = GameObject.Find("BackGroundHolder");
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        transform.Translate(x * speed, y * speed, 0);
        background.transform.Translate(x * -speed / 25, y * -speed / 50, 0);
    }
}
