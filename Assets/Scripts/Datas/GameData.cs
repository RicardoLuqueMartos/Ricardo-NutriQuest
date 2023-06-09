//using OpenCover.Framework.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameData : ScriptableObject
{
    #region Variables
    [SerializeField]
    int PerfectNoteAmountToFastFire = 5;
    public int _PerfectNoteAmountToFastFire { get { return PerfectNoteAmountToFastFire; } }
   
    [SerializeField]
    int PerfectNoteAmountToTurboFire = 10;
    public int _PerfectNoteAmountToTurboFire { get { return PerfectNoteAmountToTurboFire; } }

    [SerializeField]
    PlayerData player; 
    public PlayerData _player { get { return player; } }

    [SerializeField]
    UIData uI;
    public UIData _uI { get { return uI; } }


    [Serializable]
    public class ContentData
    {
        [SerializeField]
        public List<LevelData> levelsList;
     //   public List<LevelData> _levelsList { get { return levelsList; } }

        [SerializeField]
        public List<WeaponData> weaponsList;
   //     public List<WeaponData> _weaponsList { get { return weaponsList; } }
     
        [SerializeField]
        public List<EnemyData> enemiesList;
        //   public List<EnemyData> _enemiesList { get { return enemiesList; } }
       

    }
    [SerializeField]
    ContentData gameContent = new ContentData();
    public ContentData _gameContent { get { return gameContent; } }

    #endregion Variables

#if UNITY_EDITOR

    [MenuItem("Window/MyEditor/Detect All Datas")]
    public void DetectAllDatas()
    {
        InitLists();

        DetectAllWeaponsDatas();
        DetectAllEnemysDatas();
        DetectAllLevelsDatas();

        Save();
    }

    void InitLists()
    {
   
        if (gameContent.weaponsList == null)
            gameContent.weaponsList = new List<WeaponData>();
        if (gameContent.enemiesList == null)
            gameContent.enemiesList = new List<EnemyData>();
        if (gameContent.levelsList == null)
            gameContent.levelsList = new List<LevelData>();
      
    }

    public void DetectAllWeaponsDatas()
    {
        string[] guids = AssetDatabase.FindAssets("t:WeaponData", null);
        foreach (string guid in guids)
        {
            WeaponData asset = (WeaponData)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid), typeof(WeaponData));

            if (gameContent.weaponsList.Contains(asset) == false)
            {
                gameContent.weaponsList.Add(asset);
            }
        }
    }

    public void DetectAllEnemysDatas()
    {
        string[] guids = AssetDatabase.FindAssets("t:EnemyData", null);
        foreach (string guid in guids)
        {
            EnemyData asset = (EnemyData)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid), typeof(EnemyData));

            if (gameContent.enemiesList.Contains(asset) == false)
            {
                gameContent.enemiesList.Add(asset);
            }
        }
    }

    public void DetectAllLevelsDatas()
    {
        string[] guids = AssetDatabase.FindAssets("t:LevelData", null);
        foreach (string guid in guids)
        {
            LevelData asset = (LevelData)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid), typeof(LevelData));

            if (gameContent.levelsList.Contains(asset) == false)
            {
                gameContent.levelsList.Add(asset);
            }
        }
    }
  
    public void Save()
    {
        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
    }
#endif
}
