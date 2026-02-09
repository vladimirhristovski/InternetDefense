using UnityEngine;

[System.Serializable]
public class InformationPanel
{
    [TextArea(3, 10)]
    public string title;
    
    [TextArea(3, 10)]
    public string enemy;
    
    [TextArea(3, 10)]
    public string about;
    
    [TextArea(3, 10)]
    public string turret;
    
    public Sprite enemySprite;
    public Sprite turretSprite;
}