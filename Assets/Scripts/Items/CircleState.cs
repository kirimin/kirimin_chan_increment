using UnityEngine;

public class CircleState : MonoBehaviour, ItemState
{

    int ItemState.GetLevel() {
        return 1;
    }

    private MoveAction moveAction = new MoveAction();
    int ItemState.GetCanTakePlayerSize() {
        return 120;
    }

    int ItemState.GetRewardSize() {
        return 20;
    }

    void ItemState.Move(float speed) {
        moveAction.Straight(transform, speed);
        moveAction.Rotate(transform, 1);
    }
}
