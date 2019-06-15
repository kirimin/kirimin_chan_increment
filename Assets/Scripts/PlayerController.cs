using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed;

    private GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.125f;
        background = GameObject.Find("BackGroundHolder");
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        transform.Translate(x * speed, y * speed, 0);
        background.transform.Translate(x * -speed / 20, y * -speed / 25, 0);
    }
}
