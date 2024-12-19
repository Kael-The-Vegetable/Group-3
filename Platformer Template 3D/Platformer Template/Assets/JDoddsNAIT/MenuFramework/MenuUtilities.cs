using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JDoddsNAIT.Unity.MenuFramework
{
    public class MenuUtilities : MonoBehaviour
    {
        public void QuitGame()
        {
            Application.Quit();
        }

        public void SetTimeScale(float timeScale)
        {
            Time.timeScale = timeScale;
        }

        public void SetCursorLockState(bool locked)
        {
            Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }
}