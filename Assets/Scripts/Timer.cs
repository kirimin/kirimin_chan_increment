using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "test";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
