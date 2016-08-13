using UnityEngine;
using System.Collections;

public class HealC : MonoBehaviour
{


    private GameObject c1, c2, c3, c4, c5;

    void Start() {
        c1 = GameObject.Find("Core1");
        c2 = GameObject.Find("Core2");
        c3 = GameObject.Find("Core3");
        c4 = GameObject.Find("Core4");
        c5 = GameObject.Find("Core5");
    }

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
