using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Waves : MonoBehaviour
{
    [SerializeField]
    public List<EnemyFactory> enemyFactories;
    public Transform[] enemyCrowds;

    
    EnemyFactory enemyFactory;
    public Transform player;
    
    public void spawnWave(int num)
    {
        num -= 1;
        for (int i = 0; i < enemyCrowds[num].childCount; i++)
        {
            Transform en = enemyCrowds[num].GetChild(i);
            
            enemyFactory = enemyFactories[int.Parse(en.name)-1];
        
            IEnemy enemy = enemyFactory.getEnemy();

            enemy.positionAndRotation(en.position, Quaternion.identity);

            enemy.Player = player;

            Health enemyHP = enemy.EnemyHP;
        }
    }
}
