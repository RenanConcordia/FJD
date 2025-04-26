
using System.Collections.Generic;
using UnityEngine;

/** 
 *	
 *	Alterações no codigo
 *	
 *	
 *	[29/03] Atividade - Parte 1A
 *	
 *	Mudar a massa dos objetos altera o seu comportamento? Por que?	
 *		
 *		Sim, pois quanto maior mais tempo leva para o objeto acelarar.	
 *	
 *	
 *	
 *	Atividade Bonus
 *	
 *		Questão 1 - Um corpo com massa de 5 kg é submetido a uma força de intensidade 25N. Qual é a aceleração que ele adquire?
 *		
 *			O objeto teve a aceleração adquirida igual a 5m/s2
 *		
 *		Questão 2 - (PUC) Quando a resultante das forças que atuam sobre um corpo é 10N, sua aceleração é 4m/s2. Se a resultante das forças fosse 12,5N, a aceleração seria de:
 *		
 *			massa? 
 *		
 *			a = Fr/m
 *			4 = 10/m
 *			4/10 = 1/m → 10/4 = m
 *			m =  2,5
 *			
 */
public class Cube : MonoBehaviour {
	
	
	public Vector3 aceleracao = new Vector3( 0, 0, 0 );
	public Vector3 velocidade = new Vector3( 0, 0, 0 );
	
//	public List<Vector3> forcas = new List<Vector3>();
//	public Vector3 PESO = new Vector3( 0, 0, 0 );
//	public Vector3 GRAVIDADE = new Vector3( 0f, -9.8f, 0f );
	
	/// constante elastica
	public float K_ELASTICO = 1.0f;
	/// constante de amortecimento
	public float B_AMORTECIMENTO = 0.0f;
	
	public Vector3 forca_resultante = new Vector3( 0, 0, 0 );
	
	public float massa = 1;
	
	public Vector3 ancoragem = new Vector3(0,0,0);
	
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }


    // Update is called once per frame
    void FixedUpdate() {
		
		UpdateAcceleration();
		
		UpdateVelocity();
		UpdatePosition();
		
    }
	
	
	
	
	
	/// adicionado na aula 29/03/2025
	void UpdateAcceleration() {
		
	//	forca_resultante = new Vector3(0,0,0);
		
	//	foreach( Vector3 f in forcas ) 
	//		forca_resultante += f;
		
	//	PESO = GRAVIDADE * massa;
	//	forca_resultante = PESO;
		
	//	forca_resultante = -K_ELASTICO * transform.position;
		
		/// F = -bv - kx
	//	forca_resultante = -K_ELASTICO * transform.position;
	//	forca_resultante = -velocidade * B_AMORTECIMENTO - K_ELASTICO * transform.position;
		forca_resultante = -velocidade * B_AMORTECIMENTO - K_ELASTICO * (transform.position - ancoragem);
		
		
		aceleracao = forca_resultante / massa;
		
	}
	
	void UpdateVelocity() {
		
		velocidade += aceleracao * Time.deltaTime;
		
	}
	
	/// ordem 1
	void UpdatePosition() {
		
		transform.position += velocidade * Time.deltaTime;
		
	}
	
	/*private void OnCollisionEnter( Collision collision ) {
		
		G = new Vector3(0f,0f,0f);
		velocidade = new Vector3(0f,0f,0f);
		
		
	}*/
	
	
}
