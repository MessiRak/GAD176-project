using UnityEngine;

public class RangedEnemy : BaseEnemy
{
    void Update()
    {
        if (IsPlayerInRange())
        {
            MoveTowardsPlayer();
        }
    }
}
