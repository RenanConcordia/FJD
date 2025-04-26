using UnityEngine;

public class Sphere : MonoBehaviour
{
	
	public GameObject sphereB;
	
	public Vector3 aceleracaoA = new Vector3( 0, 0, 0 );
	public Vector3 velocidadeA = new Vector3( 0, 0, 0 );
	
	public Vector3 aceleracaoB = new Vector3( 0, 0, 0 );
	public Vector3 velocidadeB = new Vector3( 0, 0, 0 );
	
	public float massaA = 1;
	public float massaB = 1;
	
	/// constante elastica
	public float elastico = 1.0f;
	public float amortecimento = 0.0f;
	
//	public float elasticoA = 1.0f;
//	public float amortecimentoA = 0.0f;
//	
//	public float elasticoB = 1.0f;
//	public float amortecimentoB = 0.0f;
	
	//public Vector3 ancoragem = new Vector3(0,0,0);
	
	public Vector3 forcaResultanteA = new Vector3( 0, 0, 0 );
	public Vector3 forcaResultanteB = new Vector3( 0, 0, 0 );
	
	public float distancia = 0.0f;
	public float distanciaEquilibrio = 3.0f;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		
	//	distanciaInicial = Vector3.Distance(sphereB.transform.position, transform.position);
		
	}

    // Update is called once per frame
// void Update() { }
	
	
    // Update is called once per frame
    void FixedUpdate() {
		
		UpdateAcceleration();
		
		UpdateVelocity();
		UpdatePosition();
		
    }
	
	
	/// adicionado na aula 29/03/2025
	void UpdateAcceleration() {
		
	//	forcaResultanteA = -velocidadeA * amortecimentoB - elasticoA * (transform.position - ancoragem);
	//	forcaResultanteB = -velocidadeB * amortecimentoB - elasticoA * (sphereB.transform.position - ancoragem);
	//	
	//	aceleracaoA = forcaResultanteA / massaA;
	//	aceleracaoB = forcaResultanteB / massaB;
		
		
		
		distancia = Vector3.Distance(sphereB.transform.position, transform.position);
		
		Vector3 dist = new Vector3( (distancia - distanciaEquilibrio), 0f, 0f ); 
		
	//	Vector3 dir = -(sphereB.transform.position - transform.position);
	//	dir.Normalize();
		
	//	Vector3 dist = dir * (distancia - distanciaEquilibrio); 
		
		forcaResultanteA = -elastico * dist;
		forcaResultanteB = -forcaResultanteA;
	//	forcaResultanteA = -velocidadeA * amortecimento - elastico * dist;
	//	forcaResultanteB = -velocidadeB * amortecimento - elastico * dist;
		
		aceleracaoA = forcaResultanteA / massaA;
		aceleracaoB = forcaResultanteB / massaB;
		
	}
	
	void UpdateVelocity() {
		
		velocidadeA += aceleracaoA * Time.deltaTime;
		velocidadeB += aceleracaoB * Time.deltaTime;
		
	}
	
	/// ordem 1
	void UpdatePosition() {
		
		transform.position += velocidadeA * Time.deltaTime;
		sphereB.transform.position += velocidadeB * Time.deltaTime;
		
	}
	
	
}
