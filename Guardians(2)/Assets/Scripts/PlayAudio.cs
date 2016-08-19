using UnityEngine;
using System.Collections;

public class PlayAudio : MonoBehaviour {

    private AudioSource shieldhit;
    private AudioSource explosion1;
    private AudioSource explosion21;
    private AudioSource explosion22;
    private AudioSource playerdeath;
    private AudioSource playerhit;
    private AudioSource token;
    private AudioSource fimpu;
    AudioSource[] audios;
    private int clip;
    private PlayerController pc;
    private CoreBehaviour cb;
    private ScreenFader fader;
    private LostGame lost;

    // Use this for initialization
    void Start () {
        fader = FindObjectOfType(typeof(ScreenFader)) as ScreenFader;
        pc = FindObjectOfType(typeof(PlayerController)) as PlayerController;
        AudioSource[] audios = GetComponents<AudioSource>();
        cb = FindObjectOfType(typeof(CoreBehaviour)) as CoreBehaviour;
        lost = FindObjectOfType(typeof(LostGame)) as LostGame;
        shieldhit = audios[0];
        explosion1 = audios[1];
        explosion21 = audios[4];
        explosion22 = audios[5];
        playerdeath = audios[3];
        playerhit = audios[2];
        fimpu = audios[6];
        token = audios[7];
    }
	
    public void PlayToken() {
        token.Play();
    }

    public void PlayFim() {
        fimpu.Play();
    }

	public void PlayLaser () {
        shieldhit.Play();
	}
    public void PlayExplosion1() {
        explosion1.Play();
        StartCoroutine(playEngineSound());
        clip = Random.Range(1, 3);
        if (clip == 1) PlayExplosion21();
        else PlayExplosion22();
    }

    IEnumerator playEngineSound()
    {
        float start = Time.realtimeSinceStartup;
        float time = explosion1.clip.length;
        fader.EndScene(2);
        while (Time.realtimeSinceStartup < start + time)
        {
            yield return null;
        }
    }
    public void PlayExplosion21() {
        explosion21.Play();
        StartCoroutine(e21());
    }
    IEnumerator e21()
    {
        float start = Time.realtimeSinceStartup;
        float time = explosion21.clip.length;
        fader.EndScene(2);
        while (Time.realtimeSinceStartup < start + time)
        {
            yield return null;
        }
    }
    public void PlayExplosion22() {
        explosion22.Play();
        StartCoroutine(e22());
    }
    IEnumerator e22()
    {
        float start = Time.realtimeSinceStartup;
        float time = explosion22.clip.length;
        fader.EndScene(2);
        while (Time.realtimeSinceStartup < start + time)
        {
            yield return null;
        }
    }
    public void PlayPlayerDeath() {
        lost.dead = true;
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
