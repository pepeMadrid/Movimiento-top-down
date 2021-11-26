using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoverPorCLicPC : MonoBehaviour {

    public GameObject objetivoParticulas;
    public GameObject auxObjetivo;
    public GameObject interfaz;
    private bool animando = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !animando)
        {

            Ray rayModelo = Camera.main.ScreenPointToRay(Input.mousePosition);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag.Equals("Terreno"))
                {

                    GetComponent<NavMeshAgent>().SetDestination(hit.point);

                    transform.Find("Bruja").GetComponent<eventoOntrigger>().dragon.transform.LookAt(hit.point);
                    transform.Find("Bruja").GetComponent<eventoOntrigger>().dragon.GetComponent<NavMeshAgent>().SetDestination(hit.point);

                    if (auxObjetivo)
                        Destroy(auxObjetivo);
                    auxObjetivo = Instantiate(objetivoParticulas, hit.point,Quaternion.Euler(90,0,0));


                }
            }

        }

        if (auxObjetivo)
        {
            transform.Find("Bruja").LookAt(auxObjetivo.transform.position);
        }
            
    }

   


    public void destruirParticulas()
    {
        Destroy(auxObjetivo);

    }

}

