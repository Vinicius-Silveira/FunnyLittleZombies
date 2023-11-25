using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Carro : MonoBehaviour
{
[SerializeField] WheelCollider RodaTraseiraDireita;
[SerializeField] WheelCollider RodaFrenteDireita;
[SerializeField] WheelCollider RodaFrenteEsquerda;
[SerializeField] WheelCollider RodaTraseiraEsquerda;
[SerializeField] GameObject luz1;
[SerializeField] GameObject luz2;
[SerializeField] GameObject freio1;
[SerializeField] GameObject freio2;
[SerializeField] GameObject sol;
public float aceleracao = 500f;
public float freio = 300f;
public float anguloTorque = 15f;
private float aceleracaoAtual = 0f;
private bool farol = true;
private bool dia = true;
private float freioAtual = 0f;
private float anguloTorqueAtual = 0f;
private void FixedUpdate()
{
aceleracaoAtual = aceleracao * Input.GetAxis("Vertical");
RodaFrenteDireita.motorTorque = aceleracaoAtual;
RodaFrenteEsquerda.motorTorque = aceleracaoAtual;
anguloTorqueAtual = anguloTorque * Input.GetAxis("Horizontal");
RodaFrenteDireita.steerAngle = anguloTorqueAtual;
RodaFrenteEsquerda.steerAngle = anguloTorqueAtual;
if (Input.GetKey(KeyCode.Space))
{
freioAtual = freio;
        freio1.SetActive(true);
        freio2.SetActive(true);
}
else
{
freioAtual = 0f;
        freio1.SetActive(false);
        freio2.SetActive(false);
}
RodaFrenteDireita.brakeTorque = freioAtual;
RodaFrenteEsquerda.brakeTorque = freioAtual;
RodaTraseiraDireita.brakeTorque = freioAtual;
RodaTraseiraEsquerda.brakeTorque = freioAtual;
if (Input.GetKey(KeyCode.E)){
    if(farol == !false){
        luz1.SetActive(false);
        luz2.SetActive(false);
        farol = false;
    } else{
        luz1.SetActive(true);
        luz2.SetActive(true);
        farol = true;
    }
}
if (Input.GetKey(KeyCode.Q)){
    if(dia == !false){
        sol.SetActive(false);
        dia = false;
    } else{
        sol.SetActive(true);
        dia = true;
    }
}

}
}
