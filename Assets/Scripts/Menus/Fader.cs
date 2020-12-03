using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
   public CanvasGroup uiElement;
   public float TimeToFadeIn;
   public float TimeToFadeOut;
   
   void Start()
   {
       StartCoroutine(WaitToFadeIn());
       StartCoroutine(WaitToFadeOut());
   }
   public void FadeIn()
   {
       StartCoroutine(FadeCanvasGroup(uiElement,uiElement.alpha,1));
   }
   public void FadeOut()
   {
       StartCoroutine(FadeCanvasGroup(uiElement,uiElement.alpha,0));
   }
   public IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup,float start, float end, float lerpTime = 1.0f)
   {
       
       float timeStartedLerping = Time.time;
       float timeSinceStarted = Time.time - timeStartedLerping;
       float percentComplete = timeSinceStarted / lerpTime;
       while(true)
       {
           timeSinceStarted = Time.time - timeStartedLerping;
           percentComplete = timeSinceStarted / lerpTime;
           
           float currentValue = Mathf.Lerp(start,end,percentComplete);
           
           canvasGroup.alpha = currentValue;
           
           if(percentComplete >=1) break;
           yield return new WaitForEndOfFrame();
       }
   }
    IEnumerator WaitToFadeIn()
    {
       yield return new WaitForSeconds(TimeToFadeIn);
       Debug.Log("FadeIn");
       FadeIn();
    }
     IEnumerator WaitToFadeOut()
    {
       Debug.Log("FadeOut");
       yield return new WaitForSeconds(TimeToFadeOut);
       FadeOut();
    }
}
