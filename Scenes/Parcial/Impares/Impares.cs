using UnityEngine;

public class Impares : MonoBehaviour
{
	[SerializeField] private int valorMinimo = 400; 
	[SerializeField] private int valorMaximo = 600;

	void Start()
	{
		NumerosImpares();
	}

	bool EsImpar(int numero)
	{
		return numero % 2 != 0;
	}

	void NumerosImpares()
	{
		if (valorMinimo > valorMaximo) {
			Debug.Log ("El valor minimo no puede ser mayor al valor maximo.");
		} else {
			for (int i = 1; i <= 1000; i++)
			{
				if (EsImpar(i) && (i < valorMinimo || i > valorMaximo))
				{
					Debug.Log(i);  
				}
			}
		}

	}

}
