using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using Tanks.MVC;
public class GameUI : MonoBehaviour
{
    public static Action OnDeath;
    public static event Action<int> OnDeathCount;

    public GameObject playerKillUI;
    //public GameObject playerKillCountUI;

    bool checkUI;
    public TMP_Text playerKillCountUI;

    public int myID; //TankService thing
    int count = 0;
    private void Start()
    {
        //OnDeath += GameUI_OnDeath;
        playerKillUI.SetActive(false);
        checkUI = false;
    }
    private void Update()
    {
        OnDeath?.Invoke();
        //OnDeathCount?.Invoke(count);
    }
        
    public void GameUI_OnDeath()
    {
        CheckUIActive();
    }

    public void GameUI_OnDeathCount(int _count)
    {
        playerKillCountUI.text = count.ToString();
        count += 1;
    }
    private void CheckUIActive()
    {
        if (!checkUI)
        {
            playerKillUI.SetActive(true);
            checkUI = true;
            StartCoroutine(ResetUIActive());
        }
    }
    private IEnumerator ResetUIActive()
    {
        yield return new WaitForSeconds(2);
        checkUI = false;
        playerKillUI.SetActive(false);
        OnDeath -= GameUI_OnDeath;
    }

    private void OnDisable()
    {
        OnDeathCount -= GameUI_OnDeathCount;
    }
}















//Reference Script for future
/* 
  public event Action<int, int> onDeath;
  OnDeath = GameUI_OnDeath;
  onDeath += GameUI_onDeath;

    private void Start()
    {
        
        onDeath?.Invoke(0, 100);
    }

    //public void GameUI_onDeath(int deadTankID, int killedTankID)
    //{
    //    if (killedTankID == myID)
    //    {

    //    }
    //    else if(deadTankID == myID)
    //    {

    //    }
    //}

*/
