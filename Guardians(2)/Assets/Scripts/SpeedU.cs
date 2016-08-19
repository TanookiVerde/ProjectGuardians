using UnityEngine;
using System.Collections;

public class SpeedU : MonoBehaviour
{

    private PlayerController plr;
	private ScoreManager sm;
    private float timeElapsed;

    void Start()
    {
        plr = FindObjectOfType(typeof(PlayerController)) as PlayerController;
		sm = FindObjectOfType (typeof(ScoreManager)) as ScoreManager;
        timeElapsed = 0;
    }

    void Update() {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > 15) {
            timeElapsed = 0;
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Shield")
        {
			sm.AddScore ();
            plr.SpeedUp();
            Destroy(gameObject);
        }

    }
}
