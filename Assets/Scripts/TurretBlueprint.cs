using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;
    
    public int GetSellAmmount()
    {
        return cost / 2;
    }
}
