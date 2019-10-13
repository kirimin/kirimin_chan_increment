public interface ItemState
{
    int GetLevel();

    int GetCanTakePlayerSize();

    int GetRewardSize();

    void Move(float speed);
}