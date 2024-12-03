using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using DG.Tweening;
using Random = UnityEngine.Random;

public class Mainmenu : MonoBehaviour
{
    [Header("Settings Panel")]
    public GameObject _settingsPanel;
    public GameObject[] _qualityObject;
    public Text _qualityText;

    [Header("Seyf Area")]
    public GameObject m_DontHaveMoneyPopup;

    public GameObject _backround;
    public GameObject mainMenuPanel;
    [Header("Single")]
    public GameObject kilit_speed_sin;
    public GameObject kilit_hills_sin, kilit_snow_sin, kilit_city_sin;
    public Text desertMapPriceText, hillMapPriceText, SnowMapPriceText, cityMapPriceText;
    public Text villageBestDistanceText, desertBestDistanceText, hillBestDistanceText, snowBestDistanceText, cityBestDistanceText;
    public Text villageTravelDistanceText, desertTravelDistanceText, hillTravelDistanceText, snowTravelDistanceText, cityTravelDistanceText;
    [Header("2P Battle")]
    public GameObject kilit_vs;
    public GameObject kilit_speed_vs, kilit_hills_vs, kilit_snow_vs, kilit_city_vs;
    // public Text _2P_desertMapPriceText, _2P_hillMapPriceText, _2P_SnowMapPriceText, _2P_cityMapPriceText;
    [Header("4P Battle")]
    public GameObject kilit_speed_bat;
    public GameObject kilit_bat;
    public GameObject kilit_hills_bat, kilit_snow_bat, kilit_city_bat;
    // public Text _4P_desertMapPriceText, _4P_hillMapPriceText, _4P_SnowMapPriceText, _4P_cityMapPriceText;
    [Header("Tune Panel")]
    public int Arac_deger;
    public GameObject tunePanel;
    public Transform Upg1, Upg2, Upg3, Upg4;
    public Text EnginepriceText, SusPansionPriceText, FrictionPriceText, FuelTankPriceText;
    public GameObject upgradeWarningPanel;
    public GameObject[] UpgradeSound;

    [Header("Character")]
    public int sayi_kar = 0;
    public GameObject[] characterBody;
    public GameObject[] characterWaypoints;
    public Text[] CharacterPriceText;
    public Transform CharacterPanelMoneyBuyButton, CharacterBuyWarningPanel;
    public GameObject characterZemin, karakter, characterImage, karakter_panel, characterRightButton, characterLeftButton;
    public Text isim_karakter_text, isim_karakter_detay;
    public GameObject CharacterSelectButton, characterBuyButton;

    public Text fiyat_karakter_text;

    [Header("Cars")]
    public int sayi = 0;
    public GameObject[] carBody;
    public GameObject[] carWaypoints;
    public Text[] CarPriceText;
    public GameObject[] CarBackroundVideo;
    public Transform CarPanelMoneyBuyButton;
    public GameObject Arabalar, carImage;
    public GameObject arabaZemin;
    public GameObject carRightButton, carLeftButton;
    public GameObject spawnPos;
    public Text isim_araba_text, isim_araba_detay;
    public Transform VehiclesPanel;
    public Transform carBuyButton;
    public Transform carSelectButton;
    public Text onay_text;

    public Transform carBuyWarningPanel;

    [Header("Stage")]
    public Transform StagePanel;
    public Transform Single2;
    public Transform _2PBattlePanel;
    public Transform _4PBattlePanel;

    [Header("Missons")]
    public int missionint;
    public GameObject missionsPanel, missionsPanelButtoLocket;
    public GameObject[] MissionsButtonLocket;


    [Header("Other")]
    public Text _totalCoin;
    public GameObject BackroundSound;
    public AudioSource buysound;
    public Vector3 turn;
    public GameObject loading_once;
    static bool loadingg = true;



    void Awake()
    {
        //        
        Application.targetFrameRate = 60;
        if (PlayerPrefs.GetInt("BonusMap") == 0)
        {
            /*  PlayerPrefs.SetInt("BonusMap",1); */
            SceneManager.LoadScene(6);
            PlayerPrefs.SetInt("TotalNitro", 5);
            PlayerPrefs.SetInt("TotalMagnet", 5);
            PlayerPrefs.SetInt("Total4WD", 5);
            PlayerPrefs.SetInt("Varsayilan", 10);
            PlayerPrefs.SetInt("Oyun_modu", 0);
            PlayerPrefs.SetString("ExternalSoundStatus", "True");
            PlayerPrefs.SetString("GameSoundStatus", "True");
            PlayerPrefs.SetString("BackroundSoundStatus", "True");
        }

    }
    void Start()
    {

        Screen.sleepTimeout = SleepTimeout.NeverSleep; // Ekranın kararmasını yada kapanmasını engeller
        if (PlayerPrefs.GetString("ExternalSoundStatus") == "False")
        {
            _settingsPanel.transform.GetChild(0).GetChild(0).GetComponent<Image>().enabled = false;
            _settingsPanel.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().enabled = true;
            _settingsPanel.transform.GetChild(0).GetChild(0).GetComponent<Button>().enabled = false;
            _settingsPanel.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Button>().enabled = true;
        }
        if (PlayerPrefs.GetString("GameSoundStatus") == "False")
        {
            _settingsPanel.transform.GetChild(0).GetChild(1).GetComponent<Image>().enabled = false;
            _settingsPanel.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>().enabled = true;
            _settingsPanel.transform.GetChild(0).GetChild(1).GetComponent<Button>().enabled = false;
            _settingsPanel.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Button>().enabled = true;

        }
        if (PlayerPrefs.GetString("BackroundSoundStatus") == "False")
        {
            _settingsPanel.transform.GetChild(0).GetChild(2).GetComponent<Image>().enabled = false;
            _settingsPanel.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>().enabled = true;
            _settingsPanel.transform.GetChild(0).GetChild(2).GetComponent<Button>().enabled = false;
            _settingsPanel.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Button>().enabled = true;

        }
        if (PlayerPrefs.GetString("Vibrate") == "False")
        {
            _settingsPanel.transform.GetChild(0).GetChild(3).GetComponent<Image>().enabled = false;
            _settingsPanel.transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<Image>().enabled = true;
            _settingsPanel.transform.GetChild(0).GetChild(3).GetComponent<Button>().enabled = false;
            _settingsPanel.transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<Button>().enabled = true;

        }


        if (PlayerPrefs.GetInt("Mission_Buy") == 1)
        {
            missionsPanelButtoLocket.SetActive(false);
        }
        else
        {
            missionsPanelButtoLocket.SetActive(true);
        }

        nitroNumber = 1;
        turn.x -= Input.GetAxis("Mouse X") * 0;

        missionint = PlayerPrefs.GetInt("inmission");
        if (missionint == 1)
        {
            PlayerPrefs.SetInt("inmission", 0);
            arabaZemin.SetActive(false);
            _SinglePlayer2();
            VehiclesPanel.gameObject.SetActive(false);
            missionsPanel.SetActive(true);
        }
        else
        {
            if (oyunici.tunePanelOpen)
            {
                _backround.SetActive(true);
                tunePanel.SetActive(true);
                arabaZemin.SetActive(false);
                missionsPanel.SetActive(false);
                VehiclesPanel.gameObject.SetActive(false);
            }
            else
            {
                VehiclesPanel.gameObject.SetActive(true);
                arabaZemin.SetActive(true);
                missionsPanel.SetActive(false);
            }

        }
        if (loadingg)
        {

            loading_once.SetActive(true);
            loadingg = false;
        }


        if (PlayerPrefs.GetInt("Kayit") != 1)
        {
            kayit_panel.SetActive(true);
        }
        Time.timeScale = 1;
        temp_pos = transform.position;
        temp_rot = transform.rotation;
        Application.targetFrameRate = 300;


        if (PlayerPrefs.GetInt("first") == 0)
        {
            PlayerPrefs.SetString("Vibrate", "True");

            PlayerPrefs.SetInt("Varsayilan", 0);
            PlayerPrefs.SetInt("Mission", 0);
            PlayerPrefs.SetInt("Completed_mission", 0);
            PlayerPrefs.SetInt("SaveMap", 1);
            PlayerPrefs.SetInt("Araba_Deger" + 0, 1);
            PlayerPrefs.SetInt("Money", 0);
            PlayerPrefs.SetInt("first", 1);
            PlayerPrefs.SetInt("laspositionmap1", 200);
            PlayerPrefs.SetInt("laspositionmap2", 250);
            PlayerPrefs.SetInt("laspositionmap3", 300);
            PlayerPrefs.SetInt("laspositionmap4", 350);
            PlayerPrefs.SetInt("laspositionmap5", 400);
            PlayerPrefs.SetInt("distancecoinmap1", 0);
            PlayerPrefs.SetInt("distancecoinmap2", 0);
            PlayerPrefs.SetInt("distancecoinmap3", 0);
            PlayerPrefs.SetInt("distancecoinmap4", 0);
            PlayerPrefs.SetInt("distancecoinmap5", 0);
            PlayerPrefs.SetInt("Varsayilan_kar", 0);
            PlayerPrefs.SetInt("Karakterdeger" + 0, 1);
            PlayerPrefs.SetInt("Season0", 0);
            PlayerPrefs.SetInt("TotalNitro", 1);
            PlayerPrefs.SetInt("TotalMagnet", 1);
            PlayerPrefs.SetInt("Total4WD", 1);
            PlayerPrefs.SetInt("Oyun_modu", 0);
        }

        for (int i = 0; i < carImage.transform.childCount; i++)
        {
            carImage.transform.GetChild(i).gameObject.SetActive(false);
        }
        carImage.transform.GetChild(PlayerPrefs.GetInt("Varsayilan")).gameObject.SetActive(true);

        isim_araba_text.text = Arabalar.transform.GetChild(PlayerPrefs.GetInt("Varsayilan")).GetComponent<Ozellik>().isim.ToString();
        isim_araba_detay.text = Arabalar.transform.GetChild(PlayerPrefs.GetInt("Varsayilan")).GetComponent<Ozellik>().detay.ToString();
        for (int i = 0; i < karakter.transform.childCount; i++)
        {
            characterImage.transform.GetChild(i).gameObject.SetActive(false);
        }
        characterImage.transform.GetChild(PlayerPrefs.GetInt("Varsayilan_kar")).gameObject.SetActive(true);
        karakter.transform.GetChild(PlayerPrefs.GetInt("Varsayilan_kar")).gameObject.SetActive(true);
        sayi = PlayerPrefs.GetInt("Varsayilan");
        sayi_kar = PlayerPrefs.GetInt("Varsayilan_kar");
        fiyat_karakter_text.text = karakter.transform.GetChild(PlayerPrefs.GetInt("Varsayilan_kar")).GetComponent<karakter_ozellik>().fiyat.ToString("N0");
        isim_karakter_text.text = karakter.transform.GetChild(PlayerPrefs.GetInt("Varsayilan_kar")).GetComponent<karakter_ozellik>().isim.ToString();
        isim_karakter_detay.text = karakter.transform.GetChild(PlayerPrefs.GetInt("Varsayilan_kar")).GetComponent<karakter_ozellik>().detay.ToString();
        kilit_kontrol();
    }



    public void _StagePanelOpen()
    {
        sayi_kar = PlayerPrefs.GetInt("Varsayilan_kar");
        sayi = PlayerPrefs.GetInt("Varsayilan");
        // m_AdContoroller.ShowInterstitialAd();
        turn.x = 0;
        //  m_AdContoroller.ShowInterstitialAd();
    }
    public void _SinglePlayer2()
    {
        PlayerPrefs.SetInt("Oyun_modu", 0);
    }

    public void _2PBattlePanelOpen()
    {
        PlayerPrefs.SetInt("SaveMap", 1);
        PlayerPrefs.SetInt("Oyun_modu", 1);
    }

    public void _4PBattlePanelOpen()
    {
        PlayerPrefs.SetInt("SaveMap", 1);
        PlayerPrefs.SetInt("Oyun_modu", 2);
    }


    public void _VehiclePanelOpen()
    {
        sayi_kar = PlayerPrefs.GetInt("Varsayilan_kar");
        characterImage.transform.GetChild(sayi_kar).gameObject.SetActive(true);
        missionsPanel.SetActive(false);
    }
    public void _TunePanelOpen()
    {
        turn.x = 0;
        sayi_kar = PlayerPrefs.GetInt("Varsayilan_kar");
        sayi = PlayerPrefs.GetInt("Varsayilan");
        missionsPanel.SetActive(false);
    }
    Vector3 temp_pos;
    Quaternion temp_rot;
    bool garaj = false;
    public void _VehiclePanelOpenBack()
    {
        garaj = false;
        VehiclesPanel.gameObject.SetActive(false);
        karakter.SetActive(true);
        karakter_panel.SetActive(false);
        for (int i = 0; i < Arabalar.transform.childCount; i++)
        {
            Arabalar.transform.GetChild(i).gameObject.SetActive(false);
        }
        Arabalar.transform.GetChild(PlayerPrefs.GetInt("Varsayilan")).gameObject.SetActive(true);
        _2PBattlePanel.gameObject.SetActive(false);
        Single2.gameObject.SetActive(false);
        StagePanel.gameObject.SetActive(false);
        _4PBattlePanel.gameObject.SetActive(false);

    }

    public void SettingsButton(string WhatButton)
    {
        if (WhatButton == "Open")
        {
            _settingsPanel.transform.GetChild(0).GetComponent<Animation>().Play();
        }
        if (WhatButton == "Exit")
        {
            _settingsPanel.GetComponent<Animation>().Play();
        }

    }

    float carPositionSpeed = 3f;
    bool deneme = false;
    public void Character_Left_Button()
    {
        if (sayi_kar <= 0)
        {
            sayi_kar = karakter.transform.childCount;
        }

        for (int i = 0; i < karakter.transform.childCount; i++)
        {
            /* 	karakter.transform.GetChild (i).gameObject.SetActive (false);	 */

        }
        sayi_kar = sayi_kar - 1;
        /* karakter.transform.GetChild (sayi_kar).gameObject.SetActive (true); */
        fiyat_karakter_text.text = karakter.transform.GetChild(sayi_kar).GetComponent<karakter_ozellik>().fiyat.ToString("N0");
        isim_karakter_text.text = karakter.transform.GetChild(sayi_kar).GetComponent<karakter_ozellik>().isim.ToString();
        isim_karakter_detay.text = karakter.transform.GetChild(sayi_kar).GetComponent<karakter_ozellik>().detay.ToString();
    }
    public void Character_Right_Button()
    {
        if (sayi_kar >= karakter.transform.childCount - 1)
        {
            sayi_kar = -1;
        }
        for (int i = 0; i < karakter.transform.childCount; i++)
        {
            /* 	karakter.transform.GetChild (i).gameObject.SetActive (false);	 */
        }
        sayi_kar = sayi_kar + 1;
        /* karakter.transform.GetChild (sayi_kar).gameObject.SetActive (true); */
        fiyat_karakter_text.text = karakter.transform.GetChild(sayi_kar).GetComponent<karakter_ozellik>().fiyat.ToString("N0");
        isim_karakter_text.text = karakter.transform.GetChild(sayi_kar).GetComponent<karakter_ozellik>().isim.ToString();
        isim_karakter_detay.text = karakter.transform.GetChild(sayi_kar).GetComponent<karakter_ozellik>().detay.ToString();
    }
    [Header("Nitro System")]
    public int nitroPrice;
    public int nitroNumber, nitroPurshased;

    public GameObject nitroBuyPanel, reduceButton, raiseButton, nitroBuyButton, nitroWarningPanel;
    public Text nitroNumberText, nitroPriceText, totalNitroText;

    public void QualitySettingsButton()
    {
        _qualityText.text = (_qualityText.text == "High") ? "Low" : "High";
        PlayerPrefs.SetString("GameQuality", _qualityText.text);

        if (_qualityText.text=="High")
        {
            foreach (var item in _qualityObject)
            {
                item.SetActive(true);
            }
        }
        if (_qualityText.text == "Low")
        {

            foreach (var item in _qualityObject)
            {
                item.SetActive(false);
            }

        }
    }
    public void SoundOn(String whatSound)
    {
        PlayerPrefs.SetString(whatSound, "True");

    }
    public void SoundOff(String whatSound)
    {
        PlayerPrefs.SetString(whatSound, "False");
    }

    public GameObject _logo;
    private void Update()
    {
        if (_carBuyPanel.activeSelf)
        {
            _carBuyPanel.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = Arabalar.transform.GetChild(sayi).GetComponent<Ozellik>().isim.ToString();
            _carBuyPanel.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>().text = Arabalar.transform.GetChild(sayi).GetComponent<Ozellik>().detay.ToString();
        }

        if (_characterBuyPanel)
        {
            _characterBuyPanel.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = karakter.transform.GetChild(sayi_kar).GetComponent<karakter_ozellik>().isim.ToString();
            _characterBuyPanel.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>().text = karakter.transform.GetChild(sayi_kar).GetComponent<karakter_ozellik>().detay.ToString();
        }
        
        
        if(kayit_panel.activeSelf)
        {
            _logo.SetActive(true);
            loading_once.SetActive(false);
        }
        if (VehiclesPanel.gameObject.activeSelf || karakter_panel.activeSelf)
        {
            _backround.SetActive(false);
        }
        if(loading_screen.activeSelf)
        {
            BackroundSound.GetComponent<AudioSource>().volume = Mathf.Lerp(BackroundSound.GetComponent<AudioSource>().volume,0,Time.maximumDeltaTime);
        }
        if (!loading_once.activeSelf && !kayit_panel.activeSelf)
        {

            if (PlayerPrefs.GetString("BackroundSoundStatus") == "True")
            {
                BackroundSound.GetComponent<AudioSource>().enabled = true;
            }
            if (PlayerPrefs.GetString("BackroundSoundStatus") == "False")
            {
                BackroundSound.GetComponent<AudioSource>().enabled = false;
            }

            mainMenuPanel.SetActive(true);
            if (Arabalar.activeSelf && !loading_screen.activeSelf)
            {
                for (int i = 0; i < Arabalar.transform.childCount; i++)
                {
                    if (PlayerPrefs.GetString("ExternalSoundStatus") == "True")
                    {
                        if (i != sayi)
                        {
                            Arabalar.transform.GetChild(i).GetComponent<AudioSource>().enabled = false;
                        }
                        Arabalar.transform.GetChild(sayi).GetComponent<AudioSource>().enabled = true;
                    }
                    if (PlayerPrefs.GetString("ExternalSoundStatus") == "False")
                    {
                        Arabalar.transform.GetChild(i).GetComponent<AudioSource>().enabled = false;
                    }

                }
            }
            if (karakter.activeSelf)
            {
                for (int i = 0; i < karakter.transform.childCount; i++)
                {
                    if (PlayerPrefs.GetString("ExternalSoundStatus") == "True")
                    {
                        if (i != sayi_kar)
                        {
                            karakter.transform.GetChild(i).GetComponent<AudioSource>().enabled = false;
                        }
                        karakter.transform.GetChild(sayi_kar).GetComponent<AudioSource>().enabled = true;
                    }
                    else
                    {
                        karakter.transform.GetChild(i).GetComponent<AudioSource>().enabled = false;
                    }

                }
            }
        }
        
        villageBestDistanceText.text = PlayerPrefs.GetInt("Skor01").ToString();
        desertBestDistanceText.text = PlayerPrefs.GetInt("Skor02").ToString();
        hillBestDistanceText.text = PlayerPrefs.GetInt("Skor03").ToString();
        snowBestDistanceText.text = PlayerPrefs.GetInt("Skor04").ToString();
        cityBestDistanceText.text = PlayerPrefs.GetInt("Skor05").ToString();


        villageTravelDistanceText.text = PlayerPrefs.GetInt("laspositionmap1").ToString();
        desertTravelDistanceText.text = PlayerPrefs.GetInt("laspositionmap2").ToString();
        hillTravelDistanceText.text = PlayerPrefs.GetInt("laspositionmap3").ToString();
        snowTravelDistanceText.text = PlayerPrefs.GetInt("laspositionmap4").ToString();
        cityTravelDistanceText.text = PlayerPrefs.GetInt("laspositionmap5").ToString();

        nitroPurshased = nitroNumber * nitroPrice;
        nitroNumberText.text = nitroNumber.ToString();
        nitroPriceText.text = nitroPurshased.ToString();
        totalNitroText.text = PlayerPrefs.GetInt("TotalNitro").ToString("N0");
    }


    public void Car_Right_Button()
    {

        deneme = true;
        turn.x = 0;
        if (sayi >= Arabalar.transform.childCount - 1)
        {
            sayi = -1;
        }
        sayi = sayi + 1;

        isim_araba_text.text = Arabalar.transform.GetChild(sayi).GetComponent<Ozellik>().isim.ToString();
        isim_araba_detay.text = Arabalar.transform.GetChild(sayi).GetComponent<Ozellik>().detay.ToString();

        for (int l = 0; l < 9; l++)
        {

            if (PlayerPrefs.GetInt("Upg1" + Arac_deger.ToString()) != 9)
            {

                Upg1.GetChild(1).GetChild(l).GetChild(1).gameObject.SetActive(false);
                if (l < 8)
                {
                    Upg1.GetChild(1).GetChild(l + 1).GetChild(0).gameObject.SetActive(false);
                }

            }

            if (PlayerPrefs.GetInt("Upg2" + Arac_deger.ToString()) != 9)
            {
                Upg2.GetChild(1).GetChild(l).GetChild(1).gameObject.SetActive(false);
                if (l < 8)
                {
                    Upg2.GetChild(1).GetChild(l + 1).GetChild(0).gameObject.SetActive(false);
                }

            }

            if (PlayerPrefs.GetInt("Upg3" + Arac_deger.ToString()) != 9)
            {
                Upg3.GetChild(1).GetChild(l).GetChild(1).gameObject.SetActive(false);
                if (l < 8)
                {
                    Upg3.GetChild(1).GetChild(l + 1).GetChild(0).gameObject.SetActive(false);
                }

            }

            if (PlayerPrefs.GetInt("Upg4" + Arac_deger.ToString()) != 9)
            {
                Upg4.GetChild(1).GetChild(l).GetChild(1).gameObject.SetActive(false);
                if (l < 8)
                {
                    Upg4.GetChild(1).GetChild(l + 1).GetChild(0).gameObject.SetActive(false);
                }

            }
        }
        //}  
    }
    public void Car_Left_Button()
    {

        deneme = true;
        turn.x = 0;
        if (sayi <= 0)
        {
            sayi = Arabalar.transform.childCount;
        }
        sayi = sayi - 1;
        //Arabalar.transform.GetChild (sayi).gameObject.SetActive (true);
        isim_araba_text.text = Arabalar.transform.GetChild(sayi).GetComponent<Ozellik>().isim.ToString();
        isim_araba_detay.text = Arabalar.transform.GetChild(sayi).GetComponent<Ozellik>().detay.ToString();

        for (int l = 0; l < 9; l++)
        {
            if (PlayerPrefs.GetInt("Upg1" + Arac_deger.ToString()) != 9)
            {

                Upg1.GetChild(1).GetChild(l).GetChild(1).gameObject.SetActive(false);
                if (l < 8)
                {
                    Upg1.GetChild(1).GetChild(l + 1).GetChild(0).gameObject.SetActive(false);
                }

            }

            if (PlayerPrefs.GetInt("Upg2" + Arac_deger.ToString()) != 9)
            {
                Upg2.GetChild(1).GetChild(l).GetChild(1).gameObject.SetActive(false);
                if (l < 8)
                {
                    Upg2.GetChild(1).GetChild(l + 1).GetChild(0).gameObject.SetActive(false);
                }

            }

            if (PlayerPrefs.GetInt("Upg3" + Arac_deger.ToString()) != 9)
            {
                Upg3.GetChild(1).GetChild(l).GetChild(1).gameObject.SetActive(false);
                if (l < 8)
                {
                    Upg3.GetChild(1).GetChild(l + 1).GetChild(0).gameObject.SetActive(false);
                }

            }

            if (PlayerPrefs.GetInt("Upg4" + Arac_deger.ToString()) != 9)
            {
                Upg4.GetChild(1).GetChild(l).GetChild(1).gameObject.SetActive(false);
                if (l < 8)
                {
                    Upg4.GetChild(1).GetChild(l + 1).GetChild(0).gameObject.SetActive(false);
                }

            }
        }
    }
    public void karakter_satin_al()
    {
        //for (int i = 0; i < karakter.transform.childCount; i++)
        //{
        if (karakter.transform.GetChild(sayi_kar).gameObject.activeSelf)
        {
            if (PlayerPrefs.GetInt("Money") >= karakter.transform.GetChild(sayi_kar).GetComponent<karakter_ozellik>().fiyat)
            {
                buysound.Play();
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - karakter.transform.GetChild(sayi_kar).GetComponent<karakter_ozellik>().fiyat);
                PlayerPrefs.SetInt("Karakterdeger" + sayi_kar, 1);
                PlayerPrefs.SetInt("Varsayilan_kar", sayi_kar);
                //characterBuyButton.SetActive(false);
            }
            else
            {
              
                  DontHaveMoney();
            }
        }
        //}
    }
   

    private void DontHaveMoney()
    {
        var DontMoney = Instantiate(m_DontHaveMoneyPopup, GameObject.Find("Canvas").GetComponent<RectTransform>(),
            worldPositionStays: false);
        DontMoney.transform.DOShakePosition(0.4f, 15);
    }
    public void _Buy()
    {

        if (Arabalar.transform.GetChild(sayi).gameObject.activeSelf)
        {
            if (PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(sayi).gameObject.GetComponent<Ozellik>().GenelPara)
            {
                buysound.Play();
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(sayi).gameObject.GetComponent<Ozellik>().GenelPara);
                PlayerPrefs.SetInt("Araba_Deger" + sayi, 1);
                PlayerPrefs.SetInt("Varsayilan", sayi);
                //carBuyWarningPanel.gameObject.SetActive(false);
            }
            else
            {

                    DontHaveMoney();
                    //carBuyWarningPanel.DOShakePosition(0.4f, 15);
                    
                   // carBuyWarningPanel.gameObject.SetActive(true);

            }
        }
    }

    public GameObject clickk;
    public void click()
    {
        if (PlayerPrefs.GetString("GameSoundStatus") == "True")
        {
            clickk.GetComponent<AudioSource>().Play();
        }
    }

    public void paraaaa()
    {
        PlayerPrefs.SetInt("Money", 555555555);
    }
    public void CoinReset()
    {
        PlayerPrefs.SetInt("Money", 0);
    }
    public void parasifirlaaaa()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            PlayerPrefs.SetInt("Money", 555555555);
        }
        if (Input.GetKey(KeyCode.W))
        {
            PlayerPrefs.SetInt("Money", 50);
        }
        if (Input.GetKey(KeyCode.E))
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 50);
        }


        //   characterBody[sayi_kar].transform.localPosition=Vector3.Lerp(characterBody[sayi_kar].transform.localPosition,new Vector3(1.2f,0,2),15*Time.deltaTime);
        if (bar.loadingRun == false)
        {
            if (Input.GetMouseButton(0) && (Arabalar.activeSelf || karakter.activeSelf))
            {

                turn.x -= Input.GetAxis("Mouse X");
                carBody[sayi].gameObject.transform.localRotation = Quaternion.Euler(0, turn.x * 10, 0);
                characterBody[sayi_kar].gameObject.transform.localRotation = Quaternion.Euler(0, turn.x * 15, 0);
            }
            else
            {
                carBody[sayi].gameObject.transform.GetChild(0).GetComponent<Animation>().Play();

            }

        }
        for (int i = 0; i < carBody.Length; i++) // Eray
        {
            if (i != sayi)
            {
                carBody[i].gameObject.transform.GetChild(0).GetComponent<Animation>().Stop();
                carBody[i].transform.Rotate(0, 0, 0);
                CarBackroundVideo[i].transform.GetChild(0).GetComponent<Canvas>().enabled = false;
            }
            else
            {
                CarBackroundVideo[sayi].transform.GetChild(0).GetComponent<Canvas>().enabled = true;
            }

        }

        //  for(int a = 0; a < characterBody.Length; a++) // Eray
        // {
        //        if (a != sayi_kar)
        //        characterBody[a].transform.localRotation = Quaternion.Euler(transform.rotation.y, turn.x * Time.smoothDeltaTime, 0);
        //        characterBody[a].transform.localPosition=Vector3.Lerp(characterBody[a].transform.localPosition,new Vector3(0,0,0),15*Time.deltaTime);
        // } 
        if (sayi == 10)
        {
            carRightButton.SetActive(false);
        }
        else if (sayi == 0)
        {
            carLeftButton.SetActive(false);
        }
        else
        {
            carRightButton.SetActive(true);
            carLeftButton.SetActive(true);
        }
        if (sayi_kar == 6)
        {
            characterRightButton.SetActive(false);
        }
        else if (sayi_kar == 0)
        {
            characterLeftButton.SetActive(false);
        }
        else
        {
            characterRightButton.SetActive(true);
            characterLeftButton.SetActive(true);
        }


        for (int i = 0; i < carImage.transform.childCount; i++)
        {
            carImage.transform.GetChild(i).gameObject.SetActive(false);
        }
        if (VehiclesPanel == true)
        {
            carImage.transform.GetChild(sayi).gameObject.SetActive(true);
            arabaZemin.transform.position = Vector3.Lerp(arabaZemin.transform.position, carWaypoints[sayi].transform.position, Time.deltaTime * carPositionSpeed);
        }
        else
        {

            arabaZemin.transform.position = Vector3.Lerp(arabaZemin.transform.position, carWaypoints[PlayerPrefs.GetInt("Varsayilan")].transform.position, Time.deltaTime * carPositionSpeed);
        }
        for (int i = 0; i < karakter.transform.childCount; i++)
        {
            characterImage.transform.GetChild(i).gameObject.SetActive(false);
        }
        if (karakter_panel == true)
        {
            characterImage.transform.GetChild(sayi_kar).gameObject.SetActive(true);
            characterZemin.transform.position = Vector3.Lerp(characterZemin.transform.position, characterWaypoints[sayi_kar].transform.position, Time.deltaTime * carPositionSpeed);
        }
        else
        {
            carImage.transform.GetChild(PlayerPrefs.GetInt("Varsayilan_kar")).gameObject.SetActive(true);
            characterZemin.transform.position = Vector3.Lerp(characterZemin.transform.position, characterWaypoints[PlayerPrefs.GetInt("Varsayilan_kar")].transform.position, Time.deltaTime * carPositionSpeed);

        }

        for (int i = 0; i < MissionsButtonLocket.Length; i++)
        {
            if (PlayerPrefs.GetInt("Completed_mission") < i)
            {
                MissionsButtonLocket[i].SetActive(true);
            }
            else
            {
                MissionsButtonLocket[i].SetActive(false);
            }
        }




    }

    void LateUpdate()
    {


        _totalCoin.text = PlayerPrefs.GetInt("Money").ToString("N0");


        for (int i = 0; i < Arabalar.transform.childCount; i++)
        {
            if (Arabalar.transform.GetChild(sayi).gameObject.activeSelf)
            {
                Arac_deger = Arabalar.transform.GetChild(sayi).GetSiblingIndex();

                if (PlayerPrefs.GetInt("Araba_Deger" + sayi) == 1)
                {

                    Upg1.gameObject.SetActive(true);
                    Upg2.gameObject.SetActive(true);
                    Upg3.gameObject.SetActive(true);
                    Upg4.gameObject.SetActive(true);

                    if (PlayerPrefs.GetInt("Upg1" + Arac_deger.ToString()) != 8)
                    {
                        EnginepriceText.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[PlayerPrefs.GetInt("Upg1" + Arac_deger.ToString())].ToString("N0");
                    }

                    for (int l = 0; l < PlayerPrefs.GetInt("CurrentUpg1" + (Arac_deger.ToString())); l++)
                    {
                        if (PlayerPrefs.GetInt("Upg1" + Arac_deger.ToString()) != 9)
                        {
                            Upg1.GetChild(1).GetChild(l).GetChild(1).gameObject.SetActive(true);
                            Upg1.GetChild(1).GetChild(l + 1).GetChild(0).gameObject.SetActive(true);
                        }
                    }
                    if (PlayerPrefs.GetInt("Upg1" + Arac_deger.ToString()) == 8)
                    {
                        EnginepriceText.text = "MAX";
                    }



                    if (PlayerPrefs.GetInt("Upg2" + Arac_deger.ToString()) != 8)
                    {
                        SusPansionPriceText.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[PlayerPrefs.GetInt("Upg2" + Arac_deger.ToString())].ToString("N0");
                    }

                    for (int l = 0; l < PlayerPrefs.GetInt("CurrentUpg2" + (Arac_deger.ToString())); l++)
                    {
                        if (PlayerPrefs.GetInt("Upg2" + Arac_deger.ToString()) != 9)
                        {
                            Upg2.GetChild(1).GetChild(l).GetChild(1).gameObject.SetActive(true);
                            Upg2.GetChild(1).GetChild(l + 1).GetChild(0).gameObject.SetActive(true);


                        }
                    }
                    if (PlayerPrefs.GetInt("Upg2" + Arac_deger.ToString()) == 8)
                    {
                        SusPansionPriceText.text = "MAX";
                    }


                    if (PlayerPrefs.GetInt("Upg3" + Arac_deger.ToString()) != 8)
                    {
                        FrictionPriceText.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[PlayerPrefs.GetInt("Upg3" + Arac_deger.ToString())].ToString("N0");
                    }


                    for (int l = 0; l < PlayerPrefs.GetInt("CurrentUpg3" + (Arac_deger.ToString())); l++)
                    {
                        if (PlayerPrefs.GetInt("Upg3" + Arac_deger.ToString()) != 9)
                        {
                            Upg3.GetChild(1).GetChild(l).GetChild(1).gameObject.SetActive(true);
                            Upg3.GetChild(1).GetChild(l + 1).GetChild(0).gameObject.SetActive(true);


                        }
                    }
                    if (PlayerPrefs.GetInt("Upg3" + Arac_deger.ToString()) == 8)
                    {
                        FrictionPriceText.text = "MAX";
                    }


                    if (PlayerPrefs.GetInt("Upg4" + Arac_deger.ToString()) != 8)
                    {
                        FuelTankPriceText.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[PlayerPrefs.GetInt("Upg4" + Arac_deger.ToString())].ToString("N0");
                    }


                    for (int l = 0; l < PlayerPrefs.GetInt("CurrentUpg4" + (Arac_deger.ToString())); l++)
                    {
                        if (PlayerPrefs.GetInt("Upg4" + Arac_deger.ToString()) != 9)
                        {
                            Upg4.GetChild(1).GetChild(l).GetChild(1).gameObject.SetActive(true);
                            Upg4.GetChild(1).GetChild(l + 1).GetChild(0).gameObject.SetActive(true);

                        }
                    }
                    if (PlayerPrefs.GetInt("Upg4" + Arac_deger.ToString()) == 8)
                    {
                        FuelTankPriceText.text = "MAX";
                    }

                    carBuyButton.gameObject.SetActive(false);
                    carSelectButton.gameObject.SetActive(true);
                    // CarPriceText.gameObject.SetActive(false);

                }
                else
                {
                    for (int j = 0; j < CarPriceText.Length; j++)
                    {
                        CarPriceText[j].text = Arabalar.transform.GetChild(sayi).GetComponent<Ozellik>().GenelPara.ToString("N0");
                    }


                    Upg1.gameObject.SetActive(false);
                    Upg2.gameObject.SetActive(false);
                    Upg3.gameObject.SetActive(false);
                    Upg4.gameObject.SetActive(false);
                    carBuyButton.gameObject.SetActive(true);
                    carSelectButton.gameObject.SetActive(false);
                    // CarPriceText.gameObject.SetActive(true);

                }
            }
        }
        for (int i = 0; i < karakter.transform.childCount; i++)
        {
            if (karakter.transform.GetChild(i).gameObject.activeSelf)
            {
                if (PlayerPrefs.GetInt("Karakterdeger" + sayi_kar) == 1)
                {//satin alinmissa

                    characterBuyButton.SetActive(false);
                    CharacterSelectButton.SetActive(true);
                    // fiyat_karakter_text.gameObject.SetActive(false);

                }
                else
                {
                    for (int j = 0; j < CharacterPriceText.Length; j++)
                    {
                        CharacterPriceText[j].text = karakter.transform.GetChild(sayi_kar).GetComponent<karakter_ozellik>().fiyat.ToString("N0");
                    }
                    characterBuyButton.SetActive(true);
                    CharacterSelectButton.SetActive(false);

                    //fiyat_karakter_text.gameObject.SetActive(true);

                }
            }
        }
    }
    public void Varsayilan()
    {
        PlayerPrefs.SetInt("Varsayilan", sayi);
        carSelectButton.gameObject.SetActive(false);
    }

    public GameObject Satin_al_emin;
    int temp_upgrade;
    bool upgradeTest;
    public void Upgrade_panel_ac(int i)
    {
        temp_upgrade = i;

        if (PlayerPrefs.GetInt("Upg1" + (Arac_deger)) > PlayerPrefs.GetInt("CurrentUpg1" + (Arac_deger.ToString())) && i == 1)
        {
            // currentUpgrade += 1;
            PlayerPrefs.SetInt("CurrentUpg1" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg1" + (Arac_deger.ToString())) + 1);
            Satin_al_emin.SetActive(false);
        }
        else
        {
            if (PlayerPrefs.GetInt("Upg1" + Arac_deger.ToString()) < 8 && i == 1)
            {
                if (PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[PlayerPrefs.GetInt("Upg1" + (Arac_deger.ToString()))])
                {
                    Satin_al_emin.SetActive(true);
                    if (PlayerPrefs.GetInt("Upg1" + (Arac_deger.ToString())) == 0)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[0].ToString("N0") + " COIN WILL BE USED FOR LEVEL 1 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg1" + (Arac_deger.ToString())) == 1)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[1].ToString("N0") + " COIN WILL BE USED FOR LEVEL 2 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg1" + (Arac_deger.ToString())) == 2)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[2].ToString("N0") + " COIN WILL BE USED FOR LEVEL 3 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg1" + (Arac_deger.ToString())) == 3)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[3].ToString("N0") + " COIN WILL BE USED FOR LEVEL 4 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg1" + (Arac_deger.ToString())) == 4)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[4].ToString("N0") + " COIN WILL BE USED FOR LEVEL 5 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg1" + (Arac_deger.ToString())) == 5)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[5].ToString("N0") + " COIN WILL BE USED FOR LEVEL 6 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg1" + (Arac_deger.ToString())) == 6)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[6].ToString("N0") + " COIN WILL BE USED FOR LEVEL 7 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg1" + (Arac_deger.ToString())) == 7)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[7].ToString("N0") + " COIN WILL BE USED FOR LEVEL 8 UPGRADE";
                    }
                    else
                    {
                        Satin_al_emin.SetActive(false);
                    }
                }
                else
                {
                    DontHaveMoney();
                    Satin_al_emin.SetActive(false);
                }
            }
        }


        if (PlayerPrefs.GetInt("Upg2" + (Arac_deger)) > PlayerPrefs.GetInt("CurrentUpg2" + (Arac_deger.ToString())) && i == 2)
        {

            PlayerPrefs.SetInt("CurrentUpg2" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg2" + (Arac_deger.ToString())) + 1);
            Satin_al_emin.SetActive(false);
        }
        else
        {

            if (PlayerPrefs.GetInt("Upg2" + Arac_deger.ToString()) < 8 && i == 2)
            {
                if (PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[PlayerPrefs.GetInt("Upg2" + (Arac_deger.ToString()))])
                {
                    Satin_al_emin.SetActive(true);
                    if (PlayerPrefs.GetInt("Upg2" + (Arac_deger.ToString())) == 0)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[0].ToString("N0") + " COIN WILL BE USED FOR LEVEL 1 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg2" + (Arac_deger.ToString())) == 1)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[1].ToString("N0") + " COIN WILL BE USED FOR LEVEL 2 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg2" + (Arac_deger.ToString())) == 2)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[2].ToString("N0") + " COIN WILL BE USED FOR LEVEL 3 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg2" + (Arac_deger.ToString())) == 3)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[3].ToString("N0") + " COIN WILL BE USED FOR LEVEL 4 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg2" + (Arac_deger.ToString())) == 4)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[4].ToString("N0") + " COIN WILL BE USED FOR LEVEL 5 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg2" + (Arac_deger.ToString())) == 5)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[5].ToString("N0") + " COIN WILL BE USED FOR LEVEL 6 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg2" + (Arac_deger.ToString())) == 6)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[6].ToString("N0") + " COIN WILL BE USED FOR LEVEL 7 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg2" + (Arac_deger.ToString())) == 7)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[7].ToString("N0") + " COIN WILL BE USED FOR LEVEL 8 UPGRADE";
                    }
                    else
                    {
                        Satin_al_emin.SetActive(false);
                    }
                }
                else
                {DontHaveMoney();
                    Satin_al_emin.SetActive(false);
                }
            }
        }


        if (PlayerPrefs.GetInt("Upg3" + (Arac_deger)) > PlayerPrefs.GetInt("CurrentUpg3" + (Arac_deger.ToString())) && i == 3)
        {
            // currentUpgrade += 1;
            PlayerPrefs.SetInt("CurrentUpg3" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg3" + (Arac_deger.ToString())) + 1);
            Satin_al_emin.SetActive(false);
        }
        else
        {


            if (PlayerPrefs.GetInt("Upg3" + Arac_deger.ToString()) < 8 && i == 3)
            {
                if (PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[PlayerPrefs.GetInt("Upg3" + (Arac_deger.ToString()))])
                {
                    Satin_al_emin.SetActive(true);
                    if (PlayerPrefs.GetInt("Upg3" + (Arac_deger.ToString())) == 0)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[0].ToString("N0") + " COIN WILL BE USED FOR LEVEL 1 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg3" + (Arac_deger.ToString())) == 1)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[1].ToString("N0") + " COIN WILL BE USED FOR LEVEL 2 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg3" + (Arac_deger.ToString())) == 2)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[2].ToString("N0") + " COIN WILL BE USED FOR LEVEL 3 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg3" + (Arac_deger.ToString())) == 3)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[3].ToString("N0") + " COIN WILL BE USED FOR LEVEL 4 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg3" + (Arac_deger.ToString())) == 4)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[4].ToString("N0") + " COIN WILL BE USED FOR LEVEL 5 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg3" + (Arac_deger.ToString())) == 5)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[5].ToString("N0") + " COIN WILL BE USED FOR LEVEL 6 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg3" + (Arac_deger.ToString())) == 6)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[6].ToString("N0") + " COIN WILL BE USED FOR LEVEL 7 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg3" + (Arac_deger.ToString())) == 7)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[7].ToString("N0") + " COIN WILL BE USED FOR LEVEL 8 UPGRADE";
                    }
                    else
                    {
                        Satin_al_emin.SetActive(false);
                    }
                }
                else
                {
                    DontHaveMoney();
                    Satin_al_emin.SetActive(false);
                }
            }
        }

        if (PlayerPrefs.GetInt("Upg4" + (Arac_deger)) > PlayerPrefs.GetInt("CurrentUpg4" + (Arac_deger.ToString())) && i == 4)
        {
            // currentUpgrade += 1;
            PlayerPrefs.SetInt("CurrentUpg4" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg4" + (Arac_deger.ToString())) + 1);
            Satin_al_emin.SetActive(false);
        }
        else
        {
            if (PlayerPrefs.GetInt("Upg4" + Arac_deger.ToString()) < 8 && i == 4)
            {
                if (PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[PlayerPrefs.GetInt("Upg4" + (Arac_deger.ToString()))])
                {
                    Satin_al_emin.SetActive(true);
                    if (PlayerPrefs.GetInt("Upg4" + (Arac_deger.ToString())) == 0)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[0].ToString("N0") + " COIN WILL BE USED FOR LEVEL 1 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg4" + (Arac_deger.ToString())) == 1)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[1].ToString("N0") + " COIN WILL BE USED FOR LEVEL 2 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg4" + (Arac_deger.ToString())) == 2)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[2].ToString("N0") + " COIN WILL BE USED FOR LEVEL 3 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg4" + (Arac_deger.ToString())) == 3)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[3].ToString("N0") + " COIN WILL BE USED FOR LEVEL 4 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg4" + (Arac_deger.ToString())) == 4)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[4].ToString("N0") + " COIN WILL BE USED FOR LEVEL 5 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg4" + (Arac_deger.ToString())) == 5)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[5].ToString("N0") + " COIN WILL BE USED FOR LEVEL 6 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg4" + (Arac_deger.ToString())) == 6)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[6].ToString("N0") + " COIN WILL BE USED FOR LEVEL 7 UPGRADE";
                    }
                    else if (PlayerPrefs.GetInt("Upg4" + (Arac_deger.ToString())) == 7)
                    {
                        onay_text.text = Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[7].ToString("N0") + " COIN WILL BE USED FOR LEVEL 8 UPGRADE";
                    }
                    else
                    {
                        Satin_al_emin.SetActive(false);
                    }
                }
                else
                {
                    DontHaveMoney();
                    Satin_al_emin.SetActive(false);
                }
            }
        }
    }
    public void Upgrade_panel_kapat()
    {
        /* Satin_al_emin.SetActive (false); */
    }

    public void UpgradeDownButton(int i)
    {
        if (i == 1)
        {
            if (0 < PlayerPrefs.GetInt("CurrentUpg1" + (Arac_deger.ToString())))
            {
                PlayerPrefs.SetInt("CurrentUpg1" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg1" + (Arac_deger.ToString())) - 1);
                Upg1.GetChild(1).GetChild(PlayerPrefs.GetInt("CurrentUpg1" + (Arac_deger.ToString())) + 1).GetChild(0).gameObject.SetActive(false);

                if (0 <= PlayerPrefs.GetInt("CurrentUpg1" + (Arac_deger.ToString())))
                {
                    Upg1.GetChild(1).GetChild(PlayerPrefs.GetInt("CurrentUpg1" + (Arac_deger.ToString()))).GetChild(1).gameObject.SetActive(false);

                }
            }
        }

        if (i == 2)
        {
            if (0 < PlayerPrefs.GetInt("CurrentUpg2" + (Arac_deger.ToString())))
            {
                PlayerPrefs.SetInt("CurrentUpg2" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg2" + (Arac_deger.ToString())) - 1);
                Upg2.GetChild(1).GetChild(PlayerPrefs.GetInt("CurrentUpg2" + (Arac_deger.ToString())) + 1).GetChild(0).gameObject.SetActive(false);

                if (0 <= PlayerPrefs.GetInt("CurrentUpg2" + (Arac_deger.ToString())))
                {
                    Upg2.GetChild(1).GetChild(PlayerPrefs.GetInt("CurrentUpg2" + (Arac_deger.ToString()))).GetChild(1).gameObject.SetActive(false);

                }
            }
        }

        if (i == 3)
        {
            if (0 < PlayerPrefs.GetInt("CurrentUpg3" + (Arac_deger.ToString())))
            {
                PlayerPrefs.SetInt("CurrentUpg3" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg3" + (Arac_deger.ToString())) - 1);
                Upg3.GetChild(1).GetChild(PlayerPrefs.GetInt("CurrentUpg3" + (Arac_deger.ToString())) + 1).GetChild(0).gameObject.SetActive(false);

                if (0 <= PlayerPrefs.GetInt("CurrentUpg3" + (Arac_deger.ToString())))
                {
                    Upg3.GetChild(1).GetChild(PlayerPrefs.GetInt("CurrentUpg3" + (Arac_deger.ToString()))).GetChild(1).gameObject.SetActive(false);

                }
            }
        }


        if (i == 4)
        {
            if (0 < PlayerPrefs.GetInt("CurrentUpg4" + (Arac_deger.ToString())))
            {
                PlayerPrefs.SetInt("CurrentUpg4" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg4" + (Arac_deger.ToString())) - 1);
                Upg4.GetChild(1).GetChild(PlayerPrefs.GetInt("CurrentUpg4" + (Arac_deger.ToString())) + 1).GetChild(0).gameObject.SetActive(false);

                if (0 <= PlayerPrefs.GetInt("CurrentUpg4" + (Arac_deger.ToString())))
                {
                    Upg4.GetChild(1).GetChild(PlayerPrefs.GetInt("CurrentUpg4" + (Arac_deger.ToString()))).GetChild(1).gameObject.SetActive(false);

                }
            }
        }

    }
    public void Upgrade()
    {

        if (PlayerPrefs.GetString("GameSoundStatus") == "True")
        {
            UpgradeSound[temp_upgrade - 1].gameObject.GetComponent<AudioSource>().enabled=true;
        }
        else
        {
            UpgradeSound[temp_upgrade - 1].gameObject.GetComponent<AudioSource>().enabled=false;
        }


        if (temp_upgrade == 1)
        {
            if (PlayerPrefs.GetInt("Upg1" + (Arac_deger.ToString())) == 0 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[0])
            {
                PlayerPrefs.SetInt("Upg1" + (Arac_deger.ToString()), 1);
                PlayerPrefs.SetInt("CurrentUpg1" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg1" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[0]);

            }
            else if (PlayerPrefs.GetInt("Upg1" + (Arac_deger.ToString())) == 1 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[1])
            {
                PlayerPrefs.SetInt("Upg1" + (Arac_deger.ToString()), 2);
                PlayerPrefs.SetInt("CurrentUpg1" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg1" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[1]);

            }
            else if (PlayerPrefs.GetInt("Upg1" + (Arac_deger.ToString())) == 2 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[2])
            {
                PlayerPrefs.SetInt("Upg1" + (Arac_deger.ToString()), 3);
                PlayerPrefs.SetInt("CurrentUpg1" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg1" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[2]);

            }
            else if (PlayerPrefs.GetInt("Upg1" + (Arac_deger.ToString())) == 3 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[3])
            {
                PlayerPrefs.SetInt("Upg1" + (Arac_deger.ToString()), 4);
                PlayerPrefs.SetInt("CurrentUpg1" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg1" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[3]);
            }
            else if (PlayerPrefs.GetInt("Upg1" + (Arac_deger.ToString())) == 4 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[4])
            {
                PlayerPrefs.SetInt("Upg1" + (Arac_deger.ToString()), 5);
                PlayerPrefs.SetInt("CurrentUpg1" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg1" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[4]);

            }
            else if (PlayerPrefs.GetInt("Upg1" + (Arac_deger.ToString())) == 5 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[5])
            {
                PlayerPrefs.SetInt("Upg1" + (Arac_deger.ToString()), 6);
                PlayerPrefs.SetInt("CurrentUpg1" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg1" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[5]);

            }
            else if (PlayerPrefs.GetInt("Upg1" + (Arac_deger.ToString())) == 6 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[6])
            {
                PlayerPrefs.SetInt("Upg1" + (Arac_deger.ToString()), 7);
                PlayerPrefs.SetInt("CurrentUpg1" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg1" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[6]);

            }
            else if (PlayerPrefs.GetInt("Upg1" + (Arac_deger.ToString())) == 7 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[7])
            {
                PlayerPrefs.SetInt("Upg1" + (Arac_deger.ToString()), 8);
                PlayerPrefs.SetInt("CurrentUpg1" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg1" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[7]);
            }

            else
            {
                Satin_al_emin.SetActive(false);
            }
        }

        if (temp_upgrade == 2)
        {
            if (PlayerPrefs.GetInt("Upg2" + (Arac_deger.ToString())) == 0 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[0])
            {
                PlayerPrefs.SetInt("Upg2" + (Arac_deger.ToString()), 1);
                PlayerPrefs.SetInt("CurrentUpg2" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg2" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[0]);
            }
            else if (PlayerPrefs.GetInt("Upg2" + (Arac_deger.ToString())) == 1 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[1])
            {
                PlayerPrefs.SetInt("Upg2" + (Arac_deger.ToString()), 2);
                PlayerPrefs.SetInt("CurrentUpg2" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg2" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[1]);
            }
            else if (PlayerPrefs.GetInt("Upg2" + (Arac_deger.ToString())) == 2 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[2])
            {
                PlayerPrefs.SetInt("Upg2" + (Arac_deger.ToString()), 3);
                PlayerPrefs.SetInt("CurrentUpg2" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg2" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[2]);

            }
            else if (PlayerPrefs.GetInt("Upg2" + (Arac_deger.ToString())) == 3 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[3])
            {
                PlayerPrefs.SetInt("Upg2" + (Arac_deger.ToString()), 4);
                PlayerPrefs.SetInt("CurrentUpg2" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg2" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[3]);
            }
            else if (PlayerPrefs.GetInt("Upg2" + (Arac_deger.ToString())) == 4 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[4])
            {
                PlayerPrefs.SetInt("Upg2" + (Arac_deger.ToString()), 5);
                PlayerPrefs.SetInt("CurrentUpg2" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg2" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[4]);
            }
            else if (PlayerPrefs.GetInt("Upg2" + (Arac_deger.ToString())) == 5 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[5])
            {
                PlayerPrefs.SetInt("Upg2" + (Arac_deger.ToString()), 6);
                PlayerPrefs.SetInt("CurrentUpg2" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg2" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[5]);
            }
            else if (PlayerPrefs.GetInt("Upg2" + (Arac_deger.ToString())) == 6 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[6])
            {
                PlayerPrefs.SetInt("Upg2" + (Arac_deger.ToString()), 7);
                PlayerPrefs.SetInt("CurrentUpg2" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg2" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[6]);

            }
            else if (PlayerPrefs.GetInt("Upg2" + (Arac_deger.ToString())) == 7 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[7])
            {
                PlayerPrefs.SetInt("Upg2" + (Arac_deger.ToString()), 8);
                PlayerPrefs.SetInt("CurrentUpg2" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg2" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[7]);
            }

            else
            {
                Satin_al_emin.SetActive(false);
            }
        }
        if (temp_upgrade == 3)
        {
            if (PlayerPrefs.GetInt("Upg3" + (Arac_deger.ToString())) == 0 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[0])
            {
                PlayerPrefs.SetInt("Upg3" + (Arac_deger.ToString()), 1);
                PlayerPrefs.SetInt("CurrentUpg3" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg3" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[0]);
            }

            else if (PlayerPrefs.GetInt("Upg3" + (Arac_deger.ToString())) == 1 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[1])
            {
                PlayerPrefs.SetInt("Upg3" + (Arac_deger.ToString()), 2);
                PlayerPrefs.SetInt("CurrentUpg3" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg3" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[1]);
            }

            else if (PlayerPrefs.GetInt("Upg3" + (Arac_deger.ToString())) == 2 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[2])
            {
                PlayerPrefs.SetInt("Upg3" + (Arac_deger.ToString()), 3);
                PlayerPrefs.SetInt("CurrentUpg3" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg3" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[2]);
            }

            else if (PlayerPrefs.GetInt("Upg3" + (Arac_deger.ToString())) == 3 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[3])
            {
                PlayerPrefs.SetInt("Upg3" + (Arac_deger.ToString()), 4);
                PlayerPrefs.SetInt("CurrentUpg3" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg3" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[3]);
            }

            else if (PlayerPrefs.GetInt("Upg3" + (Arac_deger.ToString())) == 4 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[4])
            {
                PlayerPrefs.SetInt("Upg3" + (Arac_deger.ToString()), 5);
                PlayerPrefs.SetInt("CurrentUpg3" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg3" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[4]);
            }

            else if (PlayerPrefs.GetInt("Upg3" + (Arac_deger.ToString())) == 5 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[5])
            {
                PlayerPrefs.SetInt("Upg3" + (Arac_deger.ToString()), 6);
                PlayerPrefs.SetInt("CurrentUpg3" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg3" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[5]);
            }

            else if (PlayerPrefs.GetInt("Upg3" + (Arac_deger.ToString())) == 6 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[6])
            {
                PlayerPrefs.SetInt("Upg3" + (Arac_deger.ToString()), 7);
                PlayerPrefs.SetInt("CurrentUpg3" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg3" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[6]);
            }

            else if (PlayerPrefs.GetInt("Upg3" + (Arac_deger.ToString())) == 7 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[7])
            {
                PlayerPrefs.SetInt("Upg3" + (Arac_deger.ToString()), 8);
                PlayerPrefs.SetInt("CurrentUpg3" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg3" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[7]);
            }
            else
            {

                Satin_al_emin.SetActive(false);
            }
        }
        if (temp_upgrade == 4)
        {
            if (PlayerPrefs.GetInt("Upg4" + (Arac_deger.ToString())) == 0 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[0])
            {
                PlayerPrefs.SetInt("Upg4" + (Arac_deger.ToString()), 1);
                PlayerPrefs.SetInt("CurrentUpg4" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg4" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[0]);
            }
            else if (PlayerPrefs.GetInt("Upg4" + (Arac_deger.ToString())) == 1 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[1])
            {
                PlayerPrefs.SetInt("Upg4" + (Arac_deger.ToString()), 2);
                PlayerPrefs.SetInt("CurrentUpg4" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg4" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[1]);
            }

            else if (PlayerPrefs.GetInt("Upg4" + (Arac_deger.ToString())) == 2 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[2])
            {
                PlayerPrefs.SetInt("Upg4" + (Arac_deger.ToString()), 3);
                PlayerPrefs.SetInt("CurrentUpg4" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg4" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[2]);
            }

            else if (PlayerPrefs.GetInt("Upg4" + (Arac_deger.ToString())) == 3 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[3])
            {
                PlayerPrefs.SetInt("Upg4" + (Arac_deger.ToString()), 4);
                PlayerPrefs.SetInt("CurrentUpg4" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg4" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[3]);
            }

            else if (PlayerPrefs.GetInt("Upg4" + (Arac_deger.ToString())) == 4 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[4])
            {
                PlayerPrefs.SetInt("Upg4" + (Arac_deger.ToString()), 5);
                PlayerPrefs.SetInt("CurrentUpg4" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg4" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[4]);
            }

            else if (PlayerPrefs.GetInt("Upg4" + (Arac_deger.ToString())) == 5 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[5])
            {
                PlayerPrefs.SetInt("Upg4" + (Arac_deger.ToString()), 6);
                PlayerPrefs.SetInt("CurrentUpg4" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg4" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[5]);
            }

            else if (PlayerPrefs.GetInt("Upg4" + (Arac_deger.ToString())) == 6 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[6])
            {
                PlayerPrefs.SetInt("Upg4" + (Arac_deger.ToString()), 7);
                PlayerPrefs.SetInt("CurrentUpg4" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg4" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[6]);
            }

            else if (PlayerPrefs.GetInt("Upg4" + (Arac_deger.ToString())) == 7 && PlayerPrefs.GetInt("Money") >= Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[7])
            {
                PlayerPrefs.SetInt("Upg4" + (Arac_deger.ToString()), 8);
                PlayerPrefs.SetInt("CurrentUpg4" + (Arac_deger.ToString()), PlayerPrefs.GetInt("CurrentUpg4" + (Arac_deger.ToString())) + 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - Arabalar.transform.GetChild(Arac_deger).GetComponent<Ozellik>().CarUpgradePrice[7]);
            }
            else
            {

                Satin_al_emin.SetActive(false);
            }
        }

    }


    public GameObject _carBuyPanel,_characterBuyPanel;
    public void PlayButton()
    {
        if (PlayerPrefs.GetInt("Varsayilan") != sayi)
        {
            _carBuyPanel.SetActive(true);
            _carBuyPanel.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = Arabalar.transform.GetChild(sayi).GetComponent<Ozellik>().isim.ToString();
            _carBuyPanel.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>().text = Arabalar.transform.GetChild(sayi).GetComponent<Ozellik>().detay.ToString();
        }
        if (PlayerPrefs.GetInt("Varsayilan_kar") != sayi_kar)
        {
            _characterBuyPanel.SetActive(true);
            _characterBuyPanel.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = karakter.transform.GetChild(sayi_kar).GetComponent<karakter_ozellik>().isim.ToString();
            _characterBuyPanel.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>().text = karakter.transform.GetChild(sayi_kar).GetComponent<karakter_ozellik>().detay.ToString();
        }
        if (PlayerPrefs.GetInt("Varsayilan") == sayi && PlayerPrefs.GetInt("Varsayilan_kar") == sayi_kar)
        {
          
            Arabalar.transform.GetChild(sayi).GetComponent<AudioSource>().enabled = false;
            karakter.transform.GetChild(sayi_kar).GetComponent<AudioSource>().enabled = false;

            loading_screen.SetActive(true);
            StartCoroutine(PlayButtonGetScene());
        }
         // m_AdContoroller.ShowInterstitialAd();
        // m_AdContoroller.RequestAndLoadRewardedAd();

    }
    IEnumerator PlayButtonGetScene()
    {
        yield return new WaitForSecondsRealtime(Random.Range(3,9));
        runscene(PlayerPrefs.GetInt("SaveMap"));

    }
    public void runscene(int i)
    {
        SceneManager.LoadScene(i);
    }
    public void single(int i)
    {
        PlayerPrefs.SetInt("Oyun_modu", 0);
        PlayerPrefs.SetInt("SaveMap", i);
    }

    public void vs(int i)
    {
        PlayerPrefs.SetInt("SaveMap", i);
        PlayerPrefs.SetInt("Oyun_modu", 1);
    }
    public void battle(int i)
    {
        PlayerPrefs.SetInt("SaveMap", i);
        PlayerPrefs.SetInt("Oyun_modu", 2);

    }
    public GameObject loading_screen;

   
   // Vector3 temp_karakter;
    public void _CharacterPanelOpen()
    {
        sayi = PlayerPrefs.GetInt("Varsayilan");
        carImage.transform.GetChild(sayi).gameObject.SetActive(true);
        turn.x = 0;
        karakter_panel.SetActive(true);
      //  temp_karakter = karakter.transform.position;

    }
    public void karakter_sec_geri()
    {
        karakter_panel.SetActive(false);
        VehiclesPanel.gameObject.SetActive(false);
        for (int i = 0; i < karakter.transform.childCount - 1; i++)
        {
            karakter.transform.GetChild(i).gameObject.SetActive(false);
        }
        Arabalar.transform.GetChild(PlayerPrefs.GetInt("Varsayilan")).gameObject.SetActive(true);
        karakter.transform.GetChild(PlayerPrefs.GetInt("Varsayilan_kar")).gameObject.SetActive(true);
        _2PBattlePanel.gameObject.SetActive(false);
        Single2.gameObject.SetActive(false);
        StagePanel.gameObject.SetActive(false);
        _4PBattlePanel.gameObject.SetActive(false);


    }

    public void karakter_varsayilan()
    {
        PlayerPrefs.SetInt("Varsayilan_kar", sayi_kar);
        carSelectButton.gameObject.SetActive(false);
    }

    public Text oyuncu_adi;
    public GameObject kayit_panel;
    public void kayit()
    {
        PlayerPrefs.SetString("OyuncuAdi", oyuncu_adi.text);
        kayit_panel.SetActive(false);
        PlayerPrefs.SetInt("Kayit", 1);
        //fotolar.SetActive(true);
    }



    void kilit_kontrol()
    {
        if (PlayerPrefs.GetInt("kilit_vs") == 1)
        {
            kilit_vs.SetActive(false);
        }
        if (PlayerPrefs.GetInt("kilit_bat") == 1)
        {
            kilit_bat.SetActive(false);
        }
        if (PlayerPrefs.GetInt("kilit_speed_sin") == 1)
        {
            kilit_speed_sin.SetActive(false);
        }
        if (PlayerPrefs.GetInt("kilit_hills_sin") == 1)
        {
            kilit_hills_sin.SetActive(false);
        }
        if (PlayerPrefs.GetInt("kilit_snow_sin") == 1)
        {
            kilit_snow_sin.SetActive(false);
        }
        if (PlayerPrefs.GetInt("kilit_house_sin") == 1)
        {
            kilit_city_sin.SetActive(false);
        }
        if (PlayerPrefs.GetInt("kilit_speed_vs") == 1)
        {
            kilit_speed_vs.SetActive(false);
        }
        if (PlayerPrefs.GetInt("kilit_hills_vs") == 1)
        {
            kilit_hills_vs.SetActive(false);
        }
        if (PlayerPrefs.GetInt("kilit_speed_vs") == 1)
        {
            kilit_speed_vs.SetActive(false);
        }
        if (PlayerPrefs.GetInt("kilit_snow_vs") == 1)
        {
            kilit_snow_vs.SetActive(false);
        }
        if (PlayerPrefs.GetInt("kilit_house_vs") == 1)
        {
            kilit_city_vs.SetActive(false);
        }
        if (PlayerPrefs.GetInt("kilit_speed_bat") == 1)
        {
            kilit_speed_bat.SetActive(false);
        }
        if (PlayerPrefs.GetInt("kilit_hills_bat") == 1)
        {
            kilit_hills_bat.SetActive(false);
        }
        if (PlayerPrefs.GetInt("kilit_snow_bat") == 1)
        {
            kilit_snow_bat.SetActive(false);
        }
        if (PlayerPrefs.GetInt("kilit_house_bat") == 1)
        {
            kilit_city_bat.SetActive(false);
        }
    }
    int deger;
    public void deger_gir(int i)
    {
        deger = i;
    }
    public void kilit_ac(int i)
    {

        if (i <= PlayerPrefs.GetInt("Money"))
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - i);
            if (deger == 0)
            {
                PlayerPrefs.SetInt("kilit_vs", 1);
            }
            if (deger == 1)
            {
                PlayerPrefs.SetInt("kilit_bat", 1);
            }
            if (deger == 2)
            {
                PlayerPrefs.SetInt("kilit_speed_sin", 1);
            }
            if (deger == 3)
            {
                PlayerPrefs.SetInt("kilit_hills_sin", 1);
            }
            if (deger == 4)
            {
                PlayerPrefs.SetInt("kilit_snow_sin", 1);
            }
            if (deger == 5)
            {
                PlayerPrefs.SetInt("kilit_house_sin", 1);
            }
            if (deger == 6)
            {
                PlayerPrefs.SetInt("kilit_speed_vs", 1);
            }
            if (deger == 7)
            {
                PlayerPrefs.SetInt("kilit_hills_vs", 1);
            }
            if (deger == 8)
            {
                PlayerPrefs.SetInt("kilit_snow_vs", 1);
            }
            if (deger == 9)
            {
                PlayerPrefs.SetInt("kilit_house_vs", 1);
            }
            if (deger == 10)
            {
                PlayerPrefs.SetInt("kilit_speed_bat", 1);
            }
            if (deger == 11)
            {
                PlayerPrefs.SetInt("kilit_hills_bat", 1);
            }
            if (deger == 12)
            {
                PlayerPrefs.SetInt("kilit_snow_bat", 1);
            }
            if (deger == 13)
            {
                PlayerPrefs.SetInt("kilit_house_bat", 1);
            }

        }
        else
        {
            DontHaveMoney();
        }

        kilit_kontrol();
    }


    public GameObject yetersiz_panel;


    public GameObject fotolar;
    int temp_foto = 0;
    public void foto_sec(int i)
    {

        temp_foto = i;
    }

    public void foto_kayit()
    {
        PlayerPrefs.SetInt("Foto", temp_foto);
        kayit_panel.SetActive(false);
        PlayerPrefs.SetInt("Kayit", 1);
    }


    public void missions_open()
    {
        PlayerPrefs.SetInt("Oyun_modu", 6);

    }
    public void missions_back()
    {

        missionsPanel.SetActive(false);
    }
    public void missionPanelBuy()
    {
        buysound.Play();
        if (PlayerPrefs.GetInt("Money") > 200000 && PlayerPrefs.GetInt("Mission_Buy") == 0)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 200000);
            missionsPanelButtoLocket.SetActive(false);
            PlayerPrefs.SetInt("Mission_Buy", 1);
        }
        if (PlayerPrefs.GetInt("Money") < 200000)
        {
            
        }

    }

    int missioon = 0;
    // public GameObject mission_go;
    public void mission_deg(int i)
    {
        missioon = i;
    }
    public void mission_xselect(int scenex)
    {




        PlayerPrefs.SetInt("SaveMap", scenex);
        PlayerPrefs.SetInt("Oyun_modu", 6);
        PlayerPrefs.SetInt("Mission", missioon);
        // mission_go.SetActive(true);


        if (PlayerPrefs.GetInt("Mission") == 0)
        {

            PlayerPrefs.SetInt("Tur", 2);//yarisi kazan
            PlayerPrefs.SetInt("Yapay_select", 1);

            //PlayerPrefs.SetInt("oyun_zaman",60);
            //PlayerPrefs.SetInt("yol_metre",500);
            //PlayerPrefs.SetInt("coins", 50);

            //PlayerPrefs.SetInt("particle", 20);
            PlayerPrefs.SetInt("Kazanil_money", 5000);

        }

        else if (PlayerPrefs.GetInt("Mission") == 1)
        {

            PlayerPrefs.SetInt("Tur", 1);// 120 snde 1500 coin puan topla

            PlayerPrefs.SetInt("oyun_zaman", 120);
            PlayerPrefs.SetInt("coins", 1500);

            PlayerPrefs.SetInt("Kazanil_money", 7000);

        }

        else if (PlayerPrefs.GetInt("Mission") == 2)
        {
            PlayerPrefs.SetInt("Tur", 3);// 40 snde  265 metre yol ilerle
            PlayerPrefs.SetInt("oyun_zaman", 40);
            PlayerPrefs.SetInt("yol_metre", 265);
            PlayerPrefs.SetInt("Kazanil_money", 10000);
        }

        else if (PlayerPrefs.GetInt("Mission") == 3)
        {

            PlayerPrefs.SetInt("Tur", 5);// 150 sn'de 10 particle topla";
            PlayerPrefs.SetInt("particle", 10);
            PlayerPrefs.SetInt("oyun_zaman", 150);
            PlayerPrefs.SetInt("Kazanil_money", 13000);
        }

        else if (PlayerPrefs.GetInt("Mission") == 4)
        {

            PlayerPrefs.SetInt("Tur", 2);//yarisi kazan
            PlayerPrefs.SetInt("Yapay_select", 3);
            PlayerPrefs.SetInt("Kazanil_money", 16000);
        }

        else if (PlayerPrefs.GetInt("Mission") == 5)
        {
            PlayerPrefs.SetInt("Tur", 3);// 40 snde  450 metre yol ilerle
            PlayerPrefs.SetInt("oyun_zaman", 40);
            PlayerPrefs.SetInt("yol_metre", 450);
            PlayerPrefs.SetInt("Kazanil_money", 18000);
        }

        else if (PlayerPrefs.GetInt("Mission") == 6)
        {

            PlayerPrefs.SetInt("Tur", 1);// 120 snde 3500 coin topla
            PlayerPrefs.SetInt("oyun_zaman", 120);
            PlayerPrefs.SetInt("coins", 3500);
            PlayerPrefs.SetInt("Kazanil_money", 20000);
        }

        else if (PlayerPrefs.GetInt("Mission") == 7)
        {

            PlayerPrefs.SetInt("Tur", 5);// 200 sn'de 20 particle topla";
            PlayerPrefs.SetInt("oyun_zaman", 200);
            PlayerPrefs.SetInt("particle", 20);
            PlayerPrefs.SetInt("yol_metre", 300);
            PlayerPrefs.SetInt("Kazanil_money", 22000);
        }

        else if (PlayerPrefs.GetInt("Mission") == 8)
        {
            PlayerPrefs.SetInt("Tur", 2);//yarisi kazan
            PlayerPrefs.SetInt("Yapay_select", 5);
            PlayerPrefs.SetInt("Kazanil_money", 24000);
        }

        else if (PlayerPrefs.GetInt("Mission") == 9)
        {
            PlayerPrefs.SetInt("Tur", 1);// 120 snde 5000 coin topla
            PlayerPrefs.SetInt("oyun_zaman", 120);
            PlayerPrefs.SetInt("coins", 5000);
            PlayerPrefs.SetInt("Kazanil_money", 26000);
        }

        else if (PlayerPrefs.GetInt("Mission") == 10)
        {
            PlayerPrefs.SetInt("Tur", 1);// 100 snde 4500 coin topla
            PlayerPrefs.SetInt("oyun_zaman", 100);
            PlayerPrefs.SetInt("coins", 4500);
            PlayerPrefs.SetInt("Kazanil_money", 28000);
        }

        else if (PlayerPrefs.GetInt("Mission") == 11)
        {
            PlayerPrefs.SetInt("Tur", 5);// 150 sn'de 23 particle topla";
            PlayerPrefs.SetInt("oyun_zaman", 120);
            PlayerPrefs.SetInt("particle", 23);
            PlayerPrefs.SetInt("Kazanil_money", 30000);
        }

        else if (PlayerPrefs.GetInt("Mission") == 12)
        {

            PlayerPrefs.SetInt("Tur", 2);//yarisi kazan
            PlayerPrefs.SetInt("Yapay_select", 7);
            PlayerPrefs.SetInt("Kazanil_money", 32000);
        }

        else if (PlayerPrefs.GetInt("Mission") == 13)
        {

            PlayerPrefs.SetInt("Tur", 2);//yarisi kazan
            PlayerPrefs.SetInt("Yapay_select", 8);
            PlayerPrefs.SetInt("Kazanil_money", 35000);
        }

        else if (PlayerPrefs.GetInt("Mission") == 14)
        {
            PlayerPrefs.SetInt("Tur", 5);// 120 sn'de 32 particle topla";
            PlayerPrefs.SetInt("oyun_zaman", 120);
            PlayerPrefs.SetInt("particle", 32);
            PlayerPrefs.SetInt("Kazanil_money", 38000);
        }

        else if (PlayerPrefs.GetInt("Mission") == 15)
        {
            PlayerPrefs.SetInt("Tur", 2);//yarisi kazan
            PlayerPrefs.SetInt("Yapay_select", 9);
            PlayerPrefs.SetInt("Kazanil_money", 42000);
        }

        else if (PlayerPrefs.GetInt("Mission") == 16)
        {
            PlayerPrefs.SetInt("Tur", 1);// 120 snde 8000 puan topla
            PlayerPrefs.SetInt("oyun_zaman", 120);
            PlayerPrefs.SetInt("coins", 8000);
            PlayerPrefs.SetInt("Kazanil_money", 45000);
        }

        else if (PlayerPrefs.GetInt("Mission") == 17)
        {
            PlayerPrefs.SetInt("Tur", 2);//yarisi kazan
            PlayerPrefs.SetInt("Yapay_select", 10);
            PlayerPrefs.SetInt("Kazanil_money", 50000);
        }



    }

    public void mission_son(int scenex)
    {

        PlayerPrefs.SetInt("SaveMap", scenex);

        /*  scenex = whatscene; */

        runscene(scenex);

    }
}
