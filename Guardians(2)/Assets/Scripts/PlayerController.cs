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
    private bool played;
    private bool paused;

    private GameObject ad;
    private GameObject cmds;

    void Start () 
	{
        cmds = GameObject.FindGameObjectWithTag("Commands");
        cmds.SetActive(false);
        ad = GameObject.FindWithTag("Finish");
		verticalSpeed = 0.16f;
		horizontalSpeed = 0.18f;
		rb = GetComponent<Rigidbody2D> ();
		life = 5;
        timeElapsed = 0;
        special = false;
        played = true;
        paused = true;
	}
	
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            paused = !paused;
            if (paused) {
                Time.timeScale = 0;
                cmds.SetActive(true);
            }
            else {
                Time.timeScale = 1;
                cmds.SetActive(false);
            }
        }
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
            if (played)
            {
                played = false;
                ad.GetComponent<PlayAudio>().PlayPlayerDeath();
            }
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
            vDirection = Input.GetAxis("Vertical") * verticalSpeed;
        }
		else 
		{
			hDirection = Input.GetAxis("Horizontal") * horizontalSpeed/1.5f;
            vDirection = Input.GetAxis("Vertical") * verticalSpeed/1.5f;
        }
		transform.Translate(hDirection, vDirection, 0);
	}

	public void SubtractLife()
	{
        if (life == 1)
        {
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
