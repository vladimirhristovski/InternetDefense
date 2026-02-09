using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private TurretBlueprint turretToBuild;
    public GameObject buildEffect;
    private Node selectedNode;
    public NodeUI nodeUI;
    public GameObject sellEffect;
    
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Can't have more than one BuildManager instance!");
            return;
        }
        instance = this;
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }
    
    public bool CanBuild { get { return turretToBuild != null; } }
    
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
