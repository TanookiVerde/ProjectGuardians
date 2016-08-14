using UnityEngine;
using System.Collections;

public class PlayAudio : MonoBehaviour {

    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
