using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixcelState : MonoBehaviour, ItemState
{
    int ItemState.GetLevel() {
        return 1;
    }

    int ItemState.GetSize() {
        return 10;
    }
}
