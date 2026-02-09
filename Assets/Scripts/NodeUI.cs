using UnityEngine;


public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject ui;

    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.transform.position;
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}