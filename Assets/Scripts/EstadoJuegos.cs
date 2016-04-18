using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class EstadoJuegos : MonoBehaviour {

    public int puntuacionMaxima = 0;
    public static EstadoJuegos estadoJuego;

    private string rutaArchivo;

	void Awake () {
        rutaArchivo = Application.persistentDataPath + "/datos.dat";

        if (estadoJuego==null)
        {
            estadoJuego = this;
            DontDestroyOnLoad(gameObject);
        }else if (estadoJuego!=this)
        {
            Destroy(gameObject);
        }

	}

    void Start()
    {
        Cargar();
    }

    public void Guardar()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file =  File.Create(rutaArchivo);

        DatosAGuardar datos = new DatosAGuardar();

        datos.puntiacionMaxima = puntuacionMaxima;

        bf.Serialize(file, datos);

        file.Close();

    }

    void Cargar()
    {
        if (File.Exists(rutaArchivo))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(rutaArchivo, FileMode.Open);

            DatosAGuardar datos = (DatosAGuardar)bf.Deserialize(file);

            puntuacionMaxima = datos.puntiacionMaxima;

            file.Close();
        }
        else
        {
            puntuacionMaxima = 0;
        }
    }
	
}

[Serializable]
class DatosAGuardar
{
    public int puntiacionMaxima;

}