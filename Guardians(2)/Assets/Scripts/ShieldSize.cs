using UnityEngine;
using System.Collections;

public class ShieldSize : MonoBehaviour {

    float timeElapsed;
    bool collided = false;

    // Update is called once per frame
    void Update () {
        if (collided)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > 5)
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

