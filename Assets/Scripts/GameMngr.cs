using TMPro;
using UnityEngine;

public class GameMngr : MonoBehaviour
{
    public Transform waves = null;

    public TextMeshProUGUI countWavesTxt;
    public TextMeshProUGUI countEnemiesTxt;
    
    int countWaves = 0;
    int countEnemies = 0;
    
    int currCountWaves = 0;
    int currCountEnemies = 0;

    public TextMeshProUGUI playerHpTxt;
    int playerHp;

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

        updateCounts();
    }

    void updateCounts()
    {
        countWavesTxt.text = currCountWaves + "/" + countWaves;
        countEnemiesTxt.text = currCountEnemies + "/" + countEnemies;
    }

    public void changeWavesCount()
    {
        currCountWaves++;
        updateCounts();
    }

    public void changeEnemiesCount()
    {
        currCountEnemies++;
        updateCounts();
    }

    public void changeHP(int value)
    {
        playerHp = value;
        playerHpTxt.text = playerHp.ToString();
    }
}
