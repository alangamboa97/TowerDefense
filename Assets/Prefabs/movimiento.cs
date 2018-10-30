using UnityEngine;

public class movimiento : MonoBehaviour {

    public float velocidad = 5f;

    private Transform objetivo;
    private int indice_wavepoint = 0;

    void Start()
    {
        objetivo = Waypoints.waypoints[0];

    }

    void Update()
    {
        Vector3 dir = objetivo.position - transform.position;
        transform.Translate(dir.normalized * velocidad * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, objetivo.position) <= 0.1f)
        {
            GetNextWaypoint();


        }
    }

        void GetNextWaypoint()
        {
            if(indice_wavepoint >= Waypoints.waypoints.Length - 1)
            {
                Destroy(gameObject);
            return;
            }
            indice_wavepoint++;
            objetivo = Waypoints.waypoints[indice_wavepoint];

        }


       
    }
	

