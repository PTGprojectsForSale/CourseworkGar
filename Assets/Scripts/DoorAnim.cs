using UnityEngine;

public class DoorAnim : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void openDoor()
    {
        anim.SetInteger("state", 1);
    }
}
