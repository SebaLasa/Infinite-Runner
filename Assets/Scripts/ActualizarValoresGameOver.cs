using UnityEngine;
using System.Collections;

public class ActualizarValoresGameOver : MonoBehaviour {

    public TextMesh total;
    public TextMesh record;

    public Puntuacion puntiacion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        total.text = puntiacion.puntiacion.ToString();
        if (EstadoJuegos.estadoJuego!=null)
        {
            record.text = EstadoJuegos.estadoJuego.puntuacionMaxima.ToString();
        }
        
    }
}
