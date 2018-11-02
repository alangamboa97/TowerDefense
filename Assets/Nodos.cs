using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodos : MonoBehaviour {

    // Use this for initialization
    public Color seleccion;
    private Renderer rend;
    private Color color_incial;
    public Vector3 positionOffset;

    private GameObject torreta;


    void Start()
    {
        rend = GetComponent<Renderer>();
        color_incial = rend.material.color;
    }

    void OnMouseDown() //cuando damos click
    {
        if (torreta != null)
        {
            Debug.Log("No puedes construir");
            return;
        }

        GameObject torretaPorConstruir = BuildManager.instance.ConstruirTorreta();
        torreta = (GameObject)Instantiate(torretaPorConstruir, transform.position +positionOffset, transform.rotation);
    }
    void OnMouseEnter() // cadavez que el mouse pasa por un nodo
    {
        rend.material.color = seleccion;
    }

    void OnMouseExit()
    {
        rend.material.color = color_incial;
    }
}
