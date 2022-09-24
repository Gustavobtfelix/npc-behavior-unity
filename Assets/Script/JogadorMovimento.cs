using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour
{

    public float Velocidade = 10;
    private float eixoX;
    private float eixoZ;
    private Vector3 direcao;
    public LayerMask MascaraObjeto; // definir novo layer para objeto selecionado
    public GameObject TextoGameOver;
    public bool Vivo = true;
    private Rigidbody rigidbodyJogador;
    private Animator animatorJogador;

    void Start()
    {
        rigidbodyJogador = GetComponent<Rigidbody>();
        animatorJogador = GetComponent<Animator>();
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

        //rotacao da camera
        //variavel do tipo raio para identificar posicao
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        //mostra raio
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        //Variavel que pega posicao que o raio tem impacto com um objeto
        RaycastHit impacto;
        //Testa a fisica do. gera raio(raio gerado, variavel de impacto, limite de distancia do raio, restricao de objeto que a mascara acerta)
        if (Physics.Raycast(raio, out impacto, 100, MascaraObjeto))
        {               //salva posicao do raio a partir da posicao do jogador
            Vector3 posicaoMiraJogador = impacto.point - transform.position;
            //fixa o y da rotacao
            posicaoMiraJogador.y = transform.position.y;
            //valor posicao rotacao
            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);
            //altera rotacao do jogador
            rigidbodyJogador.MoveRotation(novaRotacao);

        }
    }
}