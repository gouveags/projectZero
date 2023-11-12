using UnityEngine;

public class fireBall : MonoBehaviour
{
    public Transform a;
    public Transform b;
    public Transform Skin;
    public float velObj;

    void Start()
    {
        SpawnAtPositionA();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, b.position, velObj * Time.deltaTime);

        if (Vector2.Distance(transform.position, b.position) < 0.1f)
        {
            SpawnAtPositionA();
            Skin.localScale = new Vector3(-1, 1, 1);
            velObj = Random.Range(5, 20);
        }
    }

    void SpawnAtPositionA()
    {
        transform.position = a.position;
    }
}
