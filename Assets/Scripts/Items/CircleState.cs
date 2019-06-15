using UnityEngine;

public class CircleState : MonoBehaviour, ItemState
{
    private MoveAction moveAction = new MoveAction();
    int ItemState.GetLevel() {
        return 1;
    }

    int ItemState.GetSize() {
        return 20;
    }

    void ItemState.Move(float speed) {
        moveAction.Straight(transform, speed);
        moveAction.Rotate(transform, 1);
    }
}
