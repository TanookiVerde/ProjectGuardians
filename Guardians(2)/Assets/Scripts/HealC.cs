using UnityEngine;
using System.Collections;

public class HealC : MonoBehaviour
{


    public GameObject c1, c2, c3, c4, c5;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Shield")
        {
            c1.GetComponent<CoreBehaviour>().AddLife();
            c2.GetComponent<CoreBehaviour>().AddLife();
            c3.GetComponent<CoreBehaviour>().AddLife();
            c4.GetComponent<CoreBehaviour>().AddLife();
            c5.GetComponent<CoreBehaviour>().AddLife();
            Destroy(gameObject);
        }

    }
}
