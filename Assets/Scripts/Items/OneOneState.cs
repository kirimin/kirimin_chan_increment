using UnityEngine;

public class OneOneState : MonoBehaviour, ItemState
{
    private MoveAction moveAction = new MoveAction();

    int ItemState.GetLevel() {
        return 0;
    }

    int ItemState.GetCanTakePlayerSize() {
        return 30;
    }

    int ItemState.GetRewardSize() {
        return 3;
    }

    void ItemState.Move(float speed) {
        moveAction.Straight(transform, speed);
        // moveAction.Rotate(transform, 2);
    }
}
