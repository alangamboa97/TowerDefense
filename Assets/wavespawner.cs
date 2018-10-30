using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wavespawner : MonoBehaviour {

    // Use this for initialization
    public Transform enemyPrefab;
    public Transform puntodespawn;
    public float tiempo_entre_olas = 6f;
    private float contador = 2f;
    private int numoleadas = 1;

    void Update()
    {
        if(contador<= 0f)
        {
            Spawn();
            contador = tiempo_entre_olas;
        }
        contador -= Time.deltaTime;
    }

    void Spawn()
    {
        for (int i = 0; i < numoleadas; i++)
        {
            SpawnEnemigo();
        }
        numoleadas++;

        Debug.Log("Una oleada se aproxima");
    }

    void SpawnEnemigo()
    {
        Instantiate(enemyPrefab, puntodespawn.position, puntodespawn.rotation);
    }
}
