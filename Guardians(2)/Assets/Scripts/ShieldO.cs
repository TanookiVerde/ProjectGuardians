using UnityEngine;
using System.Collections;

public class ShieldO : MonoBehaviour
{

    private ShieldColor shld;

    void Start()
    {
        shld = FindObjectOfType(typeof(ShieldColor)) as ShieldColor;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Shield")
        {
            shld.OmniOn();
            Destroy(gameObject);
        }

    }
}
