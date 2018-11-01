using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

    private Transform objetivo;
    public float velocidad = 70f;

    public void Buscar(Transform _objetivo) //busca un objetivo a que disparar
    {
        objetivo = _objetivo;
    }

	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
        if(objetivo == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = objetivo.position - transform.position;
        float distancia_cuadro = velocidad * Time.deltaTime;

        if(dir.magnitude <= distancia_cuadro)
        {
            Hit();
            return;
        }

        transform.Translate(dir.normalized * distancia_cuadro, Space.World);
	}

    void Hit()
    {
        Destroy(objetivo.gameObject);
        Destroy(gameObject); //destruye la bala cada vez que le da a algo;
    }
}
