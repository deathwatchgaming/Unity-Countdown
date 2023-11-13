/*
*
*  Name: DWG Countdown (Text Mesh Pro)
*  File: CountDownTMP.cs
*  Author: Deathwatch Gaming
*  License: MIT
*
*/

// Using - Engine - System - TMPro 
using System.Collections;
using System;
using UnityEngine;
using TMPro;

// For Example: Switch Scene
// Using - Scene Management
using UnityEngine.SceneManagement;

// Namespace - DWG.UBRS.CountDownTMP
namespace DWG.UBRS.CountDownTMP
{

    // Public - Class - CountDownTMP
    public class CountDownTMP : MonoBehaviour
    {
        // For Example: Switch Scene
        // Public - String - Scene To Load
        public string SceneToLoad;

        // Public - Text Mesh Pro - Start Timer

        // Specific within a UI.Canvas
        public TextMeshProUGUI startTimer;

        // Generic base/parent class for two types
        //public TMP_Text startTimer;

        // Public - Bool - CountDown Enabled = True / Yes
        //public bool CountDownEnabled = true;

        // Public - Bool - CountDown Enabled = False / No
        public bool CountDownEnabled = false;        

        // Public - Event - Action - Integer - Count Down Counter
        public event Action<int> countDownCounter;

        // Void Count Down Counter - Integer - Count
        void CountDownCounter(int count)
        {

            // Start Timer - Text - Count - To String
            startTimer.text = count.ToString();

            // Count Down Counter - Invoke - Count
            countDownCounter?.Invoke(count);

        } // Close - Void Count Down Counter - Integer - Count

        // Private - Void -Start
        private void Start()
        {
            // If CountDown Enabled
            if (CountDownEnabled == true)
            {

                // Start Coroutine - Timer To Start
                StartCoroutine(TimerToStart());

                // startTimer - gameObject - Set Active - True
                startTimer.gameObject.SetActive(true);

                // GetComponent - CountDownTMP - Enabled - True
                GetComponent<CountDownTMP>().enabled = true;

                // Debug - CountDown - Status

                // Debug Log - CountDown Is Enabled
                Debug.Log("The (TMP) countdown is enabled.");

            } // Close - If CountDown Enabled

            // Else If CountDown Is Disabled
            else if (CountDownEnabled == false)
            {

                // startTimer - gameObject - Set Active - False
                startTimer.gameObject.SetActive(false);

                // GetComponent - CountDownTMP - Enabled - False
                GetComponent<CountDownTMP>().enabled = false;

                // Debug Log - CountDown Is Disabled
                Debug.Log("The (TMP) countdown is disabled.");

            } // Close - Else If CountDown Is Disabled

        } // Close - Private - Void -Start

        // Public - Integer - Count Down time
        public int countdownTime;

        // Enumerator - Timer To Start
        IEnumerator TimerToStart()
        {

            // While - Count Down Time - Greater Than 0
            while (countdownTime > 0)
            {

                // Count Down Counter - Count Down Time
                CountDownCounter(countdownTime);

                // Yield Return - New Wait For Seconds
                yield return new WaitForSeconds(1f);

                // Count Down Time
                countdownTime--;

                // Debug - CountDown - Status

                // Debug Log - CountDown Is Running
                Debug.Log("The (TMP) countdown is running.");

            } // Close - While - Count Down Time - Greater Than 0

            // Count Down Counter - Count Down Time
            CountDownCounter(countdownTime);

            // Yield Return New - Wait For Seconds 
            yield return new WaitForSeconds(1f);

            // After Timer
            afterTimer();

        } // Close - Enumerator - Timer To Start

        // Void - After Timer
        void afterTimer()
        {

            // Start Timer - Game Object - Active Equal To False / No
            startTimer.gameObject.SetActive(false);

            // Debug Log - The CountDown Completed
            Debug.Log("The (TMP) countdown has completed.");

            // Lets Do Something Just Here For Example
            Debug.Log("Ok, lets do something here.");

            // For Example: Use The Scene Manager - To Switch The Scene

            // Scene Manager - The Scene to Load 
            SceneManager.LoadScene(SceneToLoad);

            // Debug Log - For Example: The Scene Was Switched
            Debug.Log("For example: The scene was switched.");

        } // Close - Void - After Timer

    } // Close - Public - Class - CountDownTMP

} // Close - Namespace - DWG.UBRS.CountDownTMP
