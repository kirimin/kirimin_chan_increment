using UnityEngine;

public class TriangleState : MonoBehaviour, ItemState
{
    private MoveAction moveAction = new MoveAction();
    int ItemState.GetLevel() {
        return 1;
    }

    int ItemState.GetSize() {
        return 12;
    }

    void ItemState.Move(float speed) {
        moveAction.Straight(transform, speed);
        moveAction.Rotate(transform, 1);
    }
}
