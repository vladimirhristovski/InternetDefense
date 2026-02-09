using System;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint FakePopUpTurret;
    public GameObject FakePopUpTurretItem;
    private static bool FakePopUpTurretItemActive =  false;
    
    public TurretBlueprint FakeWebsiteTurret;
    public GameObject FakeWebsiteTurretItem;
    private static bool FakeWebsiteTurretItemActive = false;
    
    public TurretBlueprint OversharingQuizTurret;
    public GameObject OversharingQuizTurretItem;
    private static bool OversharingQuizTurretItemActive = false;
    
    public TurretBlueprint PhishingEmailTurret;
    public GameObject PhishingEmailTurretItem;
    private static bool PhishingEmailTurretItemActive = false;
    
    public TurretBlueprint SuspiciousDownloadTurret;
    public GameObject SuspiciousDownloadTurretItem;
    private static bool SuspiciousDownloadTurretItemActive = false;
    
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
        FakePopUpTurretItemActive = false;
        FakeWebsiteTurretItemActive = false;
        OversharingQuizTurretItemActive = false;
        PhishingEmailTurretItemActive = false;
        SuspiciousDownloadTurretItemActive = false;
    }

    void Update()
    {
        if (FakePopUpTurretItemActive)
        {
            FakePopUpTurretItem.SetActive(true);
        }
        else
        {
            FakePopUpTurretItem.SetActive(false);
        }
        
        if (FakeWebsiteTurretItemActive)
        {
            FakeWebsiteTurretItem.SetActive(true);
        }
        else
        {
            FakeWebsiteTurretItem.SetActive(false);
        }
        
        if (OversharingQuizTurretItemActive)
        {
            OversharingQuizTurretItem.SetActive(true);
        }
        else
        {
            OversharingQuizTurretItem.SetActive(false);
        }
        
        if (PhishingEmailTurretItemActive)
        {
            PhishingEmailTurretItem.SetActive(true);
        }
        else
        {
            PhishingEmailTurretItem.SetActive(false);
        }
        
        if (SuspiciousDownloadTurretItemActive)
        {
            SuspiciousDownloadTurretItem.SetActive(true);
        }
        else
        {
            SuspiciousDownloadTurretItem.SetActive(false);
        }
    }

    public void SelectFakePopUpTurret()
    {
        Debug.Log("Fake PopUp Turret Selected");
        buildManager.SelectTurretToBuild(FakePopUpTurret);
    }
    
    public void SelectFakeWebsiteTurret()
    {
        Debug.Log("Fake Website Turret Selected");
        buildManager.SelectTurretToBuild(FakeWebsiteTurret);
    }
    
    public void SelectOversharingQuizTurret()
    {
        Debug.Log("Oversharing Quiz Turret Selected");
        buildManager.SelectTurretToBuild(OversharingQuizTurret);
    }
    
    public void SelectPhishingEmailTurret()
    {
        Debug.Log("Phishing Email Turret Selected");
        buildManager.SelectTurretToBuild(PhishingEmailTurret);
    }
    
    public void SelectSuspiciousDownloadTurret()
    {
        Debug.Log("Suspicious Download Turret Selected");
        buildManager.SelectTurretToBuild(SuspiciousDownloadTurret);
    }

    public static void UnlockFakePopUpTurret()
    {
        FakePopUpTurretItemActive = true;
    }

    public static void UnlockFakeWebsiteTurret()
    {
        FakeWebsiteTurretItemActive = true;
    }

    public static void UnlockOversharingQuizTurret()
    {
        OversharingQuizTurretItemActive = true;
    }

    public static void UnlockPhishingEmailTurret()
    {
        PhishingEmailTurretItemActive = true;
    }
    
    public static void UnlockSuspiciousDownloadTurret()
    {
        SuspiciousDownloadTurretItemActive = true;
    }
}
