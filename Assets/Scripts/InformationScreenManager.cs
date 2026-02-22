using UnityEngine;
using UnityEngine.UI;

public class InformationScreenManager : MonoBehaviour
{
    public GameObject ui;
    public Text titleText;
    public Text aboutEnemyText;
    public Text aboutText;
    public Text aboutTurretText1;
    public Text aboutTurretText2;
    public Image enemyImage;
    public Image towerImage;
    public Button continueButton;
    
    public InformationPanel fakePopUpInformationPanel;
    public InformationPanel fakeWebsiteInformationPanel;
    public InformationPanel oversharingQuizInformationPanel;
    public InformationPanel phishingEmailInformationPanel;
    public InformationPanel suspiciousDownloadInformationPanel;
    
    private bool _fakePopUp;
    private bool _fakeWebsite;
    private bool _oversharingQuiz;
    private bool _phishingEmail;
    private bool _suspiciousDownload;

    void Awake()
    {
        _fakePopUp = true;
        _fakeWebsite = false;
        _oversharingQuiz = false;
        _phishingEmail = false;
        _suspiciousDownload = false;
    }
     void Update()
    {
        if (WaveSpawner.GetWaveIndex() == 0 && _fakePopUp)
        {
            SetUpInformationPanel(fakePopUpInformationPanel, 0);
            WaveSpawner.Deactivate();
            ui.SetActive(true);
            _fakePopUp = false;
            _fakeWebsite = true;
            return;
        }
        
        if (WaveSpawner.GetWaveIndex() == 1 && WaveSpawner.GetCountdown() <= 0f && _fakeWebsite)
        {
            SetUpInformationPanel(fakeWebsiteInformationPanel, 1);
            WaveSpawner.Deactivate();
            ui.SetActive(true);
            _fakeWebsite = false;
            _oversharingQuiz = true;
            return;
        }
        
        if (WaveSpawner.GetWaveIndex() == 2 && WaveSpawner.GetCountdown() <= 0f && _oversharingQuiz)
        {
            SetUpInformationPanel(oversharingQuizInformationPanel, 2);
            WaveSpawner.Deactivate();
            ui.SetActive(true);
            _oversharingQuiz = false;
            _phishingEmail = true;
            return;
        }
        
        if (WaveSpawner.GetWaveIndex() == 3 && WaveSpawner.GetCountdown() <= 0f && _phishingEmail)
        {
            SetUpInformationPanel(phishingEmailInformationPanel, 3);
            WaveSpawner.Deactivate();
            ui.SetActive(true);
            _phishingEmail = false;
            _suspiciousDownload = true;
            return;
        }
        
        if (WaveSpawner.GetWaveIndex() == 4 && WaveSpawner.GetCountdown() <= 0f && _suspiciousDownload)
        {
            SetUpInformationPanel(suspiciousDownloadInformationPanel, 4);
            WaveSpawner.Deactivate();
            ui.SetActive(true);
            _suspiciousDownload = false;
            return;
        }
    }

    private void ContinueButton(int infoNumber)
    {
        ui.SetActive(false);
        if (infoNumber == 0)
        {
            QuestionManager.EnableFakePopUp();
            return;
        }

        if (infoNumber == 1)
        {
            QuestionManager.EnableFakeWebsite();
            return;
        }

        if (infoNumber == 2)
        {
            QuestionManager.EnableOversharingQuiz();
            return;
        }

        if (infoNumber == 3)
        {
            QuestionManager.EnablePhishingEmail();
            return;
        }

        if (infoNumber == 4)
        {
            QuestionManager.EnableSuspiciousDownload();
            return;
        }
    }
    
    void SetUpInformationPanel(InformationPanel informationPanel, int infoNumber)
    {
        continueButton.onClick.RemoveAllListeners();
        
        titleText.text = informationPanel.title;
        aboutEnemyText.text = informationPanel.enemy;
        aboutText.text = informationPanel.about;
        aboutTurretText1.text = informationPanel.turret1;
        aboutTurretText2.text = informationPanel.turret2;
        enemyImage.sprite = informationPanel.enemySprite;
        towerImage.sprite = informationPanel.turretSprite;
        
        continueButton.onClick.AddListener(() => { ContinueButton(infoNumber); });
    }
}
