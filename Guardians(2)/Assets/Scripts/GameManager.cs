using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	//Controle do spawn de projeteis
	private float spawnTimer;
	private float spawnTimerLimit;
	public int bombCounter;

	//Lista da posicao dos spawns
	public Transform[] spawn;

	//Lista de Bombas
	public GameObject[] bombPrefab;
    public GameObject background;

	private int selectedSpawn;
    private int selectedBomb;



	void Start () 
	{
		spawnTimer = 0;
        ScoreManager.score = 0;
		bombCounter = 0;
		spawnTimerLimit = 2;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (bombCounter >= 15 && spawnTimerLimit > 0.9f) 
		{
			spawnTimerLimit -= 0.2f;
			bombCounter = 0;
		}
		spawnTimer += Time.deltaTime;
		if (spawnTimer > spawnTimerLimit) 
		{
            if (ScoreManager.score <= 20000)
            {
                selectedBomb = Random.Range(0, 3);
            }
            else 
            {
                selectedBomb = Random.Range(0, 6);
            }
            selectedSpawn = Random.Range(0, 5);
            Instantiate (bombPrefab[selectedBomb], spawn [selectedSpawn].position, spawn [selectedSpawn].rotation);
			spawnTimer = 0;
		} 
	}

	public void IncreaseBombCounter()
	{
		bombCounter++;
        if (ScoreManager.score >= 10000)
        { 
            if (ScoreManager.score >= 20000)
                background.GetComponent<AudioSource>().pitch = 1.4f;
            else background.GetComponent<AudioSource>().pitch = 1.2f;
        }
        
	}
}
