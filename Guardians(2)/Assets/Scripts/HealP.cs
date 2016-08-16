using UnityEngine;
using System.Collections;

public class HealP : MonoBehaviour
{

	private ScoreManager sm;
    private PlayerController plr;

    void Start()
    {
        plr = FindObjectOfType(typeof(PlayerController)) as PlayerController;
		sm = FindObjectOfType (typeof(ScoreManager)) as ScoreManager;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Shield")
        {
            plr.RestoreLife();
            Destroy(gameObject);
			sm.AddScore ();
        }

    }
}
