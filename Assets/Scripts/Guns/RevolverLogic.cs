using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverLogic : MonoBehaviour
{
    [SerializeField] LayerMask enemy;
    [Range(1, 20)]
    public int piercingPower = 3;
    public void shot(Transform firePoint, float damage)
    {
        RaycastHit[] hits;

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        hits = Physics.RaycastAll(ray, 100f, enemy);

        System.Array.Sort(hits, (x, y) => x.distance.CompareTo(y.distance));

        if (hits.Length > 0)
        {
            for (int i = 0; i < Mathf.Min(piercingPower, hits.Length); i++)
            {
                Health enemyHp = hits[i].transform.GetComponent<Health>();
                if (enemyHp != null)
                {
                    enemyHp.hpDecrease(damage);
                }
            }
        }
    }
}
