using UnityEngine;
using System.Collections;

public class HealP : MonoBehaviour
{

	private ScoreManager sm;
    private PlayerController plr;
    private float timeElapsed;

    void Start()
    {
        plr = FindObjectOfType(typeof(PlayerController)) as PlayerController;
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
