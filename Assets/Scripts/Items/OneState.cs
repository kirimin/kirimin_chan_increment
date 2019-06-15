using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneState : MonoBehaviour, ItemState
{
    private MoveAction moveAction = new MoveAction();
    int ItemState.GetLevel() {
        return 0;
    }

    int ItemState.GetSize() {
        return 1;
    }

    void ItemState.Move(float speed) {
        moveAction.Straight(transform, speed);
    }
}
