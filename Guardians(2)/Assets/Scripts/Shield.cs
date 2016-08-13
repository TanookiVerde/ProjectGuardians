using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

    private ShieldSize shld;

	void Start () {
        shld = FindObjectOfType(typeof(ShieldSize)) as ShieldSize;
	}

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Shield") {
            shld.IncreaseSize();
            Destroy(gameObject);
        }

    }
}
