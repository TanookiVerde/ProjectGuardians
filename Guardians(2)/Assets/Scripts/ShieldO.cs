using UnityEngine;
using System.Collections;

public class ShieldO : MonoBehaviour
{

    private ShieldColor shld;
	private ScoreManager sm;

    void Start()
    {
        shld = FindObjectOfType(typeof(ShieldColor)) as ShieldColor;
		sm = FindObjectOfType (typeof(ScoreManager)) as ScoreManager;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Shield")
        {
            shld.OmniOn();
			sm.AddScore ();
            Destroy(gameObject);
        }

    }
}
