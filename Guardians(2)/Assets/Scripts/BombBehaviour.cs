using UnityEngine;
using System.Collections;

public class BombBehaviour : MonoBehaviour {

    private bool played;
    private int randaudio;
    
	//acessa componentes
	private GameManager gm;
	private ScoreManager scorem;
    private PoweUpHandler pu;
    public GameObject audioplayer;
    private ScoreManager sm;

	void Start()
	{
        sm = FindObjectOfType(typeof(ScoreManager)) as ScoreManager;
        played = true;
        pu = FindObjectOfType (typeof(PoweUpHandler)) as PoweUpHandler;
		gm = FindObjectOfType (typeof(GameManager)) as GameManager;
        audioplayer = GameObject.FindWithTag("Finish");
    }

	void Update () 
	{
        if (transform.position.x < -6.8 && played)
        {
            audioplayer.GetComponent<PlayAudio>().PlayPlayerHit();
            played = false;
        }
        if (transform.position.x < -9)
        {
            Destroy(gameObject);
        }
        transform.Translate (new Vector3 (-6f, 0f, 0f) * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D c)
	{
        switch(c.gameObject.tag) {
            case "Core1":
                pu.Break(0);
                pu.generated = false;
                c.GetComponent<CoreBehaviour>().SubtractLife();
                Destroy(gameObject);
                break;
            case "Core2":
                pu.Break(1);
                pu.generated = false;
                c.GetComponent<CoreBehaviour>().SubtractLife();
                Destroy(gameObject);
                break;
            case "Core3":
                pu.Break(2);
                pu.generated = false;
                c.GetComponent<CoreBehaviour>().SubtractLife();
                Destroy(gameObject);
                break;
            case "Core4":
                pu.Break(3);
                pu.generated = false;
                c.GetComponent<CoreBehaviour>().SubtractLife();
                Destroy(gameObject);
                break;
            case "Core5":
                pu.Break(4);
                pu.generated = false;
                c.GetComponent<CoreBehaviour>().SubtractLife();
                Destroy(gameObject);
                break;
            default:
                break;

        }
		if (c.gameObject.tag == gameObject.tag || c.gameObject.tag == "Omni")
		{
            audioplayer.GetComponent<PlayAudio>().PlayLaser();
            pu.generated = false;
            sm.AddScore();
            pu.pucount++;
			gm.IncreaseBombCounter ();
            Destroy(gameObject);
        }
	} 

	void OnCollisionEnter2D (Collision2D c)
	{
        if (c.gameObject.name == "player")
        {
            c.gameObject.GetComponent<PlayerController>().SubtractLife();
            Destroy(gameObject);
        }
	}
}
