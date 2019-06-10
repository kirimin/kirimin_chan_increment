using UnityEngine;
public class MoveAction 
{
    public void Straight(Transform transform, float speed) {
        var position = transform.localPosition;
        position.x -= speed;
        transform.localPosition = position;
    }

    public void Rotate(Transform transform, float z) {
        var rotation = transform.localRotation;
        var quaternion = Quaternion.AngleAxis(z, Vector3.forward);
        transform.localRotation = rotation * quaternion;
    }
}