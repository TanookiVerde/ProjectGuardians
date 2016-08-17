using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

    private ShieldSize shld;
	private ScoreManager sm;
    private float timeElapsed;

    void Start () {
        shld = FindObjectOfType(typeof(ShieldSize)) as ShieldSize;
		sm = FindObjectOfType (typeof(ScoreManager)) as ScoreManager;
        timeElapsed = 0;
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > 15)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Shield") {
            shld.IncreaseSize();
			sm.AddScore ();
            Destroy(gameObject);
        }

    }
}
