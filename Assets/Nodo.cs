
using UnityEngine;

public class Nodo : MonoBehaviour {

    public Color seleccion;
    private Renderer rend;
    private Color color_incial;

    void Start()
    {
        rend = GetComponent<Renderer>();
        color_incial = rend.material.color;
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
