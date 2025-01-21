using TMPro;
using UnityEngine;

public class GranadeScr : MonoBehaviour
{
    public GameObject grenadePrefab; 
    public Transform throwPoint;
    public float throwForce = 10f;

    int amo = 3;
    public TextMeshProUGUI grnsAmo;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (amo > 0)
            {
                ThrowGrenade();
                amo--;
                grnsAmo.text = amo.ToString();
            }
        }
    }

    void ThrowGrenade()
    {
        if (grenadePrefab != null && throwPoint != null)
        {
            GameObject grenade = Instantiate(grenadePrefab, throwPoint.position, throwPoint.rotation);

            Rigidbody rb = grenade.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddForce(throwPoint.forward * throwForce, ForceMode.Impulse);

        }
    }
}
