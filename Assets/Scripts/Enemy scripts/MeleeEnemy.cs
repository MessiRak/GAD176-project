using UnityEngine;

public class MeleeEnemy : BaseEnemy
{
    void Update()
    {
        if (IsPlayerInRange())
        {
            MoveTowardsPlayer();
        }
    }
}
