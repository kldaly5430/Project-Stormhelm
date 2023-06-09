using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="AI/Enemy Actions/Attack")]
public class EnemyAttackAction : EnemyActions
{
    public int attackScore = 3;
    public float recoveryTime = 2;

    public float maximumAngle = 35;
    public float minimumAngle = -35;

    public float maximumAttackDistance = 3;
    public float minimumAttackDistance = 0;

}
