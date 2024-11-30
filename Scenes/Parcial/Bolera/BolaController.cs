using UnityEngine;

public class BolaController : MonoBehaviour
{
	public float fuerzaLanzamiento = 10f; // Ajustable desde el Inspector
	private Rigidbody rb;
	private bool haSidoLanzada = false;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.linearVelocity = Vector3.zero; // Asegúrate de que no tenga velocidad inicial
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0) && !haSidoLanzada)
		{
			LanzarBola();
			haSidoLanzada = true;
		}
	}

	void LanzarBola()
	{
		// Aplicar fuerza solo en la dirección hacia adelante
		Vector3 fuerza = transform.forward * fuerzaLanzamiento;
		rb.AddForce(fuerza, ForceMode.Impulse);
	}
}
