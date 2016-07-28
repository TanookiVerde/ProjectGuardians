using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//Controle do spawn de projeteis
	private float spawnTimer;

	//Lista da posicao dos spawns
	public Transform[] spawn;

	//Lista de Bombas
	public GameObject[] bombPrefab;

	private int selectedSpawn;
	private int selectedBomb;

	void Start () 
	{
		spawnTimer = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		spawnTimer += Time.deltaTime;
		if (spawnTimer > 2) 
		{
			selectedBomb = Random.Range (0, 3);
			selectedSpawn = Random.Range (0, 5);
			Instantiate (bombPrefab[selectedBomb], spawn [selectedSpawn].position, spawn [selectedSpawn].rotation);
			spawnTimer = 0;
		} 
	}
}
