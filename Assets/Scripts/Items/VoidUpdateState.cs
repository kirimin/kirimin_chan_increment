using UnityEngine;

public class VoidUpdateState : MonoBehaviour, ItemState
{
    private MoveAction moveAction = new MoveAction();

    int ItemState.GetLevel() {
        return 3;
    }

    int ItemState.GetCanTakePlayerSize() {
        return 6000;
    }

    int ItemState.GetRewardSize() {
        return 50;
    }

    void ItemState.Move(float speed) {
        moveAction.Straight(transform, speed);
        moveAction.Rotate(transform, 0.5f);
    }
}
