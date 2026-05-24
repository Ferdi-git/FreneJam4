using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class InputManger : MonoBehaviour
{
    [SerializeField] SOInput soInput;

    [SerializeField] private TextMeshProUGUI RightText;
    [SerializeField] private TextMeshProUGUI LeftText;
    [SerializeField] private TextMeshProUGUI JumpText;


    [SerializeField] private GameObject RightScreen;
    [SerializeField] private GameObject LeftScreen;
    [SerializeField] private GameObject JumpScreen;

    [SerializeField] private SOSave soSave;

    private void Start()
    {
        StartCoroutine(StartupWaitForInput());
    }

    private IEnumerator StartupWaitForInput()
    {
        RightText.text = "RIGHT : ";
        LeftText.text = "LEFT : ";
        JumpText.text = "JUMP : ";
        RightScreen.SetActive(true);
        LeftScreen.SetActive(false);
        JumpScreen.SetActive(false);


        soInput.JumpKeyCode = KeyCode.None ;
        soInput.LeftKeyCode = KeyCode.None ;
        soInput.RightKeyCode = KeyCode.None ;

        bool foundInput = false;
        KeyCode input = KeyCode.None;
        while (!foundInput)
        {
            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(kcode) && !soSave.usedKeyCodes.Contains(kcode))
                {
                    input = kcode;
                    foundInput = true;
                    break;
                }
            } 
             
            yield return null;
        }
        soSave.usedKeyCodes.Add(input);
        soInput.RightKeyCode = input;
        RightText.text = "RIGHT : " + input.ToString() ;


        yield return new WaitForSeconds(0.1f);
        RightScreen.SetActive(false);
        LeftScreen.SetActive(true);


        foundInput = false;
        input = KeyCode.None;
        while (!foundInput)
        {
            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(kcode) && !soSave.usedKeyCodes.Contains(kcode))
                {
                    input = kcode;
                    foundInput = true;
                    break;
                }
            }

            yield return null;
        }
        soSave.usedKeyCodes.Add(input);
        soInput.LeftKeyCode = input;
        LeftText.text = "LEFT : " + input.ToString();


        yield return new WaitForSeconds(0.1f);
        LeftScreen.SetActive(false);
        JumpScreen.SetActive(true);

        foundInput = false;
        input = KeyCode.None;
        while (!foundInput)
        {
            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(kcode) && !soSave.usedKeyCodes.Contains(kcode))
                {
                    input = kcode;
                    foundInput = true;
                    break;
                }
            }

            yield return null;
        }
        soSave.usedKeyCodes.Add(input);
        soInput.JumpKeyCode = input;
        JumpText.text = "JUMP : " + input.ToString();

        JumpScreen.SetActive(false);

    }
}
