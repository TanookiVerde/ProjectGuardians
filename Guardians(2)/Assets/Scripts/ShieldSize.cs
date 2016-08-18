using UnityEngine;
using System.Collections;

public class ShieldSize : MonoBehaviour {

    private GameObject ad;
    float timeElapsed;
    bool collided = false;
    private bool played;

    void Start() {
        ad = GameObject.FindWithTag("Finish");
        played = false;
    }

    // Update is called once per frame
    void Update () {
        if (collided)
        {
            
            timeElapsed += Time.deltaTime;
            if(timeElapsed > 5 && !played) {
                played = true;
                ad.GetComponent<PlayAudio>().PlayFim();
            }

            if (timeElapsed > 8)
            {   
                DecreaseSize();
            }
        }
    }

    public void IncreaseSize()
    {
        timeElapsed = 0;
        gameObject.transform.localScale += new Vector3(0, 0.2F, 0);
        collided = true;
    }
    public void DecreaseSize() {
        gameObject.transform.localScale -= new Vector3(0, 0.2F, 0);
        collided = false;
    }
}

