using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyFactory : EnemyFactory
{
    [SerializeField] GameObject rangeEnemyPrefab;

    public override IEnemy getEnemy()
    {
        GameObject rangeEnemy = Instantiate(rangeEnemyPrefab);

        return rangeEnemy.GetComponent<RangeEnemy>();
    }

    public override IEnemy getEnemy(Transform parent)
    {
        GameObject rangeEnemy = Instantiate(rangeEnemyPrefab, parent);

        return rangeEnemy.GetComponent<RangeEnemy>();
    }
}
