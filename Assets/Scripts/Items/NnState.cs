using System.Collections;
using UnityEngine;

public class NnState : MonoBehaviour, ItemState
{
    private bool isUp;
    private int count;

    void Start() {
        isUp = Random.Range(0, 2) == 0 ? true : false;
    }

    private MoveAction moveAction = new MoveAction();

    int ItemState.GetLevel() {
        return 2;
    }

    int ItemState.GetCanTakePlayerSize() {
        return 900;
    }

    int ItemState.GetRewardSize() {
        return 80;
    }

    void ItemState.Move(float speed) {
        moveAction.Straight(transform, speed);
        moveAction.Rotate(transform, 1);
        if (isUp) {
            moveAction.Up(transform, 0.05f);
        } else {
            moveAction.Down(transform, 0.05f);
        }
        count++;
        if (count == 30) {
            count = 0;
            isUp = Random.Range(0, 2) == 0 ? true : false;
        }
    }
}
