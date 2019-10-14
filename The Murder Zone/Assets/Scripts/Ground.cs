using UnityEngine;

public class Ground : MonoBehaviour
{
    public Color hovorColor;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can't build here! - TODO: Display on screen.");
            return;
        }

        // Build a turret

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        Transform t = transform;
        t.position.Set(t.position.x, t.position.y + 0.1f, t.position.z);
        turret = Instantiate(turretToBuild, t.position, transform.rotation);
    }
    private void OnMouseEnter()
    {
        rend.material.color = hovorColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
