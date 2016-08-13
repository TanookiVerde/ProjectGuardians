using UnityEngine;
using System.Collections;

public class SpeedU : MonoBehaviour
{

    private PlayerController plr;

    void Start()
    {
        plr = FindObjectOfType(typeof(PlayerController)) as PlayerController;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Shield")
        {
            plr.SpeedUp();
            Destroy(gameObject);
        }

    }
}
