using UnityEngine;
using System.Collections;


public class Puntuacion : MonoBehaviour {

    public int puntiacion = 0;
    public TextMesh marcador;

	// Use this for initialization
	void Start () {
        NotificationCenter.DefaultCenter().AddObserver(this, "IncrementarPuntos");
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
        ActualizarMarcador();
    }

    void PersonajeHaMuerto(Notification notificacion)
    {
        if (puntiacion > EstadoJuegos.estadoJuego.puntuacionMaxima)
        {
            EstadoJuegos.estadoJuego.puntuacionMaxima = puntiacion;
            EstadoJuegos.estadoJuego.Guardar();
        }
    }

    void IncrementarPuntos(Notification notificacion)
    {
        int puntosAIncrementar = (int)notificacion.data;
        puntiacion += puntosAIncrementar;
        ActualizarMarcador();
    }

    void ActualizarMarcador()
    {
        marcador.text = puntiacion.ToString();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
