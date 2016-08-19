using UnityEngine;
using System.Collections;

public class TokenBehaviour : MonoBehaviour {

    private ScoreManager sm;
    private float timeElapsed;
    private float maxUpAndDown = 1;
    private float speed = 4;
    private float angle = 0;
    private float toDegrees = Mathf.PI / 180;
    private GameObject[] gameobjectsb, gameobjectsr, gameobjectsg;
    private GameObject ad;

    void Start()
    {
        ad = GameObject.FindWithTag("Finish");
        sm = FindObjectOfType(typeof(ScoreManager)) as ScoreManager;
        timeElapsed = 0;
    }

    // Update is called once per frame
    void FixedUpdate () {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > 10)
        {
            Destroy(gameObject);
        }
        angle += speed * Time.deltaTime;
        if (angle > 6 || angle < -6)
        {
            speed = -speed;
        }
        transform.position = transform.position + new Vector3(0,maxUpAndDown * Mathf.Sin(angle * toDegrees), 0);

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Shield")
        {
            gameobjectsb = GameObject.FindGameObjectsWithTag("Blue");
            gameobjectsg = GameObject.FindGameObjectsWithTag("Green");
            gameobjectsr = GameObject.FindGameObjectsWithTag("Red");

            for (int i = 0; i < gameobjectsr.Length; i++)
            {
                if (gameobjectsr[i].name != "Shield")
                    Destroy(gameobjectsr[i]);
            }
            for (int i = 0; i < gameobjectsg.Length; i++)
            {
                if (gameobjectsg[i].name != "Shield")
                    Destroy(gameobjectsg[i]);
            }
            for (int i = 0; i < gameobjectsb.Length; i++)
            {
                if (gameobjectsb[i].name != "Shield")
                    Destroy(gameobjectsb[i]);
            }
            ad.GetComponent<PlayAudio>().PlayToken();
            sm.AddScoreBig();
            Destroy(gameObject);
        }

    }
}
