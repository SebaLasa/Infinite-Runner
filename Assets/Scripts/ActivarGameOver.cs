using UnityEngine;
using System.Collections;

public class ActivarGameOver : MonoBehaviour {

    public GameObject camara;
    public AudioClip audioGameOver;

	// Use this for initialization
	void Start () {
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
    }
	
    void PersonajeHaMuerto(Notification notificacion)
    {
        GetComponent<AudioSource>().Stop();
        camara.SetActive(true);
        GetComponent<AudioSource>().clip = audioGameOver;
        GetComponent<AudioSource>().loop = false;
        GetComponent<AudioSource>().volume = 0.1f;
        GetComponent<AudioSource>().Play();

    }
    // Update is called once per frame
    void Update () {
	
	}
}
