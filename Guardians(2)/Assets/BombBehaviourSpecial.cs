using UnityEngine;
using System.Collections;

public class BombBehaviourSpecial : MonoBehaviour {

    private bool played;
    private int randaudio, newcolor;
    private float timeElapsed;
    private string newcolorname;

    //acessa componentes
    private GameManager gm;
    private ScoreManager scorem;
    private PoweUpHandler pu;
    public GameObject audioplayer;
    private ScoreManager sm;
    private bool generated;
    public Sprite blue, green, red;

    void Start()
    {
        sm = FindObjectOfType(typeof(ScoreManager)) as ScoreManager;
        played = true;
        pu = FindObjectOfType(typeof(PoweUpHandler)) as PoweUpHandler;
        gm = FindObjectOfType(typeof(GameManager)) as GameManager;
        audioplayer = GameObject.FindWithTag("Finish");
        generated = false;
        timeElapsed = 0;
        newcolor = 0;
    }

    void FixedUpdate()
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
        transform.Translate(new Vector3(-8f, 0f, 0f) * Time.deltaTime);

        timeElapsed += Time.deltaTime;
        if (timeElapsed > 0.8 && generated)
        {
            ChangeColor();
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        switch (c.gameObject.tag)
        {
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
            gm.IncreaseBombCounter();
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.name == "player")
        {
            c.gameObject.GetComponent<PlayerController>().SubtractLife();
            Destroy(gameObject);
        }
    }

    public void ChangeColor()
    {
        newcolor = Random.Range(1, 4);
        generated = true;
        switch(newcolor)
        {
            case 1:
                newcolorname = "Red";
                if (newcolorname == gameObject.tag)
                {
                    ChangeColor();
                }
                else
                {
                    gameObject.tag = newcolorname;
                    gameObject.GetComponent<SpriteRenderer>().sprite = red;
                }
                break;
            case 2:
                newcolorname = "Green";
                if (newcolorname == gameObject.tag)
                {
                    ChangeColor();
                }
                else
                {
                    gameObject.tag = newcolorname;
                    gameObject.GetComponent<SpriteRenderer>().sprite = green;
                }
                break;
            case 3:
                newcolorname = "Blue";
                if (newcolorname == gameObject.tag)
                {
                    ChangeColor();
                }
                else
                {
                    gameObject.tag = newcolorname;
                    gameObject.GetComponent<SpriteRenderer>().sprite = blue;
                }
                break;
            default:
                break;
        }
    }
}
