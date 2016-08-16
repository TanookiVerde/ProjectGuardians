using UnityEngine;
using System.Collections;

public class SpeedU : MonoBehaviour
{

    private PlayerController plr;
	private ScoreManager sm;

    void Start()
    {
        plr = FindObjectOfType(typeof(PlayerController)) as PlayerController;
		sm = FindObjectOfType (typeof(ScoreManager)) as ScoreManager;
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
