using TMPro;
using UnityEngine;

public class GameMngr : MonoBehaviour
{
    public Transform waves = null;

    public TextMeshPro countWavesTxt;
    public TextMeshPro countEnemiesTxt;
    int countWaves = 0;
    int countEnemies = 0;



    void Start()
    {
        if (waves == null)
        {
            Debug.Log("waves == null in GameMngr");
            return;
        }

        countWaves = waves.childCount;

        for (int i = 0; i < countWaves; i++)
            countEnemies += waves.GetChild(i).GetChild(1).childCount;

        Debug.Log(countWaves);
        Debug.Log(countEnemies);
    }

    public void changeWavesCount(int value)
    {

    }

    public void changeEnemyCount(int value)
    {

    }
}
