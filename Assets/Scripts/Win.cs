using UnityEngine;

public class Win : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            GameMngr gmMngr = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameMngr>();
            if (gmMngr != null)
                gmMngr.win();
        }
    }
}
