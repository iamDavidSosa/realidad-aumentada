using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public Rigidbody pelota; // Arrastra aquí el Rigidbody de la pelota desde el Inspector
    public float sensibilidad = 10f; // Ajusta la sensibilidad del movimiento
    public float fuerzaSalto = 5f; // Fuerza del salto
    private bool puedeSaltar = true; // Verifica si está en el suelo

    void Update()
    {
        // Lee la inclinación del dispositivo
        Vector3 inclinacion = Input.acceleration;

        // Aplica movimiento en los ejes X y Z
        Vector3 movimiento = new Vector3(inclinacion.x, 0, inclinacion.y);

        // Multiplica por la sensibilidad para controlar la velocidad
        pelota.AddForce(movimiento * sensibilidad);

        // Salto al tocar la pantalla
        if (Input.touchCount > 0 && puedeSaltar) // Si hay un toque en la pantalla
        {
            Touch touch = Input.GetTouch(0); // Obtén el primer toque
            if (touch.phase == TouchPhase.Began) // Cuando comienza el toque
            {
                pelota.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse); // Aplica la fuerza de salto
                puedeSaltar = false; // Evita saltar en el aire
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Detecta si está tocando el suelo para permitir un nuevo salto
        if (collision.gameObject.CompareTag("Suelo"))
        {
            puedeSaltar = true; // Permite saltar de nuevo
        }
    }
}
