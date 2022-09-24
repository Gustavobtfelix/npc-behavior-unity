using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float Velocidade = 10;
    private float eixoX;
    private float eixoZ;
    private Vector3 direcao;
    private Rigidbody rigidbodyJogador;

    void Start()
    {
        rigidbodyJogador = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Inputs do Jogador - Guardando teclas apertadas
        eixoX = Input.GetAxis("Horizontal");
        eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);
    }

    void FixedUpdate()
    {   //Movimentacao do Jogador por segundo
        rigidbodyJogador.MovePosition
            (rigidbodyJogador.position +
            (direcao * Velocidade * Time.deltaTime));
    }
}
