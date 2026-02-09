using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public GameObject ui;
    public GameObject correctUi;
    public GameObject wrongUi;
    public Text questionText;
    public Text answerAText;
    public Text answerBText;
    public Text answerCText;
    public Text answerDText;
    public Button answerA;
    public Button answerB;
    public Button answerC;
    public Button answerD;
    public List<Question> fakePopUpQuestions;
    public List<Question> fakeWebsiteQuestions;
    public List<Question> oversharingQuizQuestions;
    public List<Question> phishingEmailQuestions;
    public List<Question> suspiciousDownloadQuestions;
    private Question _selectedQuestion;
    private static bool _fakePopUp;
    private bool _fakePopUp2;
    private bool _fakePopUp3;
    private static bool _fakeWebsite;
    private bool _fakeWebsite2;
    private bool _fakeWebsite3;
    private static bool _oversharingQuiz;
    private bool _oversharingQuiz2;
    private bool _oversharingQuiz3;
    private static bool _phishingEmail;
    private bool _phishingEmail2;
    private bool _phishingEmail3;
    private static bool _suspiciousDownload;
    private bool _suspiciousDownload2;
    private bool _suspiciousDownload3;

    void Awake()
    {
        _fakePopUp = false;
        _fakePopUp2 = false;
        _fakePopUp3 = false;
        _fakeWebsite = false;
        _fakeWebsite2 = false;
        _fakeWebsite3 = false;
        _oversharingQuiz = false;
        _oversharingQuiz2 = false;
        _oversharingQuiz3 = false;
        _phishingEmail = false;
        _phishingEmail2 = false;
        _phishingEmail3 = false;
        _suspiciousDownload = false;
        _suspiciousDownload2 = false;
        _suspiciousDownload3 = false;
    }
    void Update()
    {
        if (_fakePopUp)
        {
            SetUpQuestion(fakePopUpQuestions, true);
            _fakePopUp = false;
            _fakePopUp2 = true;
            ui.SetActive(true);
            return;
        }
        
        if (_fakeWebsite)
        {
            SetUpQuestion(fakeWebsiteQuestions, true);
            _fakePopUp2 = false;
            _fakeWebsite = false;
            _fakeWebsite2 = true;
            ui.SetActive(true);
            return;
        }
        
        if (_oversharingQuiz)
        {
            SetUpQuestion(oversharingQuizQuestions, true);
            _fakeWebsite2 =  false;
            _oversharingQuiz = false;
            _oversharingQuiz2 =  true;
            ui.SetActive(true);
            return;
        }
        
        if (_phishingEmail)
        {
            SetUpQuestion(phishingEmailQuestions, true);
            _oversharingQuiz2 = false;
            _phishingEmail = false;
            _phishingEmail2 = true;
            ui.SetActive(true);
            return;
        }
        
        if (_suspiciousDownload)
        {
            SetUpQuestion(suspiciousDownloadQuestions, true);
            _phishingEmail2 = false;
            _suspiciousDownload = false;
            _suspiciousDownload2 = true;
            ui.SetActive(true);
            return;
        }
        
        if (WaveSpawner.GetEnemiesKilled() == 2 && WaveSpawner.GetEnemiesAlive() > 0)
        {
            if (_fakePopUp2)
            {
                SetUpQuestion(fakePopUpQuestions, false);
                WaveSpawner.Deactivate();
                _fakePopUp2 = false;
                _fakePopUp3 = true;
                ui.SetActive(true);
                return;
            }

            if (_fakeWebsite2)
            {
                SetUpQuestion(fakeWebsiteQuestions, false);
                WaveSpawner.Deactivate();
                _fakeWebsite2 = false;
                _fakeWebsite3 = true;
                ui.SetActive(true);
                return;
            }

            if (_oversharingQuiz2)
            {
                SetUpQuestion(oversharingQuizQuestions, false);
                WaveSpawner.Deactivate();
                _oversharingQuiz2 = false;
                _oversharingQuiz3 = true;
                ui.SetActive(true);
                return;
            }

            if (_phishingEmail2)
            {
                SetUpQuestion(phishingEmailQuestions, false);
                WaveSpawner.Deactivate();
                _phishingEmail2 = false;
                _phishingEmail3 = true;
                ui.SetActive(true);
                return;
            }

            if (_suspiciousDownload2)
            {
                SetUpQuestion(suspiciousDownloadQuestions, false);
                WaveSpawner.Deactivate();
                _suspiciousDownload2 = false;
                _suspiciousDownload3 = true;
                ui.SetActive(true);
                return;
            }
        }
    }
    
    private IEnumerator ShowFeedback(GameObject feedbackUI)
    {
        yield return new WaitForSecondsRealtime(5);
        ui.SetActive(false);
        WaveSpawner.ResetCountdown();
        WaveSpawner.SetActive();
        feedbackUI.SetActive(false);
    }

    private void WrongAnswer()
    {
        wrongUi.SetActive(true);
        StartCoroutine(ShowFeedback(wrongUi));
    }

    private void CorrectAnswer()
    {
        correctUi.SetActive(true);
        StartCoroutine(ShowFeedback(correctUi));
        if (_fakePopUp2)
        {
            Shop.UnlockFakePopUpTurret();
        }

        if (_fakeWebsite2)
        {
            Shop.UnlockFakeWebsiteTurret();
        }

        if (_oversharingQuiz2)
        {
            Shop.UnlockOversharingQuizTurret();
        }

        if (_phishingEmail2)
        {
            Shop.UnlockPhishingEmailTurret();
        }

        if (_suspiciousDownload2)
        {
            Shop.UnlockSuspiciousDownloadTurret();
        }
    }
    
    private void CorrectAnswer2()
    {
        correctUi.SetActive(true);
        StartCoroutine(ShowFeedback(correctUi));
        if (_fakePopUp3)
        {
            _fakePopUp3 = false;
            PlayerStats.Money += 100;
        }

        if (_fakeWebsite3)
        {
            _fakeWebsite3 = false;
            PlayerStats.Money += 150;
        }

        if (_oversharingQuiz3)
        {
            _oversharingQuiz3 = false;
            PlayerStats.Money += 200;
        }

        if (_phishingEmail3)
        {
            _phishingEmail3 = false;
            PlayerStats.Money += 250;
        }

        if (_suspiciousDownload3)
        {
            _suspiciousDownload3 = false;
            PlayerStats.Money += 300;
        }
    }
    
    void SetUpQuestion(List<Question> questions, bool main)
    {
        answerA.onClick.RemoveAllListeners();
        answerB.onClick.RemoveAllListeners();
        answerC.onClick.RemoveAllListeners();
        answerD.onClick.RemoveAllListeners();
        _selectedQuestion = null;
            
        _selectedQuestion = questions[Random.Range(0, questions.Count)];
            
        questionText.text = _selectedQuestion.questionText;
        answerAText.text = _selectedQuestion.answerA;
        answerBText.text = _selectedQuestion.answerB;
        answerCText.text = _selectedQuestion.answerC;
        answerDText.text = _selectedQuestion.answerD;
            
        if (_selectedQuestion.correctAnswer == _selectedQuestion.answerA)
        {
            answerA.onClick.AddListener(main ? CorrectAnswer : CorrectAnswer2);
        }
        else
        {
            answerA.onClick.AddListener(WrongAnswer);
        }
        
        if (_selectedQuestion.correctAnswer == _selectedQuestion.answerB)
        {
            answerB.onClick.AddListener(main ? CorrectAnswer : CorrectAnswer2);       
        }
        else
        {
            answerB.onClick.AddListener(WrongAnswer);
        }
        
        if (_selectedQuestion.correctAnswer == _selectedQuestion.answerC)
        {
            answerC.onClick.AddListener(main ? CorrectAnswer : CorrectAnswer2);
            
        }
        else
        {
            answerC.onClick.AddListener(WrongAnswer);
        }
        
        if (_selectedQuestion.correctAnswer == _selectedQuestion.answerD)
        {
            answerD.onClick.AddListener(main ? CorrectAnswer : CorrectAnswer2);       
        }
        else
        {
            answerD.onClick.AddListener(WrongAnswer);
        }
            
        questions.Remove(_selectedQuestion);
    }

    public static void EnableFakePopUp()
    {
        _fakePopUp = true;
    }
    
    public static void EnableFakeWebsite()
    {
        _fakeWebsite = true;
    }
    
    public static void EnableOversharingQuiz()
    {
        _oversharingQuiz = true;
    }
    
    public static void EnablePhishingEmail()
    {
        _phishingEmail = true;
    }
    
    public static void EnableSuspiciousDownload()
    {
        _suspiciousDownload = true;
    }
}
