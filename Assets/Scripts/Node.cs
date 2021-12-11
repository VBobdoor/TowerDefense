using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Node : MonoBehaviour
{
    [SerializeField] private Color selectedColor;
    [SerializeField] private Transform parentTransform;
    private Color standartColor;

    private bool isTurretBuild = false;
    private Renderer rendererNode;

    private void Awake()
    {
        rendererNode = GetComponent<Renderer>();
        standartColor = rendererNode.material.color;
    }

    private void OnMouseDown()
    {
        if(!isTurretBuild)
        {
            TurretsShop.turretsShop.SetActiveShopUI(this);
            ChangeColorSelected();
        }
    }

    public void BuildTurret(GameObject turret)
    {
        isTurretBuild = true;
        Instantiate(turret, parentTransform);
    }

    public void ChangeColorStandart()
    {
        rendererNode.material.color = standartColor;
    }

    private void ChangeColorSelected()
    {
        rendererNode.material.color = selectedColor;
    }

    
}
