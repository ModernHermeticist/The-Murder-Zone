using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;

    private Transform target;
    private int nodeIndex = 0;
    private int maxIndex = 0;

    public float startHealth = 10f;

    private float health;


    public Image healthBar;

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

        healthBar.fillAmount = health / startHealth;
        Color healthColor = healthBar.color;
        healthColor.r = 1 / healthBar.fillAmount;
        healthColor.g = healthBar.fillAmount;
        healthBar.color = healthColor;
    }

    public float GetHealth()
    {
        return health;
    }

    private void Start()
    {
        health = startHealth;
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
