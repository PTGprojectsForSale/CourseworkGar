using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public GameObject winPnl;
    public GameObject deadPnl;

    float time = 0;

    public DoorAnim door;

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

    private void Update()
    {
        time += Time.deltaTime;
    }

    void updateCounts()
    {
        countWavesTxt.text = currCountWaves + "/" + countWaves;
        countEnemiesTxt.text = currCountEnemies + "/" + countEnemies;

        if (currCountWaves == countWaves)
            door.openDoor();
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

    public void win()
    {
        Time.timeScale = 0.2f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        winPnl.SetActive(true);

        TextMeshProUGUI killsTxt = winPnl.transform.Find("kills").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI timeTxt = winPnl.transform.Find("time").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI ratingTxt = winPnl.transform.Find("rating").GetComponent<TextMeshProUGUI>();

        killsTxt.text = countEnemiesTxt.text;
        timeTxt.text = time.ToString();

        ratingTxt.text = "S";

    }
    public void dead()
    {
        Time.timeScale = 0.2f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        deadPnl.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
