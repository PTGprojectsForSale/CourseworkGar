using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyFactory : EnemyFactory
{
    [SerializeField] GameObject meleeEnemyPrefab;

    public override IEnemy getEnemy()
    {
        GameObject meleeEnemy = Instantiate(meleeEnemyPrefab);

        return meleeEnemy.GetComponent<MeleeEnemy>();
    }
    public override IEnemy getEnemy(Transform parent)
    {
        GameObject meleeEnemy = Instantiate(meleeEnemyPrefab, parent);

        return meleeEnemy.GetComponent<MeleeEnemy>();
    }
}
