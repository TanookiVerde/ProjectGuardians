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
	public int isHit;

	//acessa componentes
	private Rigidbody2D rb;

    private float timeElapsed;
    private bool special;
    private bool played;
    private bool paused;
    private bool played2;

    private GameObject ad;
    private GameObject cmds;
	private GameObject robo;

    void Start () 
	{
        cmds = GameObject.FindGameObjectWithTag("Commands");
        cmds.SetActive(false);
        ad = GameObject.FindWithTag("Finish");
		verticalSpeed = 0.2f;
		horizontalSpeed = 0.22f;
		rb = GetComponent<Rigidbody2D> ();
		life = 5;
        timeElapsed = 0;
        special = false;
        played = true;
        played2 = false;
        paused = true;
		robo = GameObject.FindGameObjectWithTag("Player");
	}
	
    void Update() {
		isHit = 0;
        if (Input.GetKeyDown(KeyCode.Escape))
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
        if (paused)
        {
            Time.timeScale = 0;
            cmds.SetActive(true);
        }
    }

	void FixedUpdate () 
	{
        if (special)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > 5 && !played2)
            {
                ad.GetComponent<PlayAudio>().PlayFim();
             }
            if (timeElapsed > 8)
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
            vDirection = Input.GetAxis("Vertical") * verticalSpeed/1.3f;
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
		GetComponent<Animator>().Play("playerHurt");
    }

    public void RestoreLife() {
            life = 5;
        }

    public void SpeedUp() {
        special = true;
        verticalSpeed += 0.12f;
        horizontalSpeed += 0.12f;
    }

    public void SpeedDown() {
        verticalSpeed -= 0.12f;
        horizontalSpeed -= 0.12f;
        special = false;
    }
}
