using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDot : MonoBehaviour
{
    [SerializeField] private GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 vectorResultante = (player.transform.position - transform.position).normalized;
        Debug.DrawLine(transform.position, player.transform.position, Color.white);

        if(Vector2.Dot(transform.right, vectorResultante) > 0.5)
        {
            Debug.DrawLine(transform.position, player.transform.position, Color.red);

            RaycastHit2D apuntador;
            //Utilizamos el Raycast para detectar si hay algun objeto de por medio
            //Raycast utiliza 2 vectores por default, uno de origen y otro de direccion
            //origen = posicion pato, direccion = vector resultante
            //El raycast tambien puede tener un float que representa la distancia

            apuntador = Physics2D.Raycast(transform.position, vectorResultante, 4.0f);
            
            //Si el vector del Raycast del apuntador ve al jugador entonces el pato va a seguir al jugador            
            if(apuntador.collider.gameObject == player)
            {
                Debug.DrawLine(transform.position, player.transform.position, Color.blue);

                transform.right = vectorResultante;
            }
        }
    }
}
