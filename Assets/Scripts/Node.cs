using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    
    private Renderer rend;
    private Color startColor;
    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (turret != null)
        { 
            buildManager.SelectNode(this);
            return;
        }
        
        if (!buildManager.CanBuild)
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());    
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build that turret!");
            return;
        }
        
        PlayerStats.Money -= blueprint.cost;
        
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, transform.position, Quaternion.identity);
        turret = _turret;
        
        turretBlueprint =  blueprint;
        
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        
        Debug.Log("Turret built!");
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmmount();
        
        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        
        Destroy(turret);
        turretBlueprint = null;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
        
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
