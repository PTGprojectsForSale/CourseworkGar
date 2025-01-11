using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Activator : MonoBehaviour
{
    public Waves waves;
    public int numWave;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            switch (numWave) 
            {
                case 1:
                    waves.spawnWave(1);
                    break;
                case 2:
                    waves.spawnWave(2);
                    break;
                case 3:
                    waves.spawnWave(3);
                    break;
                case 4:
                    waves.spawnWave(4);
                    break;
                default:
                    return;
            }

            gameObject.SetActive(false);
        }
    }
}
