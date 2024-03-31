using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeOrbit : MonoBehaviour
{

    public Transform pontoCentral; // O ponto central da �rbita.
    public float raio = 2.0f; // O raio da �rbita.
    public float velocidadeRotacao = 50.0f; // A velocidade de rota��o.
    public Transform cam;
    private float angulo = 0.0f;

    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        angulo += velocidadeRotacao * Time.deltaTime;

        // Calcula a nova posi��o com base no ponto central e no raio.
        float x = pontoCentral.position.x + raio * Mathf.Cos(angulo * Mathf.Deg2Rad);
        float y = pontoCentral.position.y + raio * Mathf.Sin(angulo * Mathf.Deg2Rad);

        // Define a nova posi��o do objeto.
        transform.position = new Vector3(x, y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<CharacterEnemmy>().life--;
            collision.GetComponent<CharacterEnemmy>().Skin.GetComponent<Animator>().Play("Hit", -1);
            cam.GetComponent<Animator>().Play("CamPlayerDamge", -1);

        }
    }
}



