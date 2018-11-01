using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class wavespawner : MonoBehaviour {

    // Use this for initialization
    public Transform enemyPrefab;
    public Transform puntodespawn;
    public float tiempo_entre_olas = 6f;

    public Text contadorTexto;
    private float contador = 2f;
    private int numoleadas = 0;

    void Update()
    {
        if(contador<= 0f)
        {
            StartCoroutine(Spawn());
            contador = tiempo_entre_olas;
        }
        contador -= Time.deltaTime;

        contadorTexto.text = Mathf.Floor(contador).ToString();
    }

    IEnumerator Spawn()
         
    {
        numoleadas++;
        for (int i = 0; i < numoleadas; i++)
        {
            SpawnEnemigo();
            yield return new WaitForSeconds(0.8f);
        }
       

        Debug.Log("Una oleada se aproxima");
    }

    void SpawnEnemigo()
    {
        Instantiate(enemyPrefab, puntodespawn.position, puntodespawn.rotation);
    }
}
