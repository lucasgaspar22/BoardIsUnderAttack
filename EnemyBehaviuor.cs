using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviuor : MonoBehaviour {
	
	[SerializeField] Transform target; // para o onde o inimigo deve ir
	[SerializeField] Transform myTranform; // a atual posição do inimigo
	[SerializeField] float speed;// velocidade com qual o inimigo anda
	public int hitted; //número de tiros que o inimigo levou

	// Update is called once per frame
	void Update () {
		transform.LookAt (target); // inimigo  olha para o alvo ( no caso o jogador ) 
		transform.Translate (Vector3.forward * speed * Time.deltaTime);// anda reto até o alvo 
	}
}
