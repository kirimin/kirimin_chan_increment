using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    private GameObject gameManager;
    private GameManager gameManagerComponent;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetGameObject();
        gameManagerComponent = GameManager.GetInstance();
        gameManagerComponent.levelUpEvent.AddListener(UpdateBackGround);
        UpdateBackGround();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void UpdateBackGround() {
        foreach(Transform child in gameObject.transform){
            Destroy(child.gameObject);
        }
        var prefab = (GameObject)Resources.Load ("Prefabs/background" + gameManagerComponent.level);
        var background = Instantiate (prefab);
        background.transform.parent = transform;
        background.transform.position = transform.localPosition;
    }
}
