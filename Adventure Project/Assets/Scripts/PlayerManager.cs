using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    PlayerStats stats;
    public GameObject player;
    public TextMeshProUGUI healthIndicator;

    public void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    public void UpdateHealthbar(float newHealth)
    {
        healthIndicator.text = newHealth.ToString();
    }

    public void playerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Add kill player method here? Meant to be really high level actions
}
