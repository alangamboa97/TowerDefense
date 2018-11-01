using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour {

   
    public Transform objetivo;
    public float rango = 15f;
    public string tag = "Enemigo";
    public Transform parToRotate;
    public float velocidad = 10f;
    public AudioSource disparo_s;

    public GameObject balaPrefab;
    public Transform punto_salida;



    public float disparo = 1f;     //disparos
    public float conteo_disparo = 0f;
	// Use this for initialization
	void Start () {
        InvokeRepeating("ActualizarObjetivo", 0f, 0.5f);
		
	}
    void ActualizarObjetivo()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag(tag);  //arreglo de enemigos

        float distancia_corta = Mathf.Infinity;
        GameObject enemigo_cercano = null;

        foreach (GameObject enemigo in enemigos)
        {
            float distancia = Vector3.Distance(transform.position, enemigo.transform.position);
            if (distancia < distancia_corta)
            {
                distancia_corta = distancia;
                enemigo_cercano = enemigo;
            }

        }

        if (enemigo_cercano != null && distancia_corta <= rango)
        {
            objetivo = enemigo_cercano.transform;
        }
        else
        {
            objetivo = null;
        }
            
    }
    public void Sonido()
    {
        disparo_s.Play();
    }
    // Update is called once per frame
    void Update () {
        if(objetivo == null)
        {
            return;
        }
        Vector3 dir = objetivo.position - transform.position;
        Quaternion rotacion_convertir = Quaternion.LookRotation(dir);
        Vector3 rotacion = Quaternion.Lerp(parToRotate.rotation, rotacion_convertir, Time.deltaTime* velocidad).eulerAngles;
        parToRotate.rotation = Quaternion.Euler(0f, rotacion.y, 0f);

        if(conteo_disparo <= 0f)
        {
            Disparar();
            conteo_disparo = 1f / disparo;
        }
        conteo_disparo -= Time.deltaTime;

		
	}
   
    void Disparar()
    {
        GameObject balaGO = (GameObject)Instantiate(balaPrefab, punto_salida.position, punto_salida.rotation);
        Debug.Log("Disparar");
        Bala bala = balaGO.GetComponent<Bala>();
        Sonido();

        if(bala != null)
        {
            bala.Buscar(objetivo);
        }
    }

   
    void OnDrawGizmosSelected() //ayuda visual para calcular el rango
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rango);
    }
}
