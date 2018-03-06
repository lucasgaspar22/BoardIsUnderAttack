using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBarBehaviour : MonoBehaviour {

	public float Max_Health = 100.0f; // vida máxima
	public float Cur_Health = 0.0f; // vida atual 
	public GameObject HealthBar; // bara de vidad 
	// Use this for initialization
	void Start () {
		Cur_Health = Max_Health; // ao iniciar o jogo, a vida atual é igual a vida máxima
	}

	public void decreaseHealth(float demage){ // funçao responsável por diminuir a barra de vida
		Cur_Health -= demage; // tira vida do inimigo
		float calc_health = Cur_Health / Max_Health; // calcula a porcentagem de vida   (0 - 1)
		SetHealthBar (calc_health); // atualiza a barra
	}

	public void SetHealthBar(float myHealth){
		// muda a escala X da imagem de vida 
		HealthBar.transform.localScale = new Vector3 (myHealth,HealthBar.transform.localScale.y,HealthBar.transform.localScale.z);
	}

    public float getLife()
    {
        return Cur_Health;
    }
}
