using UnityEngine;

public class OneZeroState : MonoBehaviour, ItemState
{
    private MoveAction moveAction = new MoveAction();
    int ItemState.GetLevel() {
        return 0;
    }

    int ItemState.GetSize() {
        return 2;
    }

    void ItemState.Move(float speed) {
        moveAction.Straight(transform, speed);
    }
}
