using UnityEngine;

public class PixelState : MonoBehaviour, ItemState
{
    private MoveAction moveAction = new MoveAction();
    int ItemState.GetLevel() {
        return 1;
    }

    int ItemState.GetSize() {
        return 8;
    }

    void ItemState.Move(float speed) {
        moveAction.Straight(transform, speed);
        moveAction.Rotate(transform, 1);
    }
}
