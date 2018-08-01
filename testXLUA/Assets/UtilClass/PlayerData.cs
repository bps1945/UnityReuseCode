using UnityEngine;
using System.Collections;
using System.Text;
/**************************
 * UserDefault Operations
***************************/


public class PlayerData {

	const string CONST_KEY_HAS_EVER_LAUNCH="CONST_KEY_HAS_EVER_LAUNCH";

	//const string CONST_KEY_STAR_NUM="CONST_KEY_STAR_NUM";

	const string CONST_KEY_STAR_NUM="CONST_KEY_ARMY_NUM";

	const string CONST_KEY_STORY_EVER_READ="CONST_KEY_STORY_EVER_READ";

	const string CONST_KEY_GAME_EVER_WON="CONST_KEY_GAME_EVER_WON";


	const string CONST_KEY_COIN_NUM="CONST_KEY_COIN_NUM";


	//const string CONST_KEY_UNLOCKED_LEVEL_NUM="CONST_KEY_UNLOCKED_LEVEL_NUM";
	const string CONST_KEY_PLAYER_UNLOCK = "CONST_KEY_PLAYER_UNLOCK";

	const string CONST_KEY_LAST_PLAYER_SELECT_INDEX = "CONST_KEY_LAST_PLAYER_SELECT_INDEX";

	const string CONST_KEY_LEVEL_WON="CONST_KEY_LEVEL_WON";

	const string CONST_KEY_HAS_EVER_PAID = "CONST_KEY_HAS_EVER_PAID";

	const string CONST_KEY_GAME_LAUNCHED_TIMES = "CONST_KEY_GAME_LAUNCHED_TIMES";

	const string CONST_KEY_EVER_RATED = "CONST_KEY_EVER_RATED";

	const string CONST_KEY_NG_ALERT_LAST_FETCH_DATE = "CONST_KEY_NG_ALERT_LAST_FETCH_DATE";

	const string CONST_KEY_LOCAL_NG_ALERT_VERSION = "CONST_KEY_LOCAL_NG_ALERT_VERSION";

	const string CONST_KEY_NG_ALERT_EVER_READ = "CONST_KEY_NG_ALERT_EVER_READ";

	const string CONST_KEY_IS_BGM_ON = "CONST_KEY_IS_BGM_ON";
	const string CONST_KEY_IS_SFX_ON = "CONST_KEY_IS_SFX_ON";

	//----------------------------------------------------------
	const string CONST_KEY_BGM_VOLUMN = "CONST_KEY_BGM_VOLUMN";
	const string CONST_KEY_SFX_VOLUMN = "CONST_KEY_SFX_VOLUMN";


    const string CONST_KEY_LOGGED_IN_SERVER_IDS = "CONST_KEY_LOGGED_IN_SERVER_IDS";

    private static void SetIntArray(string key,int[]intArray)
    {
        StringBuilder stringBuilder = new StringBuilder();
        for(int i=0;i<intArray.Length;i++)
        {
            int num = intArray[i];
            stringBuilder.Append(num);
            if (i != intArray.Length - 1)
            {
                stringBuilder.Append(",");
            }
        }
        PlayerPrefs.SetString(key,stringBuilder.ToString());
    }

    private static int[] GetIntArray(string key)
    {
        string arrayString= PlayerPrefs.GetString(key);
        string[] strArray=arrayString.Split(new char[1]{','});
        int[] intArray=new int[strArray.Length];
        for (int i = 0; i < strArray.Length; i++)
        {
            intArray[i] = int.Parse(strArray[i]);
        }
        return intArray;
    }


	public static bool IsFirstLaunch()
	{
		return !PlayerPrefs.HasKey (CONST_KEY_HAS_EVER_LAUNCH);
	}

	public static void SetFirstLaunchFalse()
	{
		PlayerPrefs.SetInt (CONST_KEY_HAS_EVER_LAUNCH, 1);
	}
		
	//specific game logic

	public static void InitData()
	{
		if (IsFirstLaunch ())
		{
			//InitStarNum ();

			SetFirstLaunchFalse ();
		}

		//PlayerPrefs.DeleteAll ();
	}



	public static void MockUpTestData()
	{
		PlayerPrefs.DeleteAll ();
		//InitStarNum ();
	}

	public static bool HasStoryEverRead()
	{
		return 1==PlayerPrefs.GetInt (CONST_KEY_STORY_EVER_READ);
	}

	public static void SetStoryEverRead()
	{
		PlayerPrefs.SetInt (CONST_KEY_STORY_EVER_READ, 1);
	}

	public static string GetLastFetchDateStr()
	{
		return PlayerPrefs.GetString (CONST_KEY_NG_ALERT_LAST_FETCH_DATE);
	}

	public static void SetLastFetchDateStr(string str)
	{
		PlayerPrefs.SetString (CONST_KEY_NG_ALERT_LAST_FETCH_DATE, str);
	}

	//
	public static int GetLocalNGAlertVersionNum()
	{
		return PlayerPrefs.GetInt (CONST_KEY_LOCAL_NG_ALERT_VERSION);
	}

	public static void SetLocalNGAlertVersionNum(int versionNum)
	{
		PlayerPrefs.SetInt (CONST_KEY_LOCAL_NG_ALERT_VERSION,versionNum);
	}
		
	public static int GetCoinNum()
	{
		return PlayerPrefs.GetInt (CONST_KEY_COIN_NUM);
	}

	public static void SetCoinNum(int num)
	{
		PlayerPrefs.SetInt(CONST_KEY_COIN_NUM,num);
	}

	public static int GetLastSelectedPlayerIndex()
	{
		return PlayerPrefs.GetInt (CONST_KEY_LAST_PLAYER_SELECT_INDEX);
	}

	public static void SetLastSelectedPlayerIndex(int index)
	{
		PlayerPrefs.SetInt (CONST_KEY_LAST_PLAYER_SELECT_INDEX,index);
	}

	//CONST_KEY_LAST_PLAYER_SELECT_INDEX

	public static void SetPlayerUnlock(int index)
	{
		string theKey=CONST_KEY_PLAYER_UNLOCK+index.ToString();
		PlayerPrefs.SetInt(theKey,1);
	}

	public static void SetPlayerLocked(int index)
	{
		string theKey=CONST_KEY_PLAYER_UNLOCK+index.ToString();
		PlayerPrefs.SetInt(theKey,0);
	}

	public static bool GetPlayerUnlock(int index)
	{
		string theKey=CONST_KEY_PLAYER_UNLOCK+index.ToString();
		return (1==PlayerPrefs.GetInt (theKey));
	}
		
	public static void SetLevelWon(int index){
		string theKey=CONST_KEY_LEVEL_WON+index.ToString();
		PlayerPrefs.SetInt(theKey,1);
	}

	public static bool GetLevelWon(int index){
		string theKey=CONST_KEY_LEVEL_WON+index.ToString();
		return (1==PlayerPrefs.GetInt (theKey));
	}


		
	//CONST_KEY_GAME_EVER_WIN
	public static void SetStoryWinEverRead(){
		PlayerPrefs.SetInt (CONST_KEY_STORY_EVER_READ,1);
	}

	public static bool GetStotyWinEverRead(){
		return (1==PlayerPrefs.GetInt (CONST_KEY_STORY_EVER_READ));
	}

	public static void EverWonClear()
	{
		PlayerPrefs.SetInt (CONST_KEY_GAME_EVER_WON,0);
	}

	public static bool HasEverPaidMoney()
	{
		int hasPaid = PlayerPrefs.GetInt (CONST_KEY_HAS_EVER_PAID);
		bool result = (1 == hasPaid);
		return result;	
	}

	public static void SetEverPaidMoney()
	{
		PlayerPrefs.SetInt (CONST_KEY_HAS_EVER_PAID,1);
	}

	//CONST_KEY_GAME_LAUNCHED_TIME

	public static void SetGameLaunchedTimes(int times)
	{
		PlayerPrefs.SetInt (CONST_KEY_GAME_LAUNCHED_TIMES,times);
	}

	public static int GetGameLaunchedTimes()
	{
		return PlayerPrefs.GetInt (CONST_KEY_GAME_LAUNCHED_TIMES);
	}

	public static void LaunchedTimesClearZero()
	{
		PlayerPrefs.SetInt (CONST_KEY_GAME_LAUNCHED_TIMES,0);
	}

	//CONST_KEY_NEVER_POP_UP_RATE

	public static bool HasEverRated()
	{
		return (1==PlayerPrefs.GetInt (CONST_KEY_EVER_RATED));	
	}

	public static void SetHasEverRated()
	{
		PlayerPrefs.SetInt (CONST_KEY_EVER_RATED,1);
	}

	//
	public static void SetNewGameAlertEverRead(bool hasRead)
	{
		int intValue = 0;
		if (hasRead) {
			intValue = 1;
		}
		PlayerPrefs.SetInt (CONST_KEY_NG_ALERT_EVER_READ,intValue);
	}

	public static bool GetNewGameAlertEverRead()
	{
		return (1 == PlayerPrefs.GetInt(CONST_KEY_NG_ALERT_EVER_READ));
	}

	public static bool GetBGMOn()
	{
		return PlayerPrefs.HasKey (CONST_KEY_IS_BGM_ON);
	}

	public static bool GetSFXOn()
	{
		return PlayerPrefs.HasKey (CONST_KEY_IS_SFX_ON);
	}

	public static void SetBGMOn(bool enable)
	{
		if (enable) {
			PlayerPrefs.SetInt (CONST_KEY_IS_BGM_ON,1);
		} else {
			PlayerPrefs.DeleteKey (CONST_KEY_IS_BGM_ON);
		}
	}

	public static void SetSFXOn(bool enable)
	{
		if (enable) {
			PlayerPrefs.SetInt (CONST_KEY_IS_SFX_ON , 1);
		} else {
			PlayerPrefs.DeleteKey (CONST_KEY_IS_SFX_ON);
		}
	}


	public static void SetBGMVolumn(float bgmVolumn)
	{
		PlayerPrefs.SetFloat (CONST_KEY_BGM_VOLUMN,bgmVolumn);
	}

	public static float GetBGMVolumn()
	{
		return PlayerPrefs.GetFloat(CONST_KEY_BGM_VOLUMN);
	}

	public static void SetSFXVolumn(float sfxVolumn)
	{
		PlayerPrefs.SetFloat (CONST_KEY_SFX_VOLUMN,sfxVolumn);
	}

	public static float GetSFXVolumn()
	{
		return PlayerPrefs.GetFloat(CONST_KEY_SFX_VOLUMN);
	}

    public static void SetLoggedInServerIDs(int[]ids)
    { 
        SetIntArray(CONST_KEY_LOGGED_IN_SERVER_IDS,ids);
    }

    public static int[] GetLoggedInServerIDs()
    {
        return GetIntArray(CONST_KEY_LOGGED_IN_SERVER_IDS);
    }

}
