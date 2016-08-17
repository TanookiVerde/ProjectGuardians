using UnityEngine;
using System.Collections;

public class ShieldO : MonoBehaviour
{

    private ShieldColor shld;
	private ScoreManager sm;
    private float timeElapsed;

    void Start()
    {
        shld = FindObjectOfType(typeof(ShieldColor)) as ShieldColor;
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
            shld.OmniOn();
			sm.AddScore ();
            Destroy(gameObject);
        }

    }
}
