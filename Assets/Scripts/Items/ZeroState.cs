using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroState : MonoBehaviour, ItemState
{
    int ItemState.GetLevel() {
        return 0;
    }

    int ItemState.GetSize() {
        return 1;
    }

}
