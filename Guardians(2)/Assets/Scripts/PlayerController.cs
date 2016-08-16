using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	//controle de velocidade
	private float verticalSpeed;
	private float horizontalSpeed;
	private float direction;
	private float hDirection;
	private float vDirection;

	//limites de movimento
	private float xMin = -6.75f;
	private float xMax = 7.6f;
	private float yMin = -4f;
	private float yMax = 4f;

	//vida
	public int life;

	//acessa componentes
	private Rigidbody2D rb;

    private float timeElapsed;
    private bool special;

    private GameObject ad;

    void Start () 
	{
        ad = GameObject.FindWithTag("Finish");
		verticalSpeed = 0.16f;
		horizontalSpeed = 0.18f;
		rb = GetComponent<Rigidbody2D> ();
		life = 5;
        timeElapsed = 0;
        special = false;
	}
	

	void FixedUpdate () 
	{
        if (special)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > 5)
            {
                SpeedDown();
            }
        }
        if (life == 0) 
		{
            SceneManager.LoadScene("GameOver");
		}
		MovementControl ();
		rb.position = new Vector3 (Mathf.Clamp (rb.position.x, xMin, xMax), Mathf.Clamp (rb.position.y, yMin, yMax), 0f);
	}

	private void MovementControl()
	{
		direction = Input.GetAxis ("Horizontal");
		if (direction >= 0) 
		{
			hDirection = Input.GetAxis ("Horizontal") * horizontalSpeed;
		}
		else 
		{
			hDirection = Input.GetAxis("Horizontal") * horizontalSpeed/2;	
		}
        vDirection = Input.GetAxis("Vertical") * verticalSpeed;
		transform.Translate(hDirection, vDirection, 0);
		/*if(Input.GetKey(KeyCode.D))
		{
			transform.Translate (horizontalSpeed, 0f, 0f);
		}
		if(Input.GetKey(KeyCode.A))
		{
			transform.Translate (-horizontalSpeed, 0f, 0f);
		}
		if(Input.GetKey(KeyCode.W))
		{
			transform.Translate (0f, verticalSpeed, 0f);
		}
		if(Input.GetKey(KeyCode.S))
		{
			transform.Translate (0f, -verticalSpeed, 0f);
		}*/
	}

	public void SubtractLife()
	{
        if (life == 1)
        {
            ad.GetComponent<PlayAudio>().PlayPlayerDeath();
            life--;
        }
        else
        {
            ad.GetComponent<PlayAudio>().PlayPlayerHit();
            life--;
        }
    }

    public void RestoreLife() {
            life = 5;
        }

    public void SpeedUp() {
        special = true;
        verticalSpeed += 0.2f;
        horizontalSpeed += 0.2f;
    }

    public void SpeedDown() {
        verticalSpeed -= 0.2f;
        horizontalSpeed -= 0.2f;
        special = false;
    }
}
