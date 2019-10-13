using UnityEngine;

public class PixelState : MonoBehaviour, ItemState
{
    private MoveAction moveAction = new MoveAction();

    int ItemState.GetLevel() {
        return 1;
    }

    int ItemState.GetCanTakePlayerSize() {
        return 70;
    }

    int ItemState.GetRewardSize() {
        return 8;
    }

    void ItemState.Move(float speed) {
        moveAction.Straight(transform, speed);
        moveAction.Rotate(transform, 1);
    }
}
