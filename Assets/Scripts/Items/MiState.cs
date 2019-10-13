using UnityEngine;

public class MiState : MonoBehaviour, ItemState
{
    private bool isUp;


    void Start() {
        isUp = Random.Range(0, 2) == 0 ? true : false;
    }

    private MoveAction moveAction = new MoveAction();

    int ItemState.GetLevel() {
        return 2;
    }

    int ItemState.GetCanTakePlayerSize() {
        return 800;
    }

    int ItemState.GetRewardSize() {
        return 50;
    }

    void ItemState.Move(float speed) {
        moveAction.Straight(transform, speed);
        moveAction.Rotate(transform, 1);
        if (isUp) {
            moveAction.Up(transform, 0.01f);
        } else {
            moveAction.Down(transform, 0.01f);
        }
    }
}
