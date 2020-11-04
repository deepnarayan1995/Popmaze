//using System.Collections;
//using UnityEngine;
//using GooglePlayGames;
//using GooglePlayGames.BasicApi;
//using GooglePlayGames.BasicApi.SavedGame;
//using System.Text;
//using UnityEngine.SocialPlatforms;

//public class GPGAuthentication : MonoBehaviour
//{
//    public static GPGAuthentication Instance { get; private set; }
//    const string SAVE_NAME = "Popmaze";
//    bool isSaving;
//    bool isCloudDataLoaded = false;

//    //public static PlayGamesPlatform platform;

//    public GPGAchievements Gpgac;
//    public StarLife life;
//    public MenuManager GM;

//    public GameObject ACVMTbtn, LDRBRDbtn, PLAYSbtn;

//    public GameObject playSignedPanel;

//    public SureToExitScript s2e;

//    public GameObject SignOutWarningPanel, warningHolder;

//    Vector3 presize, finalsize;

//    void Awake()
//    {
//        Instance = this;

//        if (!PlayerPrefs.HasKey(SAVE_NAME))
//        {
//            PlayerPrefs.SetString(SAVE_NAME, string.Empty);
//        }
//        if (!PlayerPrefs.HasKey("IsFirstTime"))
//        {
//            PlayerPrefs.SetInt("IsFirstTime", 1);
//        }
//        GM.LoadGameMenu();

//        presize.x = presize.y = presize.z = 1.1f;
//        finalsize.x = finalsize.y = finalsize.z = 1f;
//    }

//    void Start()
//    {        

//        if(Social.localUser.authenticated && !life.isManuallySignedOut)
//        {
//            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().
//                        EnableSavedGames().Build();
//            PlayGamesPlatform.InitializeInstance(config);
//            PlayGamesPlatform.Activate();

//            PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) =>
//            {
//                if (result == SignInStatus.Success)
//                {
//                    Social.Active.localUser.Authenticate(success =>
//                    {
//                        LoadData();
//                    });
//                    OnConnectionResponse(true);
//                    playSignedPanel.SetActive(true);
//                    s2e.isPlaypanelActive = true;
//                }
//                else if (result == SignInStatus.Failed)
//                {
//                    OnConnectionResponse(false);
//                    playSignedPanel.SetActive(false);
//                    s2e.isPlaypanelActive = false;
//                }
//            });
//        }
//        else
//        {
//            OnConnectionResponse(false);
//            playSignedPanel.SetActive(false);
//            s2e.isPlaypanelActive = false;
//        }        
//    }

//    #region Saved Games

//    string GameDataToString()
//    {
//        CloudVariables.FiveImportantValues[0] = life.isAdRemoved;
//        CloudVariables.FiveImportantValues[1] = life.isLimitlessUnlocked;
//        CloudVariables.FiveImportantValues[2] = life.diamonds;
//        CloudVariables.FiveImportantValues[3] = life.HighScore;
//        CloudVariables.FiveImportantValues[4] = life.totalClassicLocked;
//        return JsonUtil.CollectionToJsonString(CloudVariables.FiveImportantValues, "myKey");
//    }

//    void StringToGameData(string cloudData, string localData)
//    {
//        if(cloudData == string.Empty)
//        {
//            StringToGameData(localData);
//            isCloudDataLoaded = true;
//            return;
//        }

//        int[] cloudArray = JsonUtil.JsonStringToArray(cloudData, "myKey", str => int.Parse(str));

//        if(localData == string.Empty)
//        {
//            CloudVariables.FiveImportantValues = cloudArray;
//            PlayerPrefs.SetString(SAVE_NAME, cloudData);
//            isCloudDataLoaded = true;
//            return;
//        }

//        int[] localArray = JsonUtil.JsonStringToArray(localData, "myKey", str => int.Parse(str));

//        if (PlayerPrefs.GetInt("IsFirstTime") == 1)
//        {
//            PlayerPrefs.SetInt("IsFirstTime", 0);

//            if (cloudArray[0] > localArray[0])
//            {
//                PlayerPrefs.SetString(SAVE_NAME, cloudData);
//                life.isAdRemoved = cloudArray[0];
//            }
//            if (cloudArray[1] > localArray[1])
//            {
//                PlayerPrefs.SetString(SAVE_NAME, cloudData);
//                life.isLimitlessUnlocked = cloudArray[1];
//            }
//            if (cloudArray[2] > localArray[2])
//            {
//                PlayerPrefs.SetString(SAVE_NAME, cloudData);
//                life.diamonds = cloudArray[2];
//            }
//            if (cloudArray[3] > localArray[3])
//            {
//                PlayerPrefs.SetString(SAVE_NAME, cloudData);
//                life.HighScore = cloudArray[3];
//            }
//            if (cloudArray[4] < localArray[4])
//            {
//                PlayerPrefs.SetString(SAVE_NAME, cloudData);
//                life.totalClassicLocked = cloudArray[4];
//            }
//            GM.SaveGameMenu();
//        }

//        else
//        {
//            if (localArray[0] > cloudArray[0])
//            {
//                CloudVariables.FiveImportantValues[0] = localArray[0];
//                life.isAdRemoved = localArray[0];
//            }
//            if (localArray[1] > cloudArray[1])
//            {
//                CloudVariables.FiveImportantValues[1] = localArray[1];
//                life.isLimitlessUnlocked = localArray[1];
//            }
//            if (localArray[2] > cloudArray[2])
//            {
//                CloudVariables.FiveImportantValues[2] = localArray[2];
//                life.diamonds = localArray[2];
//            }
//            if (localArray[3] > cloudArray[3])
//            {
//                CloudVariables.FiveImportantValues[3] = localArray[3];
//                life.HighScore = localArray[3];
//            }
//            if (localArray[4] < cloudArray[4])
//            {
//                CloudVariables.FiveImportantValues[4] = localArray[4];
//                life.totalClassicLocked = localArray[4];
                
//            }
//            isCloudDataLoaded = true;
//            SaveData();
//            return;
//        }

//        CloudVariables.FiveImportantValues = cloudArray;
//        life.isAdRemoved = CloudVariables.FiveImportantValues[0];
//        life.isLimitlessUnlocked = CloudVariables.FiveImportantValues[1];
//        life.diamonds = CloudVariables.FiveImportantValues[2];
//        life.HighScore = CloudVariables.FiveImportantValues[3];
//        life.totalClassicLocked = CloudVariables.FiveImportantValues[4];
//        GM.SaveGameMenu();
//        isCloudDataLoaded = true;
//    }

//    void StringToGameData(string localData)
//    {
//        if(localData != string.Empty)
//        {
//            CloudVariables.FiveImportantValues = JsonUtil.JsonStringToArray(localData, "myKey", str => int.Parse(str));
//            life.isAdRemoved = CloudVariables.FiveImportantValues[0];
//            life.isLimitlessUnlocked = CloudVariables.FiveImportantValues[1];
//            life.diamonds = CloudVariables.FiveImportantValues[2];
//            life.HighScore = CloudVariables.FiveImportantValues[3];
//            life.totalClassicLocked = CloudVariables.FiveImportantValues[4];
//            GM.SaveGameMenu();
//        }
//    }

//    public void LoadData()
//    {
//        if(Social.localUser.authenticated)
//        {
//            isSaving = false;
//            ((PlayGamesPlatform)Social.Active).SavedGame.OpenWithManualConflictResolution(SAVE_NAME,
//                DataSource.ReadCacheOrNetwork, true, ResolveConflict, OnSavedGameOpened);
//        }
//        else
//        {
//            LoadLocal();
//        }
//    }

//    private void LoadLocal()
//    {        
//        StringToGameData(PlayerPrefs.GetString(SAVE_NAME));
//        GM.LoadGameMenu();
//    }

//    public void SaveData()
//    {
//        if(!isCloudDataLoaded)
//        {
//            SaveLocal();
//            return;
//        }
//        if (Social.localUser.authenticated)
//        {
//            isSaving = true;
//            ((PlayGamesPlatform)Social.Active).SavedGame.OpenWithManualConflictResolution(SAVE_NAME,
//                DataSource.ReadCacheOrNetwork, true, ResolveConflict, OnSavedGameOpened);
//        }
//        else
//        {
//            SaveLocal();
//        }
//    }

//    private void SaveLocal()
//    {
//        PlayerPrefs.SetString(SAVE_NAME, GameDataToString());

//        life.isAdRemoved = CloudVariables.FiveImportantValues[0];
//        life.isLimitlessUnlocked = CloudVariables.FiveImportantValues[1];
//        life.diamonds = CloudVariables.FiveImportantValues[2];
//        life.HighScore = CloudVariables.FiveImportantValues[3];
//        life.totalClassicLocked = CloudVariables.FiveImportantValues[4];
//        GM.SaveGameMenu();
//    }

//    private void ResolveConflict(IConflictResolver resolver, ISavedGameMetadata original, byte[] originalData,
//        ISavedGameMetadata unmerged, byte[] unmergedData)
//    {
//        if (originalData == null)
//            resolver.ChooseMetadata(unmerged);
//        else if (unmergedData == null)
//            resolver.ChooseMetadata(original);
//        else
//        {
//            string originalSTR = Encoding.ASCII.GetString(originalData);
//            string unmergedSTR = Encoding.ASCII.GetString(unmergedData);

//            int[] originalArr = JsonUtil.JsonStringToArray(originalSTR, "myKey", str => int.Parse(str));
//            int[] unmergedArr = JsonUtil.JsonStringToArray(unmergedSTR, "myKey", str => int.Parse(str));

//            for(int i=0; i < originalArr.Length - 1; i++)
//            {
//                if (originalArr[i] > unmergedArr[i])
//                {
//                    resolver.ChooseMetadata(original);
//                }
//                else if (unmergedArr[i] > originalArr[i])
//                {
//                    resolver.ChooseMetadata(unmerged);
//                }
//            }
//            if (originalArr[originalArr.Length - 1] < unmergedArr[originalArr.Length - 1])
//            {
//                resolver.ChooseMetadata(original);
//            }
//            else if (unmergedArr[originalArr.Length - 1] < originalArr[originalArr.Length - 1])
//            {
//                resolver.ChooseMetadata(unmerged);
//            }
//            else
//            {
//                resolver.ChooseMetadata(original);
//            }            
//        }
//    }

//    private void OnSavedGameOpened(SavedGameRequestStatus status, ISavedGameMetadata game)
//    {
//        if(status == SavedGameRequestStatus.Success)
//        {
//            if (!isSaving)
//                LoadGame(game);
//            else
//                StartCoroutine(SaveGame(game));
//        }
//        else
//        {
//            if (!isSaving)
//                LoadLocal();
//            else
//                SaveLocal();
//        }
//    }

//    private void LoadGame(ISavedGameMetadata game)
//    {
//        ((PlayGamesPlatform)Social.Active).SavedGame.ReadBinaryData(game, OnSavedGameDataRead);
//    }
//    private IEnumerator SaveGame(ISavedGameMetadata game)
//    {
//        string stringToSave = GameDataToString();
//        PlayerPrefs.SetString(SAVE_NAME, stringToSave);

//        life.isAdRemoved = CloudVariables.FiveImportantValues[0];
//        life.isLimitlessUnlocked = CloudVariables.FiveImportantValues[1];
//        life.diamonds = CloudVariables.FiveImportantValues[2];
//        life.HighScore = CloudVariables.FiveImportantValues[3];
//        life.totalClassicLocked = CloudVariables.FiveImportantValues[4];
//        GM.SaveGameMenu();

//        byte[] dataToSave = Encoding.ASCII.GetBytes(stringToSave);
//        SavedGameMetadataUpdate update = new SavedGameMetadataUpdate.Builder().Build();

//        yield return new WaitForSeconds(1f);
//        ((PlayGamesPlatform)Social.Active).SavedGame.CommitUpdate(game, update, dataToSave, OnSavedGameDataWritten);
        
//    }

//    private void OnSavedGameDataRead(SavedGameRequestStatus status, byte[] savedData)
//    {
//        if(status == SavedGameRequestStatus.Success)
//        {
//            string cloudDataString;
//            if (savedData.Length == 0)
//                cloudDataString = string.Empty;
//            else
//                cloudDataString = Encoding.ASCII.GetString(savedData);

//            string localDataString = PlayerPrefs.GetString(SAVE_NAME);
//            StringToGameData(cloudDataString, localDataString);
//        }
//    }

//    private void OnSavedGameDataWritten(SavedGameRequestStatus status, ISavedGameMetadata game)
//    {

//    }


//    #endregion


//    #region Button Clicks
//    public void OnButtonClickPlayService()
//    {
//        if(Social.localUser.authenticated)
//        {
//            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().
//                        EnableSavedGames().Build();
//            PlayGamesPlatform.InitializeInstance(config);
//            PlayGamesPlatform.Activate();

//            PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptAlways, (result) =>
//            {
//                if (result == SignInStatus.Success)
//                {
//                    Social.Active.localUser.Authenticate(success =>
//                    {
//                        LoadData();
//                    });
//                    OnConnectionResponse(true);
//                    playSignedPanel.SetActive(true);
//                    s2e.isPlaypanelActive = true;
//                    life.isManuallySignedOut = false;
//                    Gpgac.CheckInternetandSendACM();
//                }
//                else if (result == SignInStatus.Failed)
//                {
//                    OnConnectionResponse(false);
//                    playSignedPanel.SetActive(false);
//                    s2e.isPlaypanelActive = false;
//                }
//            });
//        }
        
//        GM.SaveGameMenu();
//    }
//    private void OnConnectionResponse(bool authenticated)
//    {
//        if(authenticated)
//        {
//            ACVMTbtn.SetActive(true);
//            LDRBRDbtn.SetActive(true);
//            PLAYSbtn.SetActive(false);
//        }
//        else
//        {
//            ACVMTbtn.SetActive(false);
//            LDRBRDbtn.SetActive(false);
//            PLAYSbtn.SetActive(true);
//        }
//    }
//    public void OpenSignOutWarning()
//    {
//        SignOutWarningPanel.SetActive(true);
//        StartCoroutine("OpenSOWR");
//    }
//    IEnumerator OpenSOWR()
//    {
//        LeanTween.scale(warningHolder, presize, 0.35f);
//        yield return new WaitForSeconds(0.35f);
//        LeanTween.scale(warningHolder, finalsize, 0.15f);
//    }
//    public void CloseSignOutWarning()
//    {
//        StartCoroutine("closeSOWR");
//    }
//    IEnumerator closeSOWR()
//    {
//        LeanTween.scale(warningHolder, presize, 0.15f);
//        yield return new WaitForSeconds(0.15f);
//        LeanTween.scale(warningHolder, Vector3.zero, 0.35f);
//        yield return new WaitForSeconds(0.35f);
//        SignOutWarningPanel.SetActive(false);
//    }
//    public void SignOutFromPlay()
//    {
//        PlayGamesPlatform.Instance.SignOut();
//        life.isManuallySignedOut = true;
//        GM.SaveGameMenu();
//        OnConnectionResponse(false);
//        StartCoroutine("DisappearPlayPanel");
//    }
//    IEnumerator DisappearPlayPanel()
//    {
//        LeanTween.scale(warningHolder, presize, 0.15f);
//        yield return new WaitForSeconds(0.15f);
//        LeanTween.scale(warningHolder, Vector3.zero, 0.35f);
//        yield return new WaitForSeconds(0.35f);
//        SignOutWarningPanel.SetActive(false);

//        LeanTween.moveLocalY(playSignedPanel, 217f, 0.3f);
//        yield return new WaitForSeconds(0.3f);
//        playSignedPanel.SetActive(false);
//        s2e.isPlaypanelActive = false;
//    }
//    #endregion
//}
