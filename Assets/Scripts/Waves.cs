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
            Transform enPos = enemyCrowds[num].GetChild(i);
            
            enemyFactory = enemyFactories[int.Parse(enPos.name)-1];
        
            IEnemy enemy = enemyFactory.getEnemy(enemyCrowds[num].parent.Find("enemys"));

            enemy.positionAndRotation(enPos.position, Quaternion.identity);

            enemy.Player = player;

            Health enemyHP = enemy.EnemyHP;
        }
    }
}
