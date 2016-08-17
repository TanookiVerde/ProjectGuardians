using UnityEngine;
using System.Collections;

public class PlayAudio : MonoBehaviour {

    private AudioSource shieldhit;
    private AudioSource explosion1;
    private AudioSource explosion21;
    private AudioSource explosion22;
    private AudioSource playerdeath;
    private AudioSource playerhit;
    AudioSource[] audios;
    private int clip;
    private PlayerController pc;
    private CoreBehaviour cb;
    private ScreenFader fader;

    // Use this for initialization
    void Start () {
        fader = FindObjectOfType(typeof(ScreenFader)) as ScreenFader;
        pc = FindObjectOfType(typeof(PlayerController)) as PlayerController;
        AudioSource[] audios = GetComponents<AudioSource>();
        cb = FindObjectOfType(typeof(CoreBehaviour)) as CoreBehaviour;
        shieldhit = audios[0];
        explosion1 = audios[1];
        explosion21 = audios[4];
        explosion22 = audios[5];
        playerdeath = audios[3];
        playerhit = audios[2];
    }
	
	public void PlayLaser () {
        shieldhit.Play();
	}
    public void PlayExplosion1() {
        explosion1.Play();
        StartCoroutine(playEngineSound());
    }

    IEnumerator playEngineSound()
    {
        yield return new WaitForSeconds(explosion1.clip.length);
        clip = Random.Range(1, 3);
        if (clip == 1) PlayExplosion21();
        else PlayExplosion22();
    }
    public void PlayExplosion21() {
        explosion21.Play();
    }
    public void PlayExplosion22() {
        explosion22.Play();
    }
    public void PlayPlayerDeath() {
        playerdeath.Play();
        cb.GameOver();
    }
    IEnumerator Death() {
        yield return new WaitForSeconds(playerdeath.clip.length + 0.8f);
        cb.GameOver();
    }
    public void PlayPlayerHit() {
        playerhit.Play();
    }
}
