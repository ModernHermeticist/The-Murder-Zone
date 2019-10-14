using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;

    private Transform target;
    private int nodeIndex = 0;
    private int maxIndex = 0;

    [SerializeField]
    private float health = 4f;

    public int GetNodeIndex()
    {
        return nodeIndex;
    }

    public void IncrementNodeIndex()
    {
        if (nodeIndex < maxIndex)
        {
            nodeIndex += 1;
        }
    }

    public int GetMaxIndex()
    {
        return maxIndex;
    }

    public void SetNextTarget()
    {
        if (nodeIndex < maxIndex)
        {
            target = Nodes.nodes[nodeIndex];
        }
    }

    public Transform GetTarget()
    {
        return target;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public float GetHealth()
    {
        return health;
    }

    private void Start()
    {
        target = Nodes.nodes[nodeIndex];
        maxIndex = Nodes.nodes.Length;
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            IncrementNodeIndex();
            SetNextTarget();
        }
    }
}
