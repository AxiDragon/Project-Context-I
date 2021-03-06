using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WhiteFlash : MonoBehaviour
{
    CanvasGroup flash;
    void Start()
    {
        flash = FindObjectOfType<CanvasGroup>();
        StartCoroutine(Flash(true));
    }

    public IEnumerator Flash(bool flashIn)
    {
        float startTime = Time.time;
        float endAlpha = flashIn ? 0f : 1f;
        float startAlpha = flashIn ? 1f : 0f;

        while (flash.alpha != endAlpha)
        {
            flash.alpha = Mathf.SmoothStep(startAlpha, endAlpha, (Time.time - startTime) / 2);

            yield return new WaitForFixedUpdate();
        }

        if (!flashIn)
        {
            switch (AreaTalk.gamePhase)
            {
                default:
                    LoadingScreen.sceneNumber = 2;
                    SceneManager.LoadScene("LoadingScreen");
                    AreaTalk.gamePhase++;
                    break;
            }
        }
    }
}
