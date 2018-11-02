using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;
    public GameObject torretaStandard; 


    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Hay mas de un BuildManager");
            return;
        }
        instance = this;
    }

    void Start()
    {
        torretaPorConstruir = torretaStandard;
    }
    // Use this for initialization
    private GameObject torretaPorConstruir;




    public GameObject ConstruirTorreta()
    {
        return torretaPorConstruir;
    }
}
