using UnityEngine;

public class BugState : MonoBehaviour, ItemState
{
    private MoveAction moveAction = new MoveAction();
     private bool isUp;
    private int count;
    
    int ItemState.GetLevel() {
        return 5;
    }

    int ItemState.GetSize() {
        return 520;
    }

    void ItemState.Move(float speed) {
        moveAction.Straight(transform, speed);
        if (isUp) {
            moveAction.Up(transform, 0.05f);
        } else {
            moveAction.Down(transform, 0.05f);
        }
        count++;
        if (count == 60) {
            count = 0;
            isUp = Random.Range(0, 2) == 0 ? true : false;
        }
    }
}
