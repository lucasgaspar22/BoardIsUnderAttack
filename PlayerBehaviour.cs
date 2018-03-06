using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerBehaviour : MonoBehaviour {
	[SerializeField] int Force;
	[SerializeField] GameObject explosion;
    [SerializeField] GameObject radial;
    [SerializeField]
    GameObject Dano;
    RadialProgressBarBehaviour radialBar;
    public static int leveln = 1;
    LevelBehaviour level;
    private int timerEnemy;


    // Use this for initialization
    void Start () {
        Dano.SetActive(false);
        level = this.GetComponent<LevelBehaviour>();
       timerEnemy = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay (new Vector3( Screen.width/2, Screen.height/2 )); // Declara de onde ele solta o raio

		RaycastHit hit; // salva onde o raio bateu
		if (Input.GetMouseButtonDown (0)) { // se o botão foi pressionado

			if (Physics.Raycast (ray, out hit)) { // se o raycat bateu em algo. Out é passagem por referência no C#
				
				GameObject obj = hit.collider.gameObject; //pega o objeto em que o ray bateu
				if (obj.tag == "Enemy") {
					EnemyBehaviuor enemy = obj.GetComponent<EnemyBehaviuor> ();
					Rigidbody rb = enemy.GetComponent<Rigidbody> (); // pega o rigid body do objeto em que o ray BATEU
					LifeBarBehaviour lifeBar = obj.GetComponent<LifeBarBehaviour> ();
					if (enemy.hitted == 5) {// se ja tomou 5 tiros
						GameObject explosionClone = (GameObject)Instantiate (explosion, obj.transform.position, Quaternion.identity); //instancia a explosão no lugar do cubo
						StartCoroutine (WaitExplosion (explosionClone)); //corrotina para esperar a explosão acabar
						Destroy (obj);// destroi o inimigo
					} else {
						enemy.hitted++; // aumenta o numero de tiros que o inimigo tomou
						lifeBar.decreaseHealth (16.666f);// atualiza a barra
						rb.AddForceAtPosition (ray.direction * Force, hit.point);// empurra o inimigo para tras
					}
				} 
			}
		}
	}

	public void Load(){
		radial.SetActive (true);
		radial.GetComponentInChildren<RadialProgressBarBehaviour>().myStart ();
	}


	public void OnCollisionStay(Collision col){
       
		if(col.gameObject.tag=="Enemy"){// se estiver encostando no inimifo
            timerEnemy++;//incrementa um contador
		}
        if (timerEnemy >= 15){// se o contator for maior do que 4
            timerEnemy = 0;//zera o timer
			LifeBarBehaviour mylifeBar = this.GetComponent<LifeBarBehaviour>();
			mylifeBar.decreaseHealth (5f);
            if (mylifeBar.getLife()<= 58f) 
            {
                Dano.SetActive(true);
            }
			if (mylifeBar.Cur_Health == 0) {
				SceneManager.LoadScene ("GameOverScreen");
			}
		}
	}

    IEnumerator WaitExplosion(GameObject explosionClone)
    {
        yield return new WaitForSeconds(3); // espera por 3 segundos
        Destroy(explosionClone);
    }

	public void WaitProgressBar(){
		level.ChangeObjective ();
		radial.SetActive (false);
        
    }
		
}