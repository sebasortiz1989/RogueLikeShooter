using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterStats : MonoBehaviour
{
    // Config
    [SerializeField] Slider playerHPBar;
    [SerializeField] Slider runningSpeedBar;
    [SerializeField] Slider playerDamageBar;
    [SerializeField] Slider attackSpeedBar;
    [SerializeField] Slider critChanceBar;
    [SerializeField] Slider enemyHPBar;
    [SerializeField] Slider enemyDamageBar;

    // String const
    private const string PLAYERHP = "PlayerHP";
    private const string RUNNINGSPEED = "RunningSpeed";
    private const string PLAYERDAMAGE = "PlayerDamage";
    private const string ATTACKSPEED = "AttackSpeed";
    private const string CRITCHANCE = "CriticalChance";
    private const string ENEMYHP = "EnemyHP";
    private const string ENEMYDAMAGE = "EnemyDamage";

    // Initialize Variables
    private static bool statsSet;

    private void Start()
    {
        if (statsSet && SceneManager.GetActiveScene().buildIndex == 2)
        {
            GetCurrentvalues();
        }
    }

    private void GetCurrentvalues()
    {
        playerHPBar.value = PlayerPrefs.GetInt(PLAYERHP);
        runningSpeedBar.value = PlayerPrefs.GetFloat(RUNNINGSPEED);
        playerDamageBar.value = PlayerPrefs.GetInt(PLAYERDAMAGE);
        attackSpeedBar.value = PlayerPrefs.GetFloat(ATTACKSPEED);
        critChanceBar.value = PlayerPrefs.GetInt(CRITCHANCE);
        enemyHPBar.value = PlayerPrefs.GetInt(ENEMYHP);
        enemyDamageBar.value = PlayerPrefs.GetInt(ENEMYDAMAGE);
    }

    public void DefaultStats()
    {
        PlayerPrefs.SetInt(PLAYERHP, 100);
        PlayerPrefs.SetFloat(RUNNINGSPEED, 5f);
        PlayerPrefs.SetInt(PLAYERDAMAGE, 10);
        PlayerPrefs.SetFloat(ATTACKSPEED, 1f);
        PlayerPrefs.SetInt(CRITCHANCE, 20);
        PlayerPrefs.SetInt(ENEMYHP, 100);
        PlayerPrefs.SetInt(ENEMYDAMAGE, 10);

        playerHPBar.value = PlayerPrefs.GetInt(PLAYERHP);
        runningSpeedBar.value = PlayerPrefs.GetFloat(RUNNINGSPEED);
        playerDamageBar.value = PlayerPrefs.GetInt(PLAYERDAMAGE);
        attackSpeedBar.value = PlayerPrefs.GetFloat(ATTACKSPEED);
        critChanceBar.value = PlayerPrefs.GetInt(CRITCHANCE);
        enemyHPBar.value = PlayerPrefs.GetInt(ENEMYHP);
        enemyDamageBar.value = PlayerPrefs.GetInt(ENEMYDAMAGE);
    }

    public void SetStatsValues()
    {
        PlayerPrefs.SetInt(PLAYERHP, (int)playerHPBar.value);
        PlayerPrefs.SetFloat(RUNNINGSPEED, runningSpeedBar.value);
        PlayerPrefs.SetInt(PLAYERDAMAGE, (int)playerDamageBar.value);
        PlayerPrefs.SetFloat(ATTACKSPEED, attackSpeedBar.value);
        PlayerPrefs.SetInt(CRITCHANCE, (int)critChanceBar.value);
        PlayerPrefs.SetInt(ENEMYHP, (int)enemyHPBar.value);
        PlayerPrefs.SetInt(ENEMYDAMAGE, (int)enemyDamageBar.value);
        statsSet = true;
    }

    public void DefaultStatsStart()
    {
        PlayerPrefs.SetInt(PLAYERHP, 100);
        PlayerPrefs.SetFloat(RUNNINGSPEED, 5f);
        PlayerPrefs.SetInt(PLAYERDAMAGE, 10);
        PlayerPrefs.SetFloat(ATTACKSPEED, 1f);
        PlayerPrefs.SetInt(CRITCHANCE, 20);
        PlayerPrefs.SetInt(ENEMYHP, 100);
        PlayerPrefs.SetInt(ENEMYDAMAGE, 10);
        statsSet = true;
    }
}
