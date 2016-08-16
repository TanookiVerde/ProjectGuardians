using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

    private ShieldSize shld;
	private ScoreManager sm;

	void Start () {
        shld = FindObjectOfType(typeof(ShieldSize)) as ShieldSize;
		sm = FindObjectOfType (typeof(ScoreManager)) as ScoreManager;
	}

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Shield") {
            shld.IncreaseSize();
			sm.AddScore ();
            Destroy(gameObject);
        }

    }
}
