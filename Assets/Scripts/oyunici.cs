using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;


public class oyunici : MonoBehaviour
{

    [Header("Quality")]
    public GameObject[] _qualityObject;
    public Text _qualityText;
    [Header("Seyf Area")] 
    public GameObject m_MagnetReward;
    public GameObject m_NitroReward;
    public GameObject m_4WDReward;
    public static string m_AdType;
    public GameObject m_Get2XPopup;
    public GameObject m_RewardFailed;
    public GameObject m_RewardedNotReady;
    
    [Header("Tutorial System")]
    public GameObject _ımages;
    public GameObject _4wdColliders;
    public int tutorialcounter = 0;
    public bool tutorialcollidertouch = false;
    public int whatTutorialCollider;
    public GameObject _tutorialNitroButton, _tutorialMagnetbutton, _tutorial4WDButton;
    float _tutorialTimer;
    public bool frenTouch;
    public GameObject _tutorialCoinAndFuelTank;

    [Header("• Single Mode System")]
    public GameObject SingleModeGameOverPanel;
    public GameObject spawn_single, singleModeTouchToContinueButton,_selectAndConinuePanel,_get2xButton;
    public Text singleLastDistanceText, singleModeAirTimeText, singleModeFrontFlipText, singleModeBackFlipText;
    public Text singleModeResultText, singleModeCollectedCoinsText, bestScoreText, coinsEndAwardText;
    [HideInInspector] public float airTimeCounter, frontFlipCounter, backFlipCounter;

    [Header("• 2P Mode System")]
    public GameObject _2PModeGameOverPanel;
    public GameObject _2PModeTouchToContinueButton;
    [HideInInspector] public GameObject _2PModeBotCar, spawn_vs_1, spawn_vs_2, _2PModeScoreTableHeader;
    //public Text ikinci_arac_fark, _2pModeScoreText, _2pModeCoinsEndAwardText;
    public Text _2pModeResultText;
    public Text _2PModePlayerResult1Text, _2PModePlayerResult2Text, _2PModePlayerName1Text, _2PModePlayerName2Text;


    [Header("• 4P Mode System")]
    public GameObject[] spawn_battle;
    public GameObject[] _4PModeCars;
    public GameObject _4PModeGameOverPanel, _4PModeTouchToContinueButton;
    public Text _4PModePlayerName1Text, _4PModePlayerName2Text, _4PModePlayerName3Text, _4PModePlayerName4Text;
    public Text _4PModeResualtText;
    public Text _4PModePlayerResult1Text, _4PModePlayerResult2Text, _4PModePlayerResult3Text, _4PModePlayerResult4Text;
    //public Text score1_bat, score2_bat, best_bat;

    [Header("• Mission System")]
    public GameObject missionCompletedPanel;
    public GameObject missionTimerPanel, MissionTouchToContunieButton;
    public Text missionPropertyText, missionCompletedRewardText, whatMissionText;
    [HideInInspector] public float oyun_zaman = 0;
    public GameObject panel_dakika, panel_saniye, panel_salise;
    int point, tur, mission_deger, particle;


    [Header("• Nitro System")]
    public Text[] totalNitroText;
    public int nitroPrice;
    public Button NitroButton;
    public GameObject _nitroBuyButton;
    private int nitroNumber = 1, nitroPurshased;
    public Text nitroPriceText, NitroNumberText;
    private bool NitroClick = false;
    private float nitroTimer;


    [Header("• Magnet System")]
    public Text[] totalMagnetText;
    public int MagnetPrice;
    public Button magnetButton;
    public GameObject _magnetBuyButton;
    private int magnetNumber = 1, magnetPurshased;
    public Text magnetPriceText, magnetNumberText;
    [HideInInspector] public bool MagnetClick = false;
    private float magnettimer;


    [Header("• 4WD System")]
    public Text[] total_4WDText;
    public int _4WdPrice;
    public Button _4WDButton;
    public GameObject _4WDBuyButton;
    private int _4WDNumber = 1, _4WDPurshased;
    public Text _4WDPriceText, _4WDNumberText;
    [HideInInspector] public bool _4WDClick = false;
    private float _4WDtimer;


    [Header("• Battle Counter")]
    [HideInInspector]
    public float startTime1, startTime2, startTime3, startTime4;
    [HideInInspector]
    public float t1, t2, t3, t4;
    [HideInInspector]
    public string minutes1, minutes2, minutes3, minutes4;
    [HideInInspector]
    public string seconds1, seconds2, seconds3, seconds4;


    [Header("• Game Start Timer")]
    public GameObject gameTimerOne;
    public GameObject gameTimerTwo, gameTimerThree, gameTimerGo;
    [HideInInspector] public GameObject ses3, ses2, ses1, sesgo;


    [Header("• Game Panel")]
    public GameObject crash;
    public int param = 0;
    public GameObject gamePlayPanel;


    [Header("• Gas Tank Over")]
    public bool GasTankOver = false;
    public GameObject GasTankPanel, gasTankWarning;
    public int whatGasTankOver = 0;


    [Header("• Warning Panel")]
    public GameObject warningPanel;


    [Header("• Cars")]
    public GameObject Araba;
    public int varsayilan_arac = 0;
    public GameObject araclar_yapay;

    [Header("• Coin")]
    public GameObject coinSpawnObject;
    public Text wonCoinText;
    public int distancecoinss;
    public Text _totalCoinText;

    [Header("• Sound")]
    public AudioSource NitroSound;
    public AudioSource MagnetSound;
    public AudioSource _4WDSound;
    public AudioSource _clickSound;
    public AudioSource _buySound;
    public AudioSource _transitionSound;


    [Header("• Other")]
    public GameObject flipText;
    public GameObject _backFlipText, _frontFlipText;
    int ayar;
    private float treeTimer;
    [HideInInspector] public int TreeIndex;
    public GameObject NitroVolume;
    public static bool tunePanelOpen;
    public PhysicMaterial darbe_deneme;
    [HideInInspector] public int Scene_val;
    private GameObject BackroundGameSounds;
    private int gameSoundIndex;


    Coroutine dur;
    [HideInInspector] public static bool deadZoom = false;
    [HideInInspector] public bool isgas = false;
    public GameObject player;
    public int mesafe;
    [HideInInspector] public int puan, award, earnedTotalCoin;
    public static int carDistanceCounter = 0;
    public Vector3 ilk_pos;
    int Oyun_modu = 0;
    public GameObject yaris_mesafeleri, yaris_mesafeleri_bat;

    public bool basla = false;
    int yol_metre;
    [HideInInspector] public GameObject Chassis;
    public bool olme, finished;
    public bool kontrol = true;
    bool once = true;
    GameObject gecici;
    public Text sonuc_battle, battle_siralama, battle_siralama_isim;
    public GameObject gecis_oldun, res1_vs, res2_vs, res1_bat, res2_bat, res3_bat, res4_bat;
    public GameObject gas_ust, fren_ust, fren_turuncu;
    public GameObject loading_screen;
    public GameObject pause_panel, arac_karakteri;
    public bool benzindip = false;
    public bool noThanks = false;
    bool takildi = false;
    float temp_kuvvet;
    public GameObject toplanan_particle;
    public GameObject playButtonPanel;
    public string m_rewardType;


    public void OnRewardGiven(string arg0)
    {
        if (arg0 == "Get2X")
        {
            Get2xButton();
            return;
        }

        if (arg0 == "RandomReward")
        {
            int a;
            a = Random.Range(0, 3);
            if (a==0)
            {
                PlayerPrefs.SetInt("TotalNitro", PlayerPrefs.GetInt("TotalNitro") + 1);
                 m_NitroReward.SetActive(true);
            }
            else if (a==1)
            {
                PlayerPrefs.SetInt("TotalMagnet", PlayerPrefs.GetInt("TotalMagnet") + 1);
                m_MagnetReward.SetActive(true);
            }
            else if (a==2)
            {
                PlayerPrefs.SetInt("Total4WD", PlayerPrefs.GetInt("Total4WD") + 1);
                m_4WDReward.SetActive(true);
            }
        }
        else
        {
            StartCoroutine(RewardedCounter(arg0));
        }
    }

    IEnumerator RewardedCounter(string arg0)
    {
        yield return new WaitForSeconds(.2f);
            olme = false;
            kontrol = true;
            benzindip = false;
            deadZoom = false;
            flip = false;
            SingleModeGameOverPanel.SetActive(false);
            gamePlayPanel.SetActive(true);
            truckk_yeni.finishFren = false;
            player.GetComponent<truckk_yeni>().gas = false;
            player.GetComponent<truckk_yeni>().fren = false;
            player.GetComponent<truckk_yeni>().Benzin = 100;
            darbe_deneme.dynamicFriction = 0;
            player.GetComponent<Rigidbody>().drag = 0;
            player.GetComponent<Rigidbody>().mass = 50;
            player.GetComponent<truckk_yeni>().MovementSound.gameObject.GetComponent<AudioSource>().Play();
            player.GetComponent<truckk_yeni>().brakeSound.GetComponent<AudioSource>().Play();
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.3f,
                player.transform.position.z);
            player.transform.localEulerAngles = new Vector3(0, 0, 0);
            player.transform.GetChild(0).eulerAngles = new Vector3(0, 0, 0);
            for (var i = 0; i < player.GetComponent<truckk_yeni>().Wheels.Length; i++)
            {
                player.GetComponent<truckk_yeni>().Wheels[i].GetComponent<Rigidbody>().angularVelocity =
                    new Vector3(0, 0, 0);
                player.GetComponent<truckk_yeni>().Wheels[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                player.GetComponent<truckk_yeni>().Wheels[i].localRotation = temp_rot_wheel[i];
                player.GetComponent<truckk_yeni>().Wheels[i].localPosition = temp_pos_wheel[i];
            }

            arac_karakteri.GetComponent<adam_oldu>().adam_son.gameObject.SetActive(true);
            arac_karakteri.GetComponent<adam_oldu>().adam2.transform.position =
                arac_karakteri.GetComponent<adam_oldu>().adam2.transform.position;
            arac_karakteri.GetComponent<adam_oldu>().adam2.gameObject.SetActive(false);
            BackroundGameSounds.transform.GetChild(gameSoundIndex).GetComponent<AudioSource>().Play();
            if (arg0 == "Nitro")
            {
                PlayerPrefs.SetInt("TotalNitro", PlayerPrefs.GetInt("TotalNitro") + 1);
            }
            else if (arg0 == "Magnet")
            {
                PlayerPrefs.SetInt("TotalMagnet", PlayerPrefs.GetInt("TotalMagnet") + 1);
            }
            else if (arg0 == "_4WD")
            {
                PlayerPrefs.SetInt("Total4WD", PlayerPrefs.GetInt("Total4WD") + 1);
            }
            else if (arg0 == "Benzin")
            {
                GasTankPanel.SetActive(false);
                benzin.gameOver = false;
                whatGasTankOver += 1;
            }
    }

    public void RandomRewardStart()
    {
        Invoke("Startsoundkapat", 1f);
        player.GetComponent<truckk_yeni>().StartSound.GetComponent<AudioSource>().Play();
        basla = true;
        playButtonPanel.SetActive(false);
        flip = false;
    }

    private void OnFailedAd()
    {
        Instantiate(m_RewardFailed, GameObject.Find("Canvas").GetComponent<RectTransform>(),
            worldPositionStays: false);
    }

    void Awake()
    {
      
        ses1 = GameObject.Find("StartSoundOne");
        ses2 = GameObject.Find("StartSoundTwo");
        ses3 = GameObject.Find("StartSoundThree");
        sesgo = GameObject.Find("StartSoundGo");
        spawn_single = GameObject.Find("SpawnDot1");
        spawn_vs_1 = GameObject.Find("SpawnDot1");
        spawn_vs_2 = GameObject.Find("SpawnDot3");
        if (araclar_yapay == null)
        {
            araclar_yapay = GameObject.FindGameObjectWithTag("araclar_yapay");
        }
        if (Araba == null)
        {
            Araba = GameObject.FindGameObjectWithTag("Araba");
        }
        if (NitroVolume == null)
        {
            NitroVolume = GameObject.Find("NitroVolume");
            NitroVolume.SetActive(false);
        }
        if (BackroundGameSounds == null)
        {
            BackroundGameSounds = GameObject.FindGameObjectWithTag("BackroundGameSounds");
        }
       
        TreeIndex = Random.Range(0, 4);
        gameSoundIndex = 0;
        mesafe = 0;
        toplanan_particle.transform.GetChild(1).GetComponent<Text>().text = "0";
        Scene_val = SceneManager.GetActiveScene().buildIndex;
        Application.targetFrameRate = 120;
        kontrol = true;
        olme = false;
        Time.timeScale = 1;
        Oyun_modu = PlayerPrefs.GetInt("Oyun_modu");
        playButtonPanel.SetActive(true);

        varsayilan_arac = PlayerPrefs.GetInt("Varsayilan");
        player = Araba.transform.GetChild(varsayilan_arac).gameObject;
        for (int i = 0; i < player.transform.parent.childCount; i++)
        {
            if (PlayerPrefs.GetInt("Varsayilan") != i)
                player.transform.parent.GetChild(i).gameObject.SetActive(false);
        }
        player.SetActive(true);
        if (PlayerPrefs.GetInt("BonusMap") == 0)
        {
            gameObject.transform.GetChild(3).GetComponent<CanvasGroup>().alpha = 1;
            playButtonPanel.SetActive(false);
            Invoke("Startsoundkapat", 0.5f);
            //  player.GetComponent<truckk_yeni>().StartSound.GetComponent<AudioSource>().Play();
            Invoke("BonusCounterStart", 7f);
        }

        if (PlayerPrefs.GetInt("Oyun_modu") == 0)
        { 
            //single mod
            player.transform.position = spawn_single.transform.position;
            for (int i = 0; i < araclar_yapay.transform.childCount; i++)
            {
                araclar_yapay.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else if (PlayerPrefs.GetInt("Oyun_modu") == 1)
        { 
            //vs mod
            int sayi = 0;
            yaris_mesafeleri.SetActive(true);
            player.transform.position = spawn_vs_1.transform.position;
            switch (varsayilan_arac)
            {
                case 0: sayi = Random.Range(0, 4); break;
                case 1: sayi = Random.Range(0, 4); break;
                case 2: sayi = Random.Range(0, 5); break;
                case 3: sayi = Random.Range(1, 6); break;
                case 4: sayi = Random.Range(2, 7); break;
                case 5: sayi = Random.Range(3, 8); break;
                case 6: sayi = Random.Range(4, 9); break;
                case 7: sayi = Random.Range(5, 10); break;
                case 8: sayi = Random.Range(6, 10); break;
                case 9: sayi = Random.Range(7, 11); break;
                case 10: sayi = Random.Range(8, 11); break;
                default:
                    break;
            }
            for (int i = 0; i < araclar_yapay.transform.childCount; i++)
            {
                if (sayi != i)
                    araclar_yapay.transform.GetChild(i).gameObject.SetActive(false);
            }
            _2PModeBotCar = araclar_yapay.transform.GetChild(sayi).gameObject;
            _2PModeBotCar.SetActive(true);
            _2PModeBotCar.transform.position = spawn_vs_2.transform.position;
            if (_2PModeBotCar)
            {
                araclar_yapay.transform.GetChild(sayi).GetComponent<truckk_yeni>().MaxAngularVel = Random.Range(player.GetComponent<truckk_yeni>().MaxAngularVel - 3, player.GetComponent<truckk_yeni>().MaxAngularVel + 2);
                araclar_yapay.transform.GetChild(sayi).GetComponent<truckk_yeni>().kuvvet = Random.Range(player.GetComponent<truckk_yeni>().kuvvet - 6.5f, player.GetComponent<truckk_yeni>().kuvvet + 8);
                araclar_yapay.transform.GetChild(sayi).GetComponent<truckk_yeni>().dynamicFrictionValue = Random.Range(player.GetComponent<truckk_yeni>().dynamicFrictionValue + 0.3f, player.GetComponent<truckk_yeni>().dynamicFrictionValue + 0.12f);
                araclar_yapay.transform.GetChild(sayi).GetComponent<truckk_yeni>().carID = sayi;
            }
        }
        else if (PlayerPrefs.GetInt("Oyun_modu") == 2)

        { //battle mod
            int sayi = 0;
            yaris_mesafeleri_bat.SetActive(true);
            player.transform.position = spawn_battle[0].transform.position;

            for (int i = 0; i < araclar_yapay.transform.childCount; i++)
            {
                if (sayi != i)
                {
                    araclar_yapay.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
            switch (varsayilan_arac)
            {
                case 0:
                    sayi = Random.Range(0, 4);
                    break;
                case 1:
                    sayi = Random.Range(0, 4);
                    break;
                case 2:
                    sayi = Random.Range(0, 5);
                    break;
                case 3:
                    sayi = Random.Range(1, 6);
                    break;
                case 4:
                    sayi = Random.Range(2, 7);
                    break;
                case 5:
                    sayi = Random.Range(3, 8);
                    break;
                case 6:
                    sayi = Random.Range(4, 9);
                    break;
                case 7:
                    sayi = Random.Range(5, 10);
                    break;
                case 8:
                    sayi = Random.Range(6, 10);
                    break;
                case 9:
                    sayi = Random.Range(7, 11);
                    break;
                case 10:
                    sayi = Random.Range(7, 11);
                    break;
                default:
                    break;
            }
            _2PModeBotCar = araclar_yapay.transform.GetChild(sayi).gameObject;
            _2PModeBotCar.SetActive(true);
            _2PModeBotCar.transform.GetComponent<truckk_yeni>().MaxAngularVel = Random.Range(player.GetComponent<truckk_yeni>().MaxAngularVel - 3.5f, player.GetComponent<truckk_yeni>().MaxAngularVel + 4.5f);
            _2PModeBotCar.transform.GetComponent<truckk_yeni>().kuvvet = Random.Range(player.GetComponent<truckk_yeni>().kuvvet - 6f, player.GetComponent<truckk_yeni>().kuvvet + 7.5f);
            _2PModeBotCar.transform.GetComponent<truckk_yeni>().dynamicFrictionValue = Random.Range(player.GetComponent<truckk_yeni>().dynamicFrictionValue + 0.3f, player.GetComponent<truckk_yeni>().dynamicFrictionValue + 0.12f);
            _2PModeBotCar.transform.position = spawn_battle[1].transform.position;
            _4PModeCars[0] = _2PModeBotCar;
            for (int i = 0; i < 2; i++)
            {
                while (araclar_yapay.transform.GetChild(sayi).gameObject.activeSelf)
                {
                    switch (varsayilan_arac)
                    {
                        case 0:
                            sayi = Random.Range(0, 4);
                            break;
                        case 1:
                            sayi = Random.Range(0, 4);
                            break;
                        case 2:
                            sayi = Random.Range(0, 5);
                            break;
                        case 3:
                            sayi = Random.Range(1, 6);
                            break;
                        case 4:
                            sayi = Random.Range(2, 7);
                            break;
                        case 5:
                            sayi = Random.Range(3, 8);
                            break;
                        case 6:
                            sayi = Random.Range(4, 9);
                            break;
                        case 7:
                            sayi = Random.Range(5, 10);
                            break;
                        case 8:
                            sayi = Random.Range(6, 10);
                            break;
                        case 9:
                            sayi = Random.Range(7, 11);
                            break;
                        case 10:

                            sayi = Random.Range(7, 11);
                            break;
                        default:
                            break;
                    }
                    _2PModeBotCar = araclar_yapay.transform.GetChild(sayi).gameObject;
                }
                _2PModeBotCar.SetActive(true);
                _2PModeBotCar.transform.position = spawn_battle[i + 2].transform.position;
                _4PModeCars[i + 1] = _2PModeBotCar;
                araclar_yapay.transform.GetChild(sayi).GetComponent<truckk_yeni>().MaxAngularVel = Random.Range(player.GetComponent<truckk_yeni>().MaxAngularVel - 3.5f, player.GetComponent<truckk_yeni>().MaxAngularVel + 4.5f);
                araclar_yapay.transform.GetChild(sayi).GetComponent<truckk_yeni>().kuvvet = Random.Range(player.GetComponent<truckk_yeni>().kuvvet - 6f, player.GetComponent<truckk_yeni>().kuvvet + 7.5f);
                araclar_yapay.transform.GetChild(sayi).GetComponent<truckk_yeni>().dynamicFrictionValue = Random.Range(player.GetComponent<truckk_yeni>().dynamicFrictionValue + 0.3f, player.GetComponent<truckk_yeni>().dynamicFrictionValue + 0.12f);
                araclar_yapay.transform.GetChild(sayi).GetComponent<truckk_yeni>().carID = sayi;

            }

            _4PModeCars[3] = player;
        }
        else if (PlayerPrefs.GetInt("Oyun_modu") == 6)
        {
            tur = PlayerPrefs.GetInt("Tur");
            mission_deger = PlayerPrefs.GetInt("Mission");
            oyun_zaman = PlayerPrefs.GetInt("oyun_zaman");
            yol_metre = PlayerPrefs.GetInt("yol_metre");
            point = PlayerPrefs.GetInt("coins");
            particle = PlayerPrefs.GetInt("particle");
            if (tur == 1 || tur == 3 || tur == 5)


                if (tur == 1)
                {
                    toplanan_particle.gameObject.SetActive(true);
                    toplanan_particle.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                    missionTimerPanel.SetActive(true);
                    missionPropertyText.text = "#" + (mission_deger + 1) + "-COLLECT " + point.ToString() + " COINS IN " + oyun_zaman.ToString() + " SECONDS !";
                    player.transform.position = spawn_single.transform.position;
                    for (int i = 0; i < araclar_yapay.transform.childCount; i++)
                    {
                        araclar_yapay.transform.GetChild(i).gameObject.SetActive(false);
                    }

                }
            if (tur == 2)
            {
                yaris_mesafeleri.SetActive(true);
                missionPropertyText.text = "#" + (mission_deger + 1) + "-BE THE FIRST TO FINISH THE RACE !";
                player.transform.position = spawn_vs_1.transform.position;
                int sayi = PlayerPrefs.GetInt("Yapay_select");
                for (int i = 0; i < araclar_yapay.transform.childCount; i++)
                {
                    if (sayi != i)
                        araclar_yapay.transform.GetChild(i).gameObject.SetActive(false);

                }
                _2PModeBotCar = araclar_yapay.transform.GetChild(sayi).gameObject;
                _2PModeBotCar.SetActive(true);
                _2PModeBotCar.transform.GetComponent<truckk_yeni>().MaxAngularVel = Random.Range(player.GetComponent<truckk_yeni>().MaxAngularVel - 3.5f, player.GetComponent<truckk_yeni>().MaxAngularVel + 4.5f);
                _2PModeBotCar.transform.GetComponent<truckk_yeni>().kuvvet = Random.Range(player.GetComponent<truckk_yeni>().kuvvet - 6f, player.GetComponent<truckk_yeni>().kuvvet + 7.5f);
                _2PModeBotCar.transform.GetComponent<truckk_yeni>().dynamicFrictionValue = Random.Range(player.GetComponent<truckk_yeni>().dynamicFrictionValue - 0.1f, player.GetComponent<truckk_yeni>().dynamicFrictionValue + 0.12f);
                _2PModeBotCar.transform.position = spawn_vs_2.transform.position;
            }
            if (tur == 3)
            {
                missionTimerPanel.SetActive(true);
                missionPropertyText.text = "#" + (mission_deger + 1) + "-DRIVE " + yol_metre.ToString() + " METERS IN " + oyun_zaman.ToString() + " SECONDS !";
                player.transform.position = spawn_single.transform.position;
                for (int i = 0; i < araclar_yapay.transform.childCount; i++)
                {
                    araclar_yapay.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
            if (tur == 4)
            {
                player.transform.position = spawn_single.transform.position;
                missionPropertyText.text = "#" + (mission_deger + 1) + "-DRIVE " + yol_metre.ToString() + " METER WITH FULL TANK FUEL !";
                for (int i = 0; i < araclar_yapay.transform.childCount; i++)
                {
                    araclar_yapay.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
            if (tur == 5)
            {
                toplanan_particle.gameObject.SetActive(true);
                toplanan_particle.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                missionPropertyText.text = "#" + (mission_deger + 1) + "-COLLECT " + particle.ToString() + " GEMS IN " + oyun_zaman.ToString() + " SECONDS !";
                missionTimerPanel.SetActive(true);
                player.transform.position = spawn_single.transform.position;
                for (int i = 0; i < araclar_yapay.transform.childCount; i++)
                {
                    araclar_yapay.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
        Chassis = player.transform.GetChild(0).gameObject;
        arac_karakteri = GameObject.FindGameObjectWithTag("karakter_Arac");

        arac_karakteri.GetComponent<adam_oldu>().adam_son.transform.GetChild(PlayerPrefs.GetInt("Varsayilan_kar")).gameObject.SetActive(true);
        arac_karakteri.GetComponent<adam_oldu>().adam2.transform.GetChild(PlayerPrefs.GetInt("Varsayilan_kar")).gameObject.SetActive(true);
        arac_karakteri.GetComponent<adam_oldu>().adam3.transform.GetChild(PlayerPrefs.GetInt("Varsayilan_kar")).gameObject.SetActive(true);

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        if (PlayerPrefs.GetInt("CurrentUpg1" + PlayerPrefs.GetInt("Varsayilan")) == 1)
        {
            player.GetComponent<truckk_yeni>().MaxAngularVel += 3f;
        }
        if (PlayerPrefs.GetInt("CurrentUpg1" + PlayerPrefs.GetInt("Varsayilan")) == 2)
        {
            player.GetComponent<truckk_yeni>().MaxAngularVel += 4.5f;
        }
        if (PlayerPrefs.GetInt("CurrentUpg1" + PlayerPrefs.GetInt("Varsayilan")) == 3)
        {
            player.GetComponent<truckk_yeni>().MaxAngularVel += 6f;
        }
        if (PlayerPrefs.GetInt("CurrentUpg1" + PlayerPrefs.GetInt("Varsayilan")) == 4)
        {
            player.GetComponent<truckk_yeni>().MaxAngularVel += 7.5f;
        }
        if (PlayerPrefs.GetInt("CurrentUpg1" + PlayerPrefs.GetInt("Varsayilan")) == 5)
        {
            player.GetComponent<truckk_yeni>().MaxAngularVel += 9f;
        }
        if (PlayerPrefs.GetInt("CurrentUpg1" + PlayerPrefs.GetInt("Varsayilan")) == 6)
        {
            player.GetComponent<truckk_yeni>().MaxAngularVel += 10.5f;
        }
        if (PlayerPrefs.GetInt("CurrentUpg1" + PlayerPrefs.GetInt("Varsayilan")) == 7)
        {
            player.GetComponent<truckk_yeni>().MaxAngularVel += 12f;
        }
        if (PlayerPrefs.GetInt("CurrentUpg1" + PlayerPrefs.GetInt("Varsayilan")) == 8)
        {
            player.GetComponent<truckk_yeni>().MaxAngularVel += 13.5f;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        for (int i = 0; i < player.GetComponent<truckk_yeni>().suspansion.Length; i++)
        {
            if (PlayerPrefs.GetInt("CurrentUpg2" + PlayerPrefs.GetInt("Varsayilan")) == 1)
            {
                //  player.GetComponent<truckk_yeni>().kuvvet += 10;
                JointDrive drive = new JointDrive();
                drive.positionDamper = player.GetComponent<truckk_yeni>().suspansion[i].yDrive.positionDamper + 2000;
                drive.positionSpring = player.GetComponent<truckk_yeni>().suspansion[i].yDrive.positionSpring;

                drive.maximumForce = player.GetComponent<truckk_yeni>().suspansion[i].yDrive.maximumForce;
                player.GetComponent<truckk_yeni>().suspansion[i].yDrive = drive;
            }
            if (PlayerPrefs.GetInt("CurrentUpg2" + PlayerPrefs.GetInt("Varsayilan")) == 2)
            {
                //  player.GetComponent<truckk_yeni>().kuvvet += 20;
                JointDrive drive = new JointDrive();
                drive.positionDamper = player.GetComponent<truckk_yeni>().suspansion[i].yDrive.positionDamper + 3000;
                drive.positionSpring = player.GetComponent<truckk_yeni>().suspansion[i].yDrive.positionSpring;
                drive.maximumForce = player.GetComponent<truckk_yeni>().suspansion[i].yDrive.maximumForce;
                player.GetComponent<truckk_yeni>().suspansion[i].yDrive = drive;
            }
            if (PlayerPrefs.GetInt("CurrentUpg2" + PlayerPrefs.GetInt("Varsayilan")) == 3)
            {
                // player.GetComponent<truckk_yeni>().kuvvet += 30;
                JointDrive drive = new JointDrive();
                drive.positionDamper = player.GetComponent<truckk_yeni>().suspansion[i].yDrive.positionDamper + 4000;
                drive.positionSpring = player.GetComponent<truckk_yeni>().suspansion[i].yDrive.positionSpring;
                drive.maximumForce = player.GetComponent<truckk_yeni>().suspansion[i].yDrive.maximumForce;
                player.GetComponent<truckk_yeni>().suspansion[i].yDrive = drive;
            }
            if (PlayerPrefs.GetInt("CurrentUpg2" + PlayerPrefs.GetInt("Varsayilan")) == 4)
            {
                // player.GetComponent<truckk_yeni>().kuvvet += 40;
                JointDrive drive = new JointDrive();
                drive.positionDamper = player.GetComponent<truckk_yeni>().suspansion[i].yDrive.positionDamper + 5000;
                drive.positionSpring = player.GetComponent<truckk_yeni>().suspansion[i].yDrive.positionSpring;
                drive.maximumForce = player.GetComponent<truckk_yeni>().suspansion[i].yDrive.maximumForce;
                player.GetComponent<truckk_yeni>().suspansion[i].yDrive = drive;
            }
            if (PlayerPrefs.GetInt("CurrentUpg2" + PlayerPrefs.GetInt("Varsayilan")) == 5)
            {
                //player.GetComponent<truckk_yeni>().kuvvet += 50;
                JointDrive drive = new JointDrive();
                drive.positionDamper = player.GetComponent<truckk_yeni>().suspansion[i].yDrive.positionDamper + 6000;
                drive.positionSpring = player.GetComponent<truckk_yeni>().suspansion[i].yDrive.positionSpring;
                drive.maximumForce = player.GetComponent<truckk_yeni>().suspansion[i].yDrive.maximumForce;
                player.GetComponent<truckk_yeni>().suspansion[i].yDrive = drive;
            }
            if (PlayerPrefs.GetInt("CurrentUpg2" + PlayerPrefs.GetInt("Varsayilan")) == 6)
            {
                //  player.GetComponent<truckk_yeni>().kuvvet += 60;
                JointDrive drive = new JointDrive();
                drive.positionDamper = player.GetComponent<truckk_yeni>().suspansion[i].yDrive.positionDamper + 7000;
                drive.positionSpring = player.GetComponent<truckk_yeni>().suspansion[i].yDrive.positionSpring;
                drive.maximumForce = player.GetComponent<truckk_yeni>().suspansion[i].yDrive.maximumForce;
                player.GetComponent<truckk_yeni>().suspansion[i].yDrive = drive;
            }
            if (PlayerPrefs.GetInt("CurrentUpg2" + PlayerPrefs.GetInt("Varsayilan")) == 7)
            {
                // player.GetComponent<truckk_yeni>().kuvvet += 70;
                JointDrive drive = new JointDrive();
                drive.positionDamper = player.GetComponent<truckk_yeni>().suspansion[i].yDrive.positionDamper + 8000;
                drive.positionSpring = player.GetComponent<truckk_yeni>().suspansion[i].yDrive.positionSpring;
                drive.maximumForce = player.GetComponent<truckk_yeni>().suspansion[i].yDrive.maximumForce;
                player.GetComponent<truckk_yeni>().suspansion[i].yDrive = drive;
            }
            if (PlayerPrefs.GetInt("CurrentUpg2" + PlayerPrefs.GetInt("Varsayilan")) == 8)
            {
                // player.GetComponent<truckk_yeni>().kuvvet += 80;
                JointDrive drive = new JointDrive();
                drive.positionDamper = player.GetComponent<truckk_yeni>().suspansion[i].yDrive.positionDamper + 9000;
                drive.positionSpring = player.GetComponent<truckk_yeni>().suspansion[i].yDrive.positionSpring;
                drive.maximumForce = player.GetComponent<truckk_yeni>().suspansion[i].yDrive.maximumForce;
                player.GetComponent<truckk_yeni>().suspansion[i].yDrive = drive;
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        if (PlayerPrefs.GetInt("CurrentUpg3" + PlayerPrefs.GetInt("Varsayilan")) == 1)
        {
            player.GetComponent<truckk_yeni>().dynamicFrictionValue += 0.1f;
        }
        if (PlayerPrefs.GetInt("CurrentUpg3" + PlayerPrefs.GetInt("Varsayilan")) == 2)
        {
            player.GetComponent<truckk_yeni>().dynamicFrictionValue += 0.15f;
        }
        if (PlayerPrefs.GetInt("CurrentUpg3" + PlayerPrefs.GetInt("Varsayilan")) == 3)
        {
            player.GetComponent<truckk_yeni>().dynamicFrictionValue += 0.2f;
        }
        if (PlayerPrefs.GetInt("CurrentUpg3" + PlayerPrefs.GetInt("Varsayilan")) == 4)
        {
            player.GetComponent<truckk_yeni>().dynamicFrictionValue += 0.5f;
        }
        if (PlayerPrefs.GetInt("CurrentUpg3" + PlayerPrefs.GetInt("Varsayilan")) == 5)
        {
            player.GetComponent<truckk_yeni>().dynamicFrictionValue += 0.8f;
        }
        if (PlayerPrefs.GetInt("CurrentUpg3" + PlayerPrefs.GetInt("Varsayilan")) == 6)
        {
            player.GetComponent<truckk_yeni>().dynamicFrictionValue += 1f;
        }
        if (PlayerPrefs.GetInt("CurrentUpg3" + PlayerPrefs.GetInt("Varsayilan")) == 7)
        {
            player.GetComponent<truckk_yeni>().dynamicFrictionValue += 1.2f;
        }
        if (PlayerPrefs.GetInt("CurrentUpg3" + PlayerPrefs.GetInt("Varsayilan")) == 8)
        {
            player.GetComponent<truckk_yeni>().dynamicFrictionValue += 1.5f;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        if (PlayerPrefs.GetInt("CurrentUpg4" + PlayerPrefs.GetInt("Varsayilan")) == 1)
        {
            player.GetComponent<truckk_yeni>().benzin_hizi -= 0.2f;
        }
        if (PlayerPrefs.GetInt("CurrentUpg4" + PlayerPrefs.GetInt("Varsayilan")) == 2)
        {
            player.GetComponent<truckk_yeni>().benzin_hizi -= 0.4f;
        }
        if (PlayerPrefs.GetInt("CurrentUpg4" + PlayerPrefs.GetInt("Varsayilan")) == 3)
        {
            player.GetComponent<truckk_yeni>().benzin_hizi -= 0.6f;
        }
        if (PlayerPrefs.GetInt("CurrentUpg4" + PlayerPrefs.GetInt("Varsayilan")) == 4)
        {
            player.GetComponent<truckk_yeni>().benzin_hizi -= 0.8f;
        }
        if (PlayerPrefs.GetInt("CurrentUpg4" + PlayerPrefs.GetInt("Varsayilan")) == 5)
        {
            player.GetComponent<truckk_yeni>().benzin_hizi -= 0.1f;
        }
        if (PlayerPrefs.GetInt("CurrentUpg4" + PlayerPrefs.GetInt("Varsayilan")) == 6)
        {
            player.GetComponent<truckk_yeni>().benzin_hizi -= 1.2f;
        }
        if (PlayerPrefs.GetInt("CurrentUpg4" + PlayerPrefs.GetInt("Varsayilan")) == 7)
        {
            player.GetComponent<truckk_yeni>().benzin_hizi -= 1.4f;
        }
        if (PlayerPrefs.GetInt("CurrentUpg4" + PlayerPrefs.GetInt("Varsayilan")) == 8)
        {
            player.GetComponent<truckk_yeni>().benzin_hizi -= 1.6f;
        }


        gas_ust.SetActive(false);
        fren_ust.SetActive(false);
        isgas = false;



        if (Oyun_modu == 1)
        {
            for (int i = 0; i < _2PModeBotCar.GetComponent<truckk_yeni>().Wheels.Length; i++)
            {
                _2PModeBotCar.GetComponent<truckk_yeni>().Wheels[i].GetComponent<AudioSource>().enabled = false;
            }

        }
        if (Oyun_modu == 2)
        {
            for (int x = 0; x < _4PModeCars.Length; x++)
            {
                for (int i = 0; i < _4PModeCars[x].GetComponent<truckk_yeni>().Wheels.Length; i++)
                {
                    _4PModeCars[x].GetComponent<truckk_yeni>().Wheels[i].GetComponent<AudioSource>().enabled = false;
                }

            }
        }
        Invoke("baslangic", 0.3f);
        gamePlayPanel.SetActive(false);
    }

    public Vector3[] temp_pos_sus, temp_pos_wheel;
    public Quaternion[] temp_rot_sus, temp_rot_wheel;
    public Vector3 sase_sus_pos, sase_wheel_pos;
    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep; // Ekranın kararmasını yada kapanmasını engeller
        SoundManager();
        flip = false;
        ayar = 0;
        tunePanelOpen = true;
        darbe_deneme.dynamicFriction = 0;
        frontFlipCounter = 0;
        backFlipCounter = 0;
        distancecoinss = 0;
        whatGasTankOver = 0;
        GasTankOver = false;
        carDistanceCounter = 0;
        seaDistance = 1;
        missionFinish = false;

        for (int i = 0; i < player.GetComponent<truckk_yeni>().Wheels.Length; i++)
        {
            player.GetComponent<truckk_yeni>().Wheels[i].GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            player.GetComponent<truckk_yeni>().Wheels[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            player.GetComponent<truckk_yeni>().Wheels[i].localRotation = temp_rot_wheel[i];
            player.GetComponent<truckk_yeni>().Wheels[i].localPosition = temp_pos_wheel[i];
        }
        if(Scene_val==1)
        {
            InvokeRepeating("TreeCounter", 1f, 60f);
        }

    }


    void TreeCounter()
    {
            treeTimer += 1 * Time.deltaTime;
            if (treeTimer >= 60)
            {
                treeTimer = 0;
                TreeIndex = Random.Range(0, 4);
            }
    }
    public void SkipButton()
    {
        loading_screen.SetActive(true);
        Time.timeScale = 1;
        gameObject.transform.GetChild(3).GetComponent<CanvasGroup>().alpha += 0.7f * Time.deltaTime;
        StartCoroutine(TutorialMainMenu());
    }
    void BonusCounterStart()
    {

        basla = true;
    }
    IEnumerator TutorialMainMenu()
    {
        yield return new WaitForSecondsRealtime(2);
        TouchToContunieButton(1);
    }
      

    void baslangic()
    {
        if (player)
        {

            if (Oyun_modu == 1)
            {
                for (int i = 0; i < _2PModeBotCar.GetComponent<truckk_yeni>().Wheels.Length; i++)
                {
                    _2PModeBotCar.GetComponent<truckk_yeni>().Wheels[i].GetComponent<AudioSource>().enabled = true;
                }

            }
            if (Oyun_modu == 2)
            {
                for (int x = 0; x < _4PModeCars.Length; x++)
                {
                    for (int i = 0; i < _4PModeCars[x].GetComponent<truckk_yeni>().Wheels.Length; i++)
                    {
                        _4PModeCars[x].GetComponent<truckk_yeni>().Wheels[i].GetComponent<AudioSource>().enabled = true;
                    }

                }
            }
        }
    }
    public void SoundManager()
    {
        if (PlayerPrefs.GetString("GameSoundStatus") == "True")
        {
            player.GetComponent<truckk_yeni>().MovementSound.gameObject.GetComponent<AudioSource>().enabled = true;
            player.GetComponent<truckk_yeni>().StartSound.GetComponent<AudioSource>().enabled = true;
            player.GetComponent<truckk_yeni>().brakeSound.GetComponent<AudioSource>().enabled = true;
            _buySound.enabled = true;
            ses1.GetComponent<AudioSource>().enabled = true;
            ses2.GetComponent<AudioSource>().enabled = true;
            ses3.GetComponent<AudioSource>().enabled = true;
            sesgo.GetComponent<AudioSource>().enabled = true;
            player.GetComponent<truckk_yeni>().turboBlowOffSound.GetComponent<AudioSource>().enabled = true;
            player.GetComponent<truckk_yeni>().coin_ses.GetComponent<AudioSource>().enabled = true;
            gasTankWarning.GetComponent<AudioSource>().enabled = true;

        }
        if (PlayerPrefs.GetString("GameSoundStatus") == "False")
        {
            player.GetComponent<truckk_yeni>().MovementSound.gameObject.GetComponent<AudioSource>().enabled = false;
            player.GetComponent<truckk_yeni>().StartSound.GetComponent<AudioSource>().enabled = false;
            player.GetComponent<truckk_yeni>().brakeSound.GetComponent<AudioSource>().enabled = false;
            _buySound.enabled = false;
            ses1.GetComponent<AudioSource>().enabled = false;
            ses2.GetComponent<AudioSource>().enabled = false;
            ses3.GetComponent<AudioSource>().enabled = false;
            sesgo.GetComponent<AudioSource>().enabled = false;
            player.GetComponent<truckk_yeni>().turboBlowOffSound.GetComponent<AudioSource>().enabled = false;
            player.GetComponent<truckk_yeni>().coin_ses.GetComponent<AudioSource>().enabled = false;
            gasTankWarning.GetComponent<AudioSource>().enabled = false;
        }
        for (int i = 0; i < BackroundGameSounds.transform.childCount; i++)
        {
            if (PlayerPrefs.GetString("BackroundSoundStatus") == "True")
            {
                BackroundGameSounds.transform.GetChild(i).GetComponent<AudioSource>().enabled = true;
            }
            if (PlayerPrefs.GetString("BackroundSoundStatus") == "False")
            {
                BackroundGameSounds.transform.GetChild(i).GetComponent<AudioSource>().enabled = false;
            }
        }

    }


    void bas2x()
    {
        gameTimerThree.SetActive(false);
        gameTimerTwo.SetActive(true);
        ses2.GetComponent<AudioSource>().Play();
        gameTimerTwo.GetComponent<Animation>().Play();

        Invoke("bas1x", 0.7f);
    }
    void bas1x()
    {
        gameTimerTwo.SetActive(false);
        gameTimerOne.SetActive(true);
        ses1.GetComponent<AudioSource>().Play();
        gameTimerOne.GetComponent<Animation>().Play();

        Invoke("basgo", 0.7f);
    }

  
    void Startsoundkapat()
    {
        player.GetComponent<truckk_yeni>().MovementSound.GetComponent<AudioSource>().Play();

    }
    public bool botcargo = false;
    public void PlayToGamebutton(string _whatbutton)
    {
        if (_whatbutton=="RewardedAdButton")
        {
            RevivalButton("RandomReward");
            return;
        }
        
        Invoke("Startsoundkapat", 1f);
        player.GetComponent<truckk_yeni>().StartSound.GetComponent<AudioSource>().Play();
        basla = true;
        playButtonPanel.SetActive(false);
        flip = false;
    }
    void basgo()
    {

        gamePlayPanel.SetActive(true);

        sesgo.GetComponent<AudioSource>().Play();
        gameTimerGo.GetComponent<Animation>().Play();
        gameTimerOne.SetActive(false);
        gameTimerGo.SetActive(true);

        Invoke("baskapat", 1);

        temp_kuvvet = player.GetComponent<truckk_yeni>().kuvvet;

        GetComponent<Canvas>().enabled = true;
        if (PlayerPrefs.GetInt("BonusMap") != 0)
        {
            gas_ust.SetActive(true);
            fren_ust.SetActive(true);
        }

        botcargo = true;
        isgas = true;

    }

    void baskapat()
    {
        player.GetComponent<truckk_yeni>().kuvvet = temp_kuvvet;
        if (!gassdown)
            gameTimerGo.SetActive(false);
    }
    IEnumerator Crash_kapat(int i)
    {
        // if (GoogleAdMobController.m_instance)
        // {
        //     GoogleAdMobController.m_instance.RequestAndLoadInterstitialAd();
        //     GoogleAdMobController.m_instance.RequestAndLoadRewardedAd();
        // }
        yield return new WaitForSecondsRealtime(i);
        BackroundGameSounds.transform.GetChild(gameSoundIndex).GetComponent<AudioSource>().Stop();
        
        crash.SetActive(false);
        if (PlayerPrefs.GetInt("BonusMap") == 1 && !GasTankPanel.activeSelf )
        {
            SingleModeGameOverPanel.SetActive(true);
            
        }
        if (PlayerPrefs.GetInt("BonusMap") == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    IEnumerator takildi_fonk2()
    {
        yield return new WaitForSeconds(5);
        olme = true;
        kontrol = true;
    }

    public void GasTankOverPanelNoThanksButton()
    {
        if (whatGasTankOver != 2)
        {
            player.GetComponent<truckk_yeni>().MovementSound.gameObject.GetComponent<AudioSource>().Play();
            player.GetComponent<truckk_yeni>().brakeSound.GetComponent<AudioSource>().Play();
        }
        SingleModeGameOverPanel.transform.GetChild(1).position = new Vector3(800, 0, 0);
        noThanks = true;
        GasTankOver = true;
    }

    int seaDistance = 1;

    public void SoundButton()
    {
        gameSoundIndex++;
        if (gameSoundIndex >= BackroundGameSounds.transform.childCount)
        {
            gameSoundIndex = -1;
        }
    }

    void FixedUpdate()
    {
       
       
        if (!olme && !benzindip)
        {
            if (finished)
            {
                darbe_deneme.dynamicFriction = 30;
                player.GetComponent<Rigidbody>().drag = 3;
                player.GetComponent<Rigidbody>().mass = 10000;
                if (Oyun_modu == 1 && ayar == 0)
                {
                    ayar = 1;
                    if (Scene_val == 1)
                    {
                        earnedTotalCoin += 10000;
                    }
                    if (Scene_val == 2)
                    {
                        earnedTotalCoin += 15000;
                    }
                    if (Scene_val == 3)
                    {
                        earnedTotalCoin += 20000;
                    }
                    if (Scene_val == 4)
                    {
                        earnedTotalCoin += 25000;
                    }
                    if (Scene_val == 5)
                    {
                        earnedTotalCoin += 35000;
                    }

                    PlayerPrefs.SetInt("Money", param);

                }
                else if (Oyun_modu == 2 && ayar == 0)
                {
                    ayar = 1;
                    if (Scene_val == 1)
                    {
                        earnedTotalCoin += 15000;
                    }
                    if (Scene_val == 2)
                    {
                        earnedTotalCoin += 25000;
                    }
                    if (Scene_val == 3)
                    {
                        earnedTotalCoin += 30000;
                    }
                    if (Scene_val == 4)
                    {
                        earnedTotalCoin += 35000;
                    }
                    if (Scene_val == 5)
                    {
                        earnedTotalCoin += 35000;
                    }
                    PlayerPrefs.SetInt("Money", param);
                }
                else if (Oyun_modu == 6 && ayar == 0)
                {
                    ayar = 1;
                    
                    earnedTotalCoin = distancecoinss + puan + award + PlayerPrefs.GetInt("Kazanil_money");
                  //  PlayerPrefs.SetInt("Money", param);
                }
            }
            else
            {
                param = distancecoinss + PlayerPrefs.GetInt("Money") + puan + award;
                earnedTotalCoin = distancecoinss + puan + award;
            }
        }

        wonCoinText.text = param.ToString("N0");

        if (player.transform.rotation.eulerAngles.z > 177 && player.transform.rotation.eulerAngles.z < 182)
        {
            flip = true;
        }
        if (player.transform.rotation.eulerAngles.z > 350 && flip) //backflip is done
        {
            _transitionSound.Play();
            backFlipCounter += 1;
            _backFlipText.transform.DOLocalRotate(new Vector3(0, 0, Random.Range(3, 45)), 0.15f);
            _backFlipText.transform.DOScale(new Vector3(1, 1, 1), 0.15f);
            award += 1000;
            Invoke("fliptextEnabled", 1);
            flip = false;
        }

        if (player.transform.rotation.eulerAngles.z < 60 && flip) //frontflip is done
        {
            _transitionSound.Play();
            frontFlipCounter += 1;
            _frontFlipText.transform.DOLocalRotate(new Vector3(0, 0, Random.Range(-5, -35)), 0.15f);
            _frontFlipText.transform.DOScale(new Vector3(1, 1, 1), 0.15f);
            award += 1000;
            Invoke("fliptextEnabled", 1);
            flip = false;
        }

    }
    void fliptextEnabled()
    {

        _backFlipText.transform.DOLocalRotate(new Vector3(0, 0, 140), 0.15f);
        _backFlipText.transform.DOScale(new Vector3(0, 0, 0), 0.15f);
        _frontFlipText.transform.DOLocalRotate(new Vector3(0, 0, -140), 0.15f);
        _frontFlipText.transform.DOScale(new Vector3(0, 0, 0), 0.15f);

    }

    public void GasUp()
    {

        if (!finished && !olme)
        {
            player.GetComponent<truckk_yeni>().gas = false;
        }

    }
    public void FrenUp()
    {

        if (!finished && !olme)
        {
            player.GetComponent<truckk_yeni>().fren = false;

        }
    }
    bool sola = false, saga = false;
    bool gassdown = false;
    public void GasDown()
    {

        if (!finished && !olme)
        {
            player.GetComponent<truckk_yeni>().gas = true;
            gassdown = true;
        }

    }
    public void FrenDown()
    {
        if (!finished && !olme)
        {
            player.GetComponent<truckk_yeni>().fren = true;
        }

    }

    public void SpecialPowerReduceButton(string whatPower)
    {
        if (nitroNumber > 1 && whatPower == "Nitro")
        {
            nitroNumber = nitroNumber - 1;
        }
        if (magnetNumber > 1 && whatPower == "Magnet")
        {
            magnetNumber = magnetNumber - 1;
        }
        if (_4WDNumber > 1 && whatPower == "_4WD")
        {
            _4WDNumber = _4WDNumber - 1;
        }
    }
    public void SpecialPowerRaiseButton(string whatPower)
    {
        if (nitroNumber < 10 && whatPower == "Nitro")
        {
            if (nitroNumber + PlayerPrefs.GetInt("TotalNitro") < 10)
            {
                nitroNumber = nitroNumber + 1;
            }
        }
        if (magnetNumber < 10 && whatPower == "Magnet")
        {
            if (magnetNumber + PlayerPrefs.GetInt("TotalMagnet") < 10)
            {
                magnetNumber = magnetNumber + 1;
            }
        }
        if (_4WDNumber < 10 && whatPower == "_4WD")
        {
            if (_4WDNumber + PlayerPrefs.GetInt("Total4WD") < 10)
            {

                _4WDNumber = _4WDNumber + 1;
            }
        }
    }

    public GameObject _powerBuyWarningPanel;
    public void SpecialPowerBuyButton(string whatPower)
    {

        if (whatPower == "Nitro")
        {
            if (PlayerPrefs.GetInt("Money") >= nitroPurshased && PlayerPrefs.GetInt("TotalNitro") < 10)
            {
                if (PlayerPrefs.GetString("GameSoundStatus") == "True")
                {
                    _buySound.Play();
                }
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - nitroPurshased);
                PlayerPrefs.SetInt("TotalNitro", PlayerPrefs.GetInt("TotalNitro") + nitroNumber);
                nitroNumber = 1;
            }
            else
            {
                nitroNumber = 1;
                _powerBuyWarningPanel.SetActive(true);
               
            }
        }
        if (whatPower == "Magnet")
        {
            if (PlayerPrefs.GetInt("Money") >= magnetPurshased && PlayerPrefs.GetInt("TotalMagnet") < 10)
            {
                if (PlayerPrefs.GetString("GameSoundStatus") == "True")
                {
                    _buySound.Play();
                }
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - magnetPurshased);
                PlayerPrefs.SetInt("TotalMagnet", PlayerPrefs.GetInt("TotalMagnet") + magnetNumber);
                magnetNumber = 1;
            }
            else
            {
                magnetNumber = 1;
                _powerBuyWarningPanel.SetActive(true);
                
            }
        }
        if (whatPower == "_4WD")
        {
            if (PlayerPrefs.GetInt("Money") >= _4WDPurshased && PlayerPrefs.GetInt("Total4WD") < 10)
            {
                if (PlayerPrefs.GetString("GameSoundStatus") == "True")
                {
                    _buySound.Play();
                }
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - _4WDPurshased);
                PlayerPrefs.SetInt("Total4WD", PlayerPrefs.GetInt("Total4WD") + _4WDNumber);
                _4WDNumber = 1;
            }
            else
            {
                nitroNumber = 1;
                _powerBuyWarningPanel.SetActive(true);
                
            }

        }
    }

    public void click()
    {

        if (PlayerPrefs.GetString("GameSoundStatus") == "True")
        {
            _clickSound.GetComponent<AudioSource>().Play();
        }
    }
  
   
    public void NosButton()
    {
        if (PlayerPrefs.GetInt("TotalNitro") > 0)
        {
            nitroTimer = 1.7f;
            NitroClick = true;
            PlayerPrefs.SetInt("TotalNitro", PlayerPrefs.GetInt("TotalNitro") - 1);
        }
        else
        {
            Debug.Log("eeeeeeee");
        }
    }
    public void MagnetButton()
    {
        if (PlayerPrefs.GetInt("TotalMagnet") > 0)
        {
            magnettimer = 30;
            MagnetClick = true;
            PlayerPrefs.SetInt("TotalMagnet", PlayerPrefs.GetInt("TotalMagnet") - 1);
        }
        else
        {

        }
    }
    public void _4wdButton()
    {
        if (PlayerPrefs.GetInt("Total4WD") > 0)
        {
            _4WDtimer = 15;
            _4WDClick = true;
            PlayerPrefs.SetInt("Total4WD", PlayerPrefs.GetInt("Total4WD") - 1);
        }
        else
        {
        }
    }

    private void Update()
    {
        if (player.GetComponent<truckk_yeni>().gas==true)
        {
            gas_ust.transform.GetChild(0).GetComponent<Image>().enabled = false;
            gas_ust.transform.GetChild(0).GetChild(0).GetComponent<Image>().enabled = true;
        }
        else
        {
            gas_ust.transform.GetChild(0).GetComponent<Image>().enabled = true;
            gas_ust.transform.GetChild(0).GetChild(0).GetComponent<Image>().enabled = false;
        }
        if (player.GetComponent<truckk_yeni>().fren == true)
        {
            fren_ust.transform.GetChild(0).GetComponent<Image>().enabled = false;
            fren_ust.transform.GetChild(0).GetChild(0).GetComponent<Image>().enabled = true;
        }
        else
        {
            fren_ust.transform.GetChild(0).GetComponent<Image>().enabled = true;
            fren_ust.transform.GetChild(0).GetChild(0).GetComponent<Image>().enabled = false;
        }


        if (PlayerPrefs.GetInt("BonusMap") == 0 && tutorialcounter == 0)
        {
            gameObject.transform.GetChild(3).GetComponent<CanvasGroup>().alpha -= 0.7f * Time.deltaTime;
        }


        if (olme || benzindip && finished)
        {
            gamePlayPanel.gameObject.SetActive(false);
            player.GetComponent<truckk_yeni>().MovementSound.gameObject.GetComponent<AudioSource>().Stop();
            player.GetComponent<truckk_yeni>().brakeSound.GetComponent<AudioSource>().Stop();
        }
        if (Input.GetKey(KeyCode.Y))
        {
            PlayerPrefs.SetInt("Money", 55555);
        }
        _totalCoinText.text = PlayerPrefs.GetInt("Money").ToString();


        for (int i = 0; i < totalNitroText.Length; i++)
        {
            totalNitroText[i].text = PlayerPrefs.GetInt("TotalNitro").ToString();
        }
        for (int i = 0; i < totalMagnetText.Length; i++)
        {
            totalMagnetText[i].text = PlayerPrefs.GetInt("TotalMagnet").ToString();
        }
        for (int i = 0; i < total_4WDText.Length; i++)
        {
            total_4WDText[i].text = PlayerPrefs.GetInt("Total4WD").ToString();
        }

        if (PlayerPrefs.GetInt("TotalNitro") == 0 && NitroClick == false)
        {
            var nitroButtonColor = NitroButton.GetComponent<Image>().color;
            nitroButtonColor.a = 0;
            NitroButton.GetComponent<Image>().color = nitroButtonColor;
        }
        else
        {
            var nitroButtonColor = NitroButton.GetComponent<Image>().color;
            nitroButtonColor.a = 1;
            NitroButton.GetComponent<Image>().color = nitroButtonColor;
        }


        if (PlayerPrefs.GetInt("TotalMagnet") == 0 && MagnetClick == false)
        {
            var magnetButtonColor = magnetButton.GetComponent<Image>().color;
            magnetButtonColor.a = 0;
            magnetButton.GetComponent<Image>().color = magnetButtonColor;
        }
        else
        {
            var magnetButtonColor = magnetButton.GetComponent<Image>().color;
            magnetButtonColor.a = 1;
            magnetButton.GetComponent<Image>().color = magnetButtonColor;
        }



        if (PlayerPrefs.GetInt("Total4WD") < 1 && _4WDClick == false)
        {
            var _4WdButtonColor = magnetButton.GetComponent<Image>().color;
            _4WdButtonColor.a = 0;
            _4WDButton.GetComponent<Image>().color = _4WdButtonColor;
        }
        else
        {
            var _4WdButtonColor = magnetButton.GetComponent<Image>().color;
            _4WdButtonColor.a = 1;
            _4WDButton.GetComponent<Image>().color = _4WdButtonColor;
        }

        NitroNumberText.text = nitroNumber.ToString();
        nitroPurshased = nitroNumber * nitroPrice;
        nitroPriceText.text = nitroPurshased.ToString();

        magnetNumberText.text = magnetNumber.ToString();
        magnetPurshased = magnetNumber * MagnetPrice;
        magnetPriceText.text = magnetPurshased.ToString();

        _4WDNumberText.text = _4WDNumber.ToString();
        _4WDPurshased = _4WDNumber * _4WdPrice;
        _4WDPriceText.text = _4WDPurshased.ToString();

        if (MagnetClick)
        {
            if (magnettimer > 0)
            {
                if (PlayerPrefs.GetString("GameSoundStatus") == "True")
                {
                    MagnetSound.enabled = true;
                }
                magnetButton.GetComponent<Button>().enabled = false;
                magnettimer -= 1 * Time.deltaTime;
                magnetButton.GetComponent<Image>().fillAmount = magnettimer / 30;
            }
            if (magnettimer <= 0)
            {
                if (PlayerPrefs.GetString("GameSoundStatus") == "True")
                {
                    MagnetSound.enabled = true;
                }
                MagnetClick = false;
                magnetButton.GetComponent<Button>().enabled = true;
                magnetButton.GetComponent<Image>().fillAmount = 30;
            }
        }
        if (_4WDClick)
        {
            if (_4WDtimer > 0)
            {
                if (PlayerPrefs.GetString("GameSoundStatus") == "True")
                {

                    _4WDSound.enabled = true;

                }
                player.GetComponent<truckk_yeni>().dort_ceker = true;
                _4WDButton.GetComponent<Button>().enabled = false;
                _4WDtimer -= 1 * Time.deltaTime;
                _4WDButton.GetComponent<Image>().fillAmount = _4WDtimer / 15;
            }
            if (_4WDtimer <= 0)
            {

                if (PlayerPrefs.GetString("GameSoundStatus") == "True")
                {
                    _4WDSound.enabled = false;

                }
                player.GetComponent<truckk_yeni>().dort_ceker = false;
                _4WDClick = false;
                _4WDButton.GetComponent<Button>().enabled = true;
                _4WDButton.GetComponent<Image>().fillAmount = 15;
            }
        }
        if (NitroClick)
        {
            if (nitroTimer > 0)
            {

                NitroVolume.SetActive(true);
                player.GetComponent<truckk_yeni>().exhaust.transform.GetChild(0).gameObject.SetActive(true);
                player.GetComponent<truckk_yeni>().exhaust.transform.GetChild(1).gameObject.SetActive(false);
                if (PlayerPrefs.GetString("GameSoundStatus") == "True")
                {
                    NitroSound.enabled = true;
                }

                player.GetComponent<Rigidbody>().AddForce(player.transform.right * 25000);
                NitroButton.GetComponent<Button>().enabled = false;
                nitroTimer -= 1 * Time.deltaTime;
                NitroButton.GetComponent<Image>().fillAmount = nitroTimer / 1.7f;
            }
            if (nitroTimer <= 0)
            {
                NitroVolume.SetActive(false);
                player.GetComponent<truckk_yeni>().exhaust.transform.GetChild(0).gameObject.SetActive(false);
                player.GetComponent<truckk_yeni>().exhaust.transform.GetChild(1).gameObject.SetActive(true);
                if (PlayerPrefs.GetString("GameSoundStatus") == "True")
                {
                    NitroSound.enabled = false;
                }
                NitroClick = false;
                NitroButton.GetComponent<Button>().enabled = true;
                NitroButton.GetComponent<Image>().fillAmount = 3;
            }
        }

        if (PlayerPrefs.GetInt("BonusMap") == 0)
        {
          
            if (Time.timeScale < 0.5f)
            {
                _tutorialTimer += 1 * Time.deltaTime;
                if (_tutorialTimer >= 1)
                {
                    Time.timeScale = 1;
                    loading_screen.SetActive(true);
                    StartCoroutine(RestartScene());
                  
                   // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
            else
            {
                _tutorialTimer = 0;
            }

            if (!tutorialcollidertouch && tutorialcounter != 0 && tutorialcounter != 3)
            {
                gamePlayPanel.transform.GetChild(0).gameObject.SetActive(true);
                gamePlayPanel.transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                gamePlayPanel.transform.GetChild(0).gameObject.SetActive(false);
                gamePlayPanel.transform.GetChild(1).gameObject.SetActive(false);
            }


            if (!gameTimerGo.activeSelf)
            {
               
                if (tutorialcounter == 0)
                {
                   

                    fren_ust.gameObject.SetActive(false);
                    gas_ust.SetActive(true);
                    if (player.GetComponent<truckk_yeni>().gas == false)
                    {

                        _ımages.transform.GetChild(0).GetComponent<CanvasGroup>().alpha += Time.deltaTime * 2;
                      
                        if (_ımages.transform.GetChild(0).GetComponent<CanvasGroup>().alpha > 0.8f)
                        {
                            Time.timeScale = .1f;
                        }
                    }
                    else
                    {
                        gameTimerGo.SetActive(false);
                       // fren_ust.gameObject.SetActive(true);
                        tutorialcounter += 1;
                        Time.timeScale = 1;
                    }
                }
                if (tutorialcounter == 1)
                {
                    _ımages.transform.GetChild(0).GetComponent<CanvasGroup>().alpha -= Time.deltaTime;
                    if (tutorialcollidertouch)
                    {
                      //  fren_ust.SetActive(false);
                        gas_ust.SetActive(false);
                        _ımages.transform.GetChild(1).GetComponent<CanvasGroup>().alpha += Time.deltaTime * 2;
                        if (_ımages.transform.GetChild(1).GetComponent<CanvasGroup>().alpha > 0.8f)
                        {
                            _tutorialNitroButton.SetActive(true);
                            Time.timeScale = .1f;

                        }
                        if (NitroClick)
                        {
                            _tutorialNitroButton.SetActive(false);
                            tutorialcounter += 1;
                            Time.timeScale = 1f;
                            tutorialcollidertouch = false;
                           // fren_ust.SetActive(true);
                            gas_ust.SetActive(true);
                        }
                    }
                }
                if (tutorialcounter == 2)
                {
                    _ımages.transform.GetChild(1).GetComponent<CanvasGroup>().alpha -= Time.deltaTime;
                    player.GetComponent<truckk_yeni>().MainMesh.GetComponent<Rigidbody>().AddTorque(transform.forward * Time.deltaTime * (player.GetComponent<truckk_yeni>().kuvvet - 20), ForceMode.Acceleration);
                    if (tutorialcollidertouch)
                    {
                      //  fren_ust.SetActive(false);
                        _ımages.transform.GetChild(2).gameObject.SetActive(true);
                        _ımages.transform.GetChild(2).GetComponent<CanvasGroup>().alpha += Time.deltaTime * 2;
                        if (_ımages.transform.GetChild(2).GetComponent<CanvasGroup>().alpha > 0.8f)
                        {
                            Time.timeScale = .1f;
                        }
                        if (player.GetComponent<truckk_yeni>().gas)
                        {
                            _ımages.transform.GetChild(2).GetChild(0).GetChild(3).GetComponent<Image>().fillAmount = player.transform.rotation.eulerAngles.z / 345;
                            player.transform.Rotate(0, 0, 1f);
                        }
                    }
                    if (player.transform.rotation.eulerAngles.z > 177 && player.transform.rotation.eulerAngles.z < 182)
                    {
                        flip = true;
                    }
                    if (player.transform.rotation.eulerAngles.z > 350 && flip) //backflip is done
                    {
                        tutorialcounter += 1;
                        Time.timeScale = 1f;
                        tutorialcollidertouch = false;
                      //  fren_ust.SetActive(true);
                        flip = false;
                    }
                }
                if (tutorialcounter == 3)
                {
                    _ımages.transform.GetChild(2).GetComponent<CanvasGroup>().alpha -= Time.deltaTime;
                    if (tutorialcollidertouch)
                    {
                        fren_ust.gameObject.SetActive(true);
                        _ımages.transform.GetChild(3).GetComponent<CanvasGroup>().alpha += Time.deltaTime * 4;
                        if (player.GetComponent<truckk_yeni>().fren == false )
                        {
                            gasTankWarning.SetActive(true);
                            Time.timeScale = .1f;
                            gas_ust.SetActive(false);
                            _4wdColliders.SetActive(true);
                        }
                        else
                        {
                            _tutorialCoinAndFuelTank.SetActive(true);
                            Time.timeScale = 1;
                            tutorialcollidertouch = false;
                        }
                    }
                }
                if (tutorialcounter == 4)
                {
                    _ımages.transform.GetChild(3).GetComponent<CanvasGroup>().alpha -= Time.deltaTime;
                    if (tutorialcollidertouch)
                    {
                        _ımages.transform.GetChild(4).GetComponent<CanvasGroup>().alpha += Time.deltaTime * 4;

                        if (_ımages.transform.GetChild(4).GetComponent<CanvasGroup>().alpha > 0.8f)
                        {
                            _tutorial4WDButton.SetActive(true);
                            Time.timeScale = .1f;
                            gas_ust.SetActive(false);
                            fren_ust.SetActive(false);

                        }
                        if (_4WDClick)
                        {
                            gas_ust.SetActive(true);
                            _tutorial4WDButton.SetActive(false);
                            tutorialcounter += 1;
                            Time.timeScale = 1;
                            tutorialcollidertouch = false;
                            player.GetComponentInParent<truckk_yeni>().physicMaterial.dynamicFriction = player.gameObject.GetComponentInParent<truckk_yeni>().dynamicFrictionValue;

                        }
                    }
                }

                if (tutorialcounter == 5)
                {
                    _ımages.transform.GetChild(4).GetComponent<CanvasGroup>().alpha -= Time.deltaTime;
                    if (tutorialcollidertouch)
                    {
                        _ımages.transform.GetChild(5).GetComponent<CanvasGroup>().alpha += Time.deltaTime * 4;

                        if (_ımages.transform.GetChild(5).GetComponent<CanvasGroup>().alpha > 0.8f)
                        {
                            _tutorialMagnetbutton.SetActive(true);
                            Time.timeScale = .1f;
                            gas_ust.SetActive(false);
                          //  fren_ust.SetActive(false);
                        }
                        if (MagnetClick)
                        {
                          //  fren_ust.SetActive(true);
                            gas_ust.SetActive(true);
                            _tutorialMagnetbutton.SetActive(false);
                            tutorialcounter += 1;
                            Time.timeScale = 1;
                            tutorialcollidertouch = false;
                        }
                    }
                }

                if (tutorialcounter == 6)
                {
                    gas_ust.SetActive(true);
                //    fren_ust.SetActive(true);
                    _ımages.transform.GetChild(5).GetComponent<CanvasGroup>().alpha -= Time.deltaTime;
                    if (tutorialcollidertouch)
                    {

                        player.GetComponent<truckk_yeni>().MovementSound.GetComponent<AudioSource>().volume = Mathf.Lerp(player.GetComponent<truckk_yeni>().MovementSound.GetComponent<AudioSource>().volume, 0f, Time.smoothDeltaTime);
                        gameObject.transform.GetChild(3).GetComponent<CanvasGroup>().alpha += 0.7f * Time.deltaTime;

                    }

                }
                if (tutorialcounter == 6)
                {

                    if (tutorialcollidertouch)
                    {
                        StartCoroutine(TutorialMainMenu());
                    }
                }
            }
            else
            {
                if (!playButtonPanel.activeSelf)
                {
                    player.transform.GetChild(0).GetComponent<Rigidbody>().AddTorque(transform.forward * Time.deltaTime * -80, ForceMode.Acceleration);
                    player.GetComponent<Rigidbody>().AddForce(player.transform.right * 20000);
                    player.GetComponent<truckk_yeni>().MovementSound.GetComponent<AudioSource>().pitch = Mathf.Lerp(player.GetComponent<truckk_yeni>().MovementSound.GetComponent<AudioSource>().pitch, (-1 * player.GetComponent<truckk_yeni>().Wheels[1].GetComponent<Rigidbody>().angularVelocity.z / 13), Time.smoothDeltaTime);
                    player.GetComponent<truckk_yeni>().MovementSound.GetComponent<AudioSource>().volume = Mathf.Lerp(player.GetComponent<truckk_yeni>().MovementSound.GetComponent<AudioSource>().volume, 1f, Time.smoothDeltaTime);
                }
            }
        }

        minutes1 = ((int)t1 / 60).ToString();
        seconds1 = (t1 % 60).ToString("F2");
        minutes2 = ((int)t2 / 60).ToString();
        seconds2 = (t2 % 60).ToString("F2");
        minutes3 = ((int)t3 / 60).ToString();
        seconds3 = (t3 % 60).ToString("F2");
        minutes4 = ((int)t4 / 60).ToString();
        seconds4 = (t4 % 60).ToString("F2");
        if (PlayerPrefs.GetInt("Oyun_modu") == 1)
        {
            _2PModePlayerResult1Text.text = minutes1 + ":" + seconds1;
            _2PModePlayerResult2Text.text = minutes2 + ":" + seconds2;
        }
        if (PlayerPrefs.GetInt("Oyun_modu") == 2)
        {
            _4PModePlayerResult1Text.text = minutes1 + ":" + seconds1;
            _4PModePlayerResult2Text.text = minutes2 + ":" + seconds2;
            _4PModePlayerResult3Text.text = minutes3 + ":" + seconds3;
            _4PModePlayerResult4Text.text = minutes4 + ":" + seconds4;
        }

        if (benzin.gameOver)
        {
            GasTankPanel.SetActive(false);
            olme = false;
            kontrol = true;
            benzindip = false;
            deadZoom = false;
            flip = false;
            SingleModeGameOverPanel.SetActive(false);
            gamePlayPanel.SetActive(true);
            truckk_yeni.finishFren = false;
            darbe_deneme.dynamicFriction = 0;
            player.GetComponent<Rigidbody>().drag = 0;
            player.GetComponent<Rigidbody>().mass = 50;
            benzin.gameOver = false;
        }

        if (GasTankOver && (whatGasTankOver == 0 || whatGasTankOver == 1))
        {
            GasTankPanel.SetActive(false);
            GetComponent<Canvas>().enabled = true;
            truckk_yeni.finishFren = true;
            SingleModeGameOverPanel.SetActive(true);
            GasTankOver = false;
            whatGasTankOver += 1;
        }
        if (PlayerPrefs.GetString("BackroundSoundStatus") == "True")
        {
            if (!olme && gameSoundIndex == -1)
            {
                BackroundGameSounds.gameObject.SetActive(false);
            }
            for (int i = 0; i < BackroundGameSounds.transform.childCount; i++)
            {
                if (i != gameSoundIndex)
                {
                    if (gameSoundIndex == -1)
                    {
                        BackroundGameSounds.SetActive(false);
                        soundline.SetActive(true);
                    }
                    else
                    {
                        soundline.SetActive(false);
                        BackroundGameSounds.SetActive(true);
                        BackroundGameSounds.transform.GetChild(gameSoundIndex).GetComponent<AudioSource>().enabled = true;
                        BackroundGameSounds.transform.GetChild(i).GetComponent<AudioSource>().enabled = false;
                    }
                }
            }
        }
        if (isgas == true && !finished)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.S))
            {
                FrenDown();
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.S))
            {
                FrenUp();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.W))
            {
                GasDown();
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.W))
            {
                GasUp();
            }
        }
    }
    public GameObject soundline;
    public static bool flip;
    void LateUpdate()
    {
        if (PlayerPrefs.GetInt("BonusMap")==1)
        {
            if (SingleModeGameOverPanel.activeSelf && earnedTotalCoin<=0)
            {
                _get2xButton.SetActive(false);
            }
            else
            {
                _get2xButton.SetActive(true);
            }
        }
       

       if (finished==true)
        {
            gamePlayPanel.SetActive(false);
        }

        if (missionTimerPanel.activeSelf)
        {
            /* Geri Sayimmm */
            if (!GasTankPanel.activeSelf && gamePlayPanel.activeSelf)
                if (oyun_zaman > 0)
                {
                    oyun_zaman -= Time.deltaTime;
                    if (((int)(oyun_zaman / 60)).ToString().Length == 1)
                    {
                        panel_dakika.GetComponent<Text>().text = "0" + ((int)(oyun_zaman / 60)).ToString();
                    }
                    else
                    {
                        panel_dakika.GetComponent<Text>().text = ((int)(oyun_zaman / 60)).ToString();
                    }
                    if (((int)(oyun_zaman % 60)).ToString().Length == 1)
                    {
                        panel_saniye.GetComponent<Text>().text = "0" + ((int)(oyun_zaman % 60)).ToString();
                    }
                    else
                    {
                        panel_saniye.GetComponent<Text>().text = ((int)(oyun_zaman % 60)).ToString();
                    }
                    if ((int)(100 * (oyun_zaman - (int)(oyun_zaman % 60))).ToString().Length == 1)
                    {
                        panel_salise.GetComponent<Text>().text = "0" + ((int)(100 * (oyun_zaman - (int)(oyun_zaman % 60)))).ToString();
                    }
                    else
                    {
                        panel_salise.GetComponent<Text>().text = ((int)(100 * (oyun_zaman - (int)(oyun_zaman)))).ToString();
                    }
                }
        }

        if (player)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, spawn_vs_1.transform.position.z);

            if (player.transform.GetComponent<truckk_yeni>().Benzin <= 1)
            {
               
                Debug.Log("singlePanel");
                    player.GetComponent<truckk_yeni>().fren = false;
                    player.GetComponent<truckk_yeni>().gas = false;
                gamePlayPanel.SetActive(false);
              
                gasTankWarning.GetComponent<Image>().enabled = false;
                GetComponent<Canvas>().enabled = true;
                if (benzin.gameOver == true || GasTankOver == true)
                {
                    GasTankPanel.SetActive(false);
                }
                else if (whatGasTankOver == 0 && !benzin.gameOver && noThanks == false && !finished && (Oyun_modu == 0 || (Oyun_modu == 6 && PlayerPrefs.GetInt("Tur") != 2)))
                {
                    GasTankPanel.SetActive(true);
                    SingleModeGameOverPanel.SetActive(false);
                }
                else if (whatGasTankOver == 1 && !benzin.gameOver && noThanks == false && !finished && (Oyun_modu == 0 || (Oyun_modu == 6 && PlayerPrefs.GetInt("Tur") != 2)))
                {
                    GasTankPanel.SetActive(true);
                    SingleModeGameOverPanel.SetActive(false);
                }
                else if (whatGasTankOver == 2 && !benzin.gameOver)
                {
                    GetComponent<Canvas>().enabled = true;
                    _selectAndConinuePanel.SetActive(false);
                    SingleModeGameOverPanel.transform.GetChild(1).localPosition=new Vector3(800,0,0);
                    SingleModeGameOverPanel.SetActive(true);
                    GasTankOver = false;
                    whatGasTankOver += 1;
                }
                else
                {
                    GetComponent<Canvas>().enabled = true;
                    SingleModeGameOverPanel.SetActive(true);
                    GasTankOver = false;
                    whatGasTankOver += 1;
                }
            }

            if (!takildi)
            {
                if ((player.GetComponent<truckk_yeni>().Wheels[1].GetComponent<Rigidbody>().angularVelocity.z > 20 || player.GetComponent<truckk_yeni>().Wheels[1].GetComponent<Rigidbody>().angularVelocity.z < -20) && (player.GetComponent<truckk_yeni>().Wheels[1].GetComponent<Rigidbody>().velocity.x < 0.25f || player.GetComponent<truckk_yeni>().Wheels[1].GetComponent<Rigidbody>().velocity.x > -0.25f))
                {
                    takildi = true;
                    dur = StartCoroutine(takildi_fonk2());
                }
            }
            else if (player.GetComponent<truckk_yeni>().Wheels[0].GetComponent<Rigidbody>().velocity.x > 0.25f || player.GetComponent<truckk_yeni>().Wheels[0].GetComponent<Rigidbody>().velocity.x < -0.25f)
            {
                StopCoroutine(dur);
                takildi = false;
            }

            if (player.GetComponent<truckk_yeni>().Benzin < 20 && !olme)
            {
                gasTankWarning.SetActive(true);
            }
            else
            {
                gasTankWarning.SetActive(false);
            }

            if (basla)
            {
                basla = false;
                gameTimerThree.SetActive(true);
                gameTimerThree.GetComponent<Animation>().Play();
                ses3.GetComponent<AudioSource>().Play();
                Invoke("bas2x", 0.7f);
            }

            if (olme && kontrol)
            {
                
                darbe_deneme.dynamicFriction = 30;
                player.GetComponent<Rigidbody>().drag = 3;
                player.GetComponent<Rigidbody>().mass = 10000;

                GasTankPanel.SetActive(false);
                gasTankWarning.SetActive(false);

                crash.SetActive(true);
                truckk_yeni.finishFren = true;
                deadZoom = true;
                StartCoroutine(Crash_kapat(3));

                singleLastDistanceText.text = mesafe + "M";
                singleModeCollectedCoinsText.text = earnedTotalCoin.ToString("N0");
                singleModeAirTimeText.text = airTimeCounter.ToString();
                singleModeBackFlipText.text = backFlipCounter.ToString();
                singleModeFrontFlipText.text = frontFlipCounter.ToString();
                coinsEndAwardText.text = (award).ToString("N0");
              

                if (finished)
                {
                    gas_ust.SetActive(false);
                    fren_ust.SetActive(false);
                    isgas = false;
                    gasTankWarning.SetActive(false);
                    GetComponent<Canvas>().enabled = false;
                    deadZoom = true;

                    StartCoroutine(finished1(1));

                }
                kontrol = false;
            }

            else if (benzindip && kontrol)
            {
                singleLastDistanceText.text = mesafe + " M";
                singleModeCollectedCoinsText.text = earnedTotalCoin.ToString("N0");
                singleModeAirTimeText.text = airTimeCounter.ToString();
                singleModeBackFlipText.text = backFlipCounter.ToString();
                singleModeFrontFlipText.text = frontFlipCounter.ToString();
                coinsEndAwardText.text = award.ToString("N0");
                if (finished)
                {
                    gas_ust.SetActive(false);
                    fren_ust.SetActive(false);
                    isgas = false;
                    gasTankWarning.SetActive(false);
                    GetComponent<Canvas>().enabled = false;
                    deadZoom = true;
                    StartCoroutine(finished1(1));
                }
                kontrol = false;
            }

            ////  kazanma durumu
            if (Oyun_modu == 6 && finished) //mission
            {
                GetComponent<Canvas>().enabled = true;
                gasTankWarning.SetActive(false);
                gas_ust.SetActive(false);
                fren_ust.SetActive(false);
                isgas = false;

                //vs mod
                gasTankWarning.SetActive(false);

                if (!olme)
                {


                    if (PlayerPrefs.GetInt("Tur") == 2)
                    {
                        if (mesafe - _2PModeBotCar.transform.GetChild(0).position.x < 0)
                        {
                            Debug.Log("Erayy2");
                            _2PModeGameOverPanel.SetActive(true);
                            StartCoroutine(finished1(1));
                        }
                        else
                        {
                            Debug.Log("Erayy");
                            missionCompletedPanel.SetActive(true);
                        }
                    }

                    else
                    {
                        missionCompletedPanel.SetActive(true);
                    }

                    PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + PlayerPrefs.GetInt("Kazanil_money"));
                    missionCompletedRewardText.text = PlayerPrefs.GetInt("Kazanil_money").ToString("N0");
                    whatMissionText.text = "Mission " + PlayerPrefs.GetInt("Completed_mission").ToString();
                    if (PlayerPrefs.GetInt("Mission") == PlayerPrefs.GetInt("Completed_mission"))
                    {
                        PlayerPrefs.SetInt("Completed_mission", PlayerPrefs.GetInt("Completed_mission") + 1);
                    }
                }

            }

            if (Oyun_modu == 6 && tur == 1)
            {
                toplanan_particle.transform.GetChild(1).GetComponent<Text>().text = earnedTotalCoin.ToString();
                if (point <= earnedTotalCoin)
                {
                    finished = true;
                }
                if (oyun_zaman < 0)
                {
                    olme = true;
                }
            }
            if (Oyun_modu == 6 && tur == 3)
            {
                if (yol_metre <= mesafe)
                {
                    finished = true;
                }
                if (oyun_zaman < 0)
                {
                    olme = true;
                }
            }
            if (Oyun_modu == 6 && tur == 4)
            {
                if (yol_metre <= mesafe)
                {
                    finished = true;
                }
            }
            if (Oyun_modu == 6 && tur == 5)
            {
                if (particle <= (int.Parse(toplanan_particle.transform.GetChild(1).GetComponent<Text>().text)))
                {
                    finished = true;
                }
                if (oyun_zaman < 0)
                {
                    olme = true;
                }
            }
            if (Oyun_modu == 1 && finished)
            {   //2P mod
                gasTankWarning.SetActive(false);
                StartCoroutine(finished1(1));

            }
            if (Oyun_modu == 2 && finished && once)
            {
                gasTankWarning.SetActive(false);

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (_4PModeCars[i].transform.GetChild(0).position.x <= _4PModeCars[j].transform.GetChild(0).position.x)
                        {
                            gecici = _4PModeCars[i];
                            _4PModeCars[i] = _4PModeCars[j];
                            _4PModeCars[j] = gecici;
                        }
                    }
                }
                if (!olme)
                {
                    for (int i = 0; i < _4PModeCars.Length; i++)
                    {
                        if (_4PModeCars[i].name == player.name)
                        {
                            if (i == 0 || i==1 ||i==2)
                            {
                                bat_lost = true;
                            }
                            if (i == 3)
                            {
                                bat_lost = false;
                            }
                        }
                    }

                }
                deadZoom = true;
                StartCoroutine(finished2(1));
            }

        }
        //mesafe yazdırma onemli
        if (player)
        {
            mesafe = ((int)(Chassis.transform.position.x - ilk_pos.x));
            carDistanceCounter = ((int)(Chassis.transform.position.x - ilk_pos.x));

            if (Oyun_modu == 0)
            {
                if (Scene_val == 1)
                {
                    if (Chassis.transform.position.x > PlayerPrefs.GetInt("Skor01"))
                    {
                        PlayerPrefs.SetInt("Skor01", (int)Chassis.transform.position.x);
                        rekor_text.text = PlayerPrefs.GetInt("Skor01").ToString() + "M";
                        bestScoreText.text = PlayerPrefs.GetInt("Skor01").ToString() + "M";
                    }
                    else
                    {
                        rekor_text.text = PlayerPrefs.GetInt("Skor01").ToString() + "M";
                        bestScoreText.text = PlayerPrefs.GetInt("Skor01").ToString() + "M";
                    }
                }
                else if (Scene_val == 2)
                {
                    if (Chassis.transform.position.x > PlayerPrefs.GetInt("Skor02"))
                    {
                        PlayerPrefs.SetInt("Skor02", (int)Chassis.transform.position.x);
                        rekor_text.text = PlayerPrefs.GetInt("Skor02").ToString() + "M";
                        bestScoreText.text = PlayerPrefs.GetInt("Skor02").ToString() + "M";
                    }
                    else
                    {
                        rekor_text.text = PlayerPrefs.GetInt("Skor02").ToString() + "M";
                        bestScoreText.text = PlayerPrefs.GetInt("Skor02").ToString() + "M";
                    }
                }
                else if (Scene_val == 3)
                {
                    if (Chassis.transform.position.x > PlayerPrefs.GetInt("Skor03"))
                    {
                        PlayerPrefs.SetInt("Skor03", (int)Chassis.transform.position.x);
                        rekor_text.text = PlayerPrefs.GetInt("Skor03").ToString() + "M";
                        bestScoreText.text = PlayerPrefs.GetInt("Skor03").ToString() + "M";
                    }
                    else
                    {
                        rekor_text.text = PlayerPrefs.GetInt("Skor03").ToString() + "M";
                        bestScoreText.text = PlayerPrefs.GetInt("Skor03").ToString() + "M";
                    }
                }
                else if (Scene_val == 4)
                {
                    if (Chassis.transform.position.x > PlayerPrefs.GetInt("Skor04"))
                    {
                        PlayerPrefs.SetInt("Skor04", (int)Chassis.transform.position.x);
                        rekor_text.text = PlayerPrefs.GetInt("Skor04").ToString() + "M";
                        bestScoreText.text = PlayerPrefs.GetInt("Skor04").ToString() + "M";
                    }
                    else
                    {
                        rekor_text.text = PlayerPrefs.GetInt("Skor04").ToString() + "M";
                        bestScoreText.text = PlayerPrefs.GetInt("Skor04").ToString() + "M";
                    }
                }
                else if (Scene_val == 5)
                {
                    if (Chassis.transform.position.x > PlayerPrefs.GetInt("Skor05"))
                    {
                        PlayerPrefs.SetInt("Skor05", (int)Chassis.transform.position.x);
                        rekor_text.text = PlayerPrefs.GetInt("Skor05").ToString() + "M";
                        bestScoreText.text = PlayerPrefs.GetInt("Skor05").ToString() + "M";
                    }
                    else
                    {
                        rekor_text.text = PlayerPrefs.GetInt("Skor05").ToString() + "M";
                        bestScoreText.text = PlayerPrefs.GetInt("Skor05").ToString() + "M";
                    }
                }
            }
            else
            {
                rekor_text.transform.parent.gameObject.SetActive(false);
                rekor_text.gameObject.SetActive(false);
            }
        }

    }

    public Text rekor_text;

    IEnumerator finished1(int x)
    {
        GasTankPanel.SetActive(false);
        yield return new WaitForSecondsRealtime(x);
        GetComponent<Canvas>().enabled = true;
        singleLastDistanceText.text = mesafe + "M";
        if (Oyun_modu != 6 && Oyun_modu != 2)
        {
            _2PModeGameOverPanel.SetActive(true);

        }
        float fark = Mathf.Abs(mesafe - _2PModeBotCar.transform.GetChild(0).position.x);
        if (!olme)
        {
            if (benzindip)
            {
                _2pModeResultText.text = "YOU LOST !";

            }
            else if (_2PModeBotCar.transform.GetChild(0).position.x > player.transform.GetChild(0).position.x)
            {
                _2pModeResultText.text = "YOU LOST !";
            }
            else
            {
                _2pModeResultText.text = "YOU WIN ";
               // PlayerPrefs.SetInt("Money", earnedTotalCoin);

            }
        }
        else
        {
            for (int i = 0; i < res2_vs.transform.childCount; i++)
            {
                res2_vs.transform.GetChild(i).gameObject.SetActive(false);
            }


            _2pModeResultText.text = "YOU LOST !";

        }
    }
    public bool bat_lost = false;
    IEnumerator finished2(int y)
    {
        yield return new WaitForSecondsRealtime(y);
        GetComponent<Canvas>().enabled = true;
        _4PModeGameOverPanel.SetActive(true);

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (_4PModeCars[i].transform.GetChild(0).position.x <= _4PModeCars[j].transform.GetChild(0).position.x)
                {
                    gecici = _4PModeCars[i];
                    _4PModeCars[i] = _4PModeCars[j];
                    _4PModeCars[j] = gecici;
                }
            }
        }


        if (!olme)
        {
            if (benzindip)
            {

                bat_lost = true;
                _4PModeResualtText.text = "YOU LOST !";
                _4PModePlayerName1Text.text = PlayerPrefs.GetString("OyuncuAdi");
                for (int x = 0; x < res4_bat.transform.childCount; x++)
                {
                    res4_bat.transform.GetChild(x).gameObject.SetActive(false);
                }
                res4_bat.transform.GetChild(PlayerPrefs.GetInt("Varsayilan_kar")).gameObject.SetActive(true);
            }
            else
            {
                for (int i = 0; i < _4PModeCars.Length; i++)
                {
                    if (_4PModeCars[i].name == player.name)
                    {
                        if (i == 0)
                        {

                            bat_lost = true;
                            _4PModeResualtText.text = "YOU LOST !";
                        }
                        if (i == 1)
                        {

                            bat_lost = true;
                            _4PModeResualtText.text = "YOU LOST !";

                        }
                        if (i == 2)
                        {

                            bat_lost = true;
                            _4PModeResualtText.text = "YOU LOST !";

                        }
                        if (i == 3)
                        {

                            bat_lost = false;
                            _4PModeResualtText.text = "YOU WIN !";
                        }
                    }
                }
            }
            once = false;
        }
        else
        {
            _4PModeResualtText.text = "YOU LOST !";
        }
    }


    IEnumerator yarali_bar_once(int i)
    {
        transform.GetComponent<Canvas>().enabled = false;
        yield return new WaitForSecondsRealtime(i);
        transform.GetComponent<Canvas>().enabled = true;
        gecis_oldun.SetActive(true);
    }
   public void Get2xButton()
    {
        singleModeCollectedCoinsText.text = (earnedTotalCoin*2).ToString("N0");
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") +(earnedTotalCoin*2));
        var Get2XPopup = Instantiate(m_Get2XPopup, GameObject.Find("Canvas").GetComponent<RectTransform>(), worldPositionStays: false);
        if(Get2XPopup) Get2XPopup.GetComponent<PopupManager>().m_GainedText.text = (earnedTotalCoin*2).ToString("N0");
    }

    public void Restart()
    {
        Time.timeScale = 1;
        Debug.Log(Time.timeScale);
        loading_screen.SetActive(true);
        StartCoroutine(RestartScene());
    }
    IEnumerator RestartScene()
    {
        yield return new WaitForSecondsRealtime(Random.Range(4,9));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator MainMenuCoroutine()
    {
        yield return new WaitForSecondsRealtime(Random.Range(3,9));
        SceneManager.LoadScene("MainMenu");
    }

    public void TouchToContunieButton(int i)
    {

        loading_screen.SetActive(true);
        if (i == 0)
        {
            PlayerPrefs.SetInt("inmission", 0);
        }
        else if (i == 1)
        {
            tunePanelOpen = false;
            PlayerPrefs.SetInt("BonusMap", 1);
        }
        else if (i == 2)
        {
            PlayerPrefs.SetInt("inmission", 1);
        }
        missionCompletedPanel.SetActive(false);

        Time.timeScale = 1;
        StartCoroutine(MainMenuCoroutine());
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") +earnedTotalCoin );

    }

    public static bool missionFinish = false;
    public void missiontoAna_Sahne()
    {
        loading_screen.SetActive(true);
        PlayerPrefs.SetInt("inmission", 1);
        missionCompletedPanel.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + param);
    }
    public void Ana_Sahne()
    {
        loading_screen.SetActive(true);
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + earnedTotalCoin);
        PlayerPrefs.SetInt("inmission", 0);
        missionCompletedPanel.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(MainMenuCoroutine());
    }


    public void Pause()
    {
        deadZoom = true;
        Time.timeScale = .5f * Time.deltaTime;
        pause_panel.SetActive(true);
        gamePlayPanel.SetActive(false);
        // if(GoogleAdMobController.m_instance) GoogleAdMobController.m_instance.RequestAndLoadInterstitialAd();
        player.GetComponent<truckk_yeni>().MovementSound.gameObject.GetComponent<AudioSource>().Stop();
        player.GetComponent<truckk_yeni>().brakeSound.GetComponent<AudioSource>().Stop();
        gasTankWarning.GetComponent<AudioSource>().Stop();

        if (!pause_panel.activeSelf)
        {

        }
    }
    public void Pause_back()
    {
         Time.timeScale = 1;
        gamePlayPanel.SetActive(true);
        pause_panel.SetActive(false);
        player.GetComponent<truckk_yeni>().MovementSound.gameObject.GetComponent<AudioSource>().Play();
        player.GetComponent<truckk_yeni>().brakeSound.GetComponent<AudioSource>().Play();
        if (player.GetComponent<truckk_yeni>().Benzin < 20)
        {
            gasTankWarning.GetComponent<AudioSource>().Play();
        }
    }

    public void ReviveWithCash()
    {
        if (PlayerPrefs.GetInt("Money")>=15000)
        {
        olme = false;
        kontrol = true;
        benzindip = false;
        deadZoom = false;
        SingleModeGameOverPanel.SetActive(false);
        gamePlayPanel.SetActive(true);
        truckk_yeni.finishFren = false;
        player.GetComponent<truckk_yeni>().gas = false;
        player.GetComponent<truckk_yeni>().fren = false;
        player.GetComponent<truckk_yeni>().Benzin = 100;
        darbe_deneme.dynamicFriction = 0;
        player.GetComponent<Rigidbody>().drag = 0;
        player.GetComponent<Rigidbody>().mass = 50;
        player.GetComponent<truckk_yeni>().MovementSound.gameObject.GetComponent<AudioSource>().Play();
        player.GetComponent<truckk_yeni>().brakeSound.GetComponent<AudioSource>().Play();
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.3f,
            player.transform.position.z);
        player.transform.localEulerAngles = new Vector3(0, 0, 0);
        player.transform.GetChild(0).eulerAngles = new Vector3(0, 0, 0);
        for (var i = 0; i < player.GetComponent<truckk_yeni>().Wheels.Length; i++)
        {
            player.GetComponent<truckk_yeni>().Wheels[i].GetComponent<Rigidbody>().angularVelocity =
                new Vector3(0, 0, 0);
            player.GetComponent<truckk_yeni>().Wheels[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            player.GetComponent<truckk_yeni>().Wheels[i].localRotation = temp_rot_wheel[i];
            player.GetComponent<truckk_yeni>().Wheels[i].localPosition = temp_pos_wheel[i];
        }

        arac_karakteri.GetComponent<adam_oldu>().adam_son.gameObject.SetActive(true);
        arac_karakteri.GetComponent<adam_oldu>().adam2.transform.position =
            arac_karakteri.GetComponent<adam_oldu>().adam2.transform.position;
        arac_karakteri.GetComponent<adam_oldu>().adam2.gameObject.SetActive(false);
        BackroundGameSounds.transform.GetChild(gameSoundIndex).GetComponent<AudioSource>().Play();
        GasTankPanel.SetActive(false);
       
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 15000);
        }
        else
        {
            _powerBuyWarningPanel.SetActive(true);
        }
            
       
    }
    public void QualitySettingsButton()
    {
        _qualityText.text = (_qualityText.text == "High") ? "Low" : "High";
        PlayerPrefs.SetString("GameQuality", _qualityText.text);
       
        if (_qualityText.text == "High")
        {
            foreach (var item in GameObject.FindObjectsOfType<Camera>())
            {
                item.farClipPlane = 200;
            }
            RenderSettings.fogStartDistance = 20f;
            RenderSettings.fogEndDistance = 600f;
            foreach (var item in _qualityObject)
            {
                item.SetActive(true);
            }
        }
        if (_qualityText.text == "Low")
        {
            foreach (var item in GameObject.FindObjectsOfType<Camera>())
            {
                item.farClipPlane = 90;
            }
           
            RenderSettings.fogStartDistance = 10f;
            RenderSettings.fogEndDistance = 80;
            foreach (var item in _qualityObject)
            {
                item.SetActive(false);
            }
        }
    }

    public void RevivalButton(string _whatButton)
    {
       
        m_rewardType = _whatButton;
      

    }


}

