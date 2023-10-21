using UnityEngine;
using UnityEngine.UI;

public class DamageTextController : MonoBehaviour
{
    public Text damageText;
    public float moveSpeed = 2.0f;
    public float destroyTime = 1.0f;

    void Start()
    {
        damageText = GetComponent<Text>();
    }

    public void ShowDamage(int damage)
    {
        damageText.text = "-" + damage;
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        // Mover o texto para cima
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }
}
