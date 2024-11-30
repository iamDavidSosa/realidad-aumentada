using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float velocidadMovimiento = 10f;
	public float fuerzaSalto = 300f;
	private Rigidbody rb;
	public Text textoGanar;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		textoGanar.text="";
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Finish"))
		{
			textoGanar.text = "¡Ganaste!";
			Invoke("CargarSiguienteNivel", 5f);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			// Aquí podrías cargar el siguiente nivel o mostrar un mensaje de ganar
		}
		else if (other.gameObject.CompareTag("Enemy"))
		{
			textoGanar.text = "¡Perdiste!";
			Invoke("CargarSiguienteNivel", 5f);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reinicia la escena
		}
	}

	void Update()
	{
		// Movimiento horizontal y vertical
		float movimientoH = Input.GetAxis("Horizontal");
		float movimientoV = Input.GetAxis("Vertical");

		Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV) * velocidadMovimiento * Time.deltaTime;
		rb.AddForce(movimiento, ForceMode.VelocityChange);

		// Saltar con espacio o clic izquierdo del ratón
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
		{
			rb.AddForce(Vector3.up * fuerzaSalto);
		}

		if (transform.position.y < -10)
		{
			textoGanar.text = "¡Perdiste!";
			Invoke("CargarSiguienteNivel", 5f);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}

