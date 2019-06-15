using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidUpdateState : MonoBehaviour, ItemState
{
    private MoveAction moveAction = new MoveAction();
    int ItemState.GetLevel() {
        return 3;
    }

    int ItemState.GetSize() {
        return 50;
    }

    void ItemState.Move(float speed) {
        moveAction.Straight(transform, speed);
        moveAction.Rotate(transform, 0.5f);
    }
}
