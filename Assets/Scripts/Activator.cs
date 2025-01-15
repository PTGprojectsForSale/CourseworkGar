using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Activator : MonoBehaviour
{
    public Waves waves;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            int numWave = int.Parse(transform.parent.name);

            waves.spawnWave(numWave);

            GameMngr gmMngr = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameMngr>();
            if (gmMngr != null)
                gmMngr.changeWavesCount();

            Debug.Log(numWave + " Wave activated");
            gameObject.SetActive(false);
        }
    }
}
