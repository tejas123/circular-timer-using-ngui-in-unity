using UnityEngine;
using System.Collections;

public class CircularTimer : MonoBehaviour {

	#region PUBLIC_VARIABLES
	public UITexture timerTexture;//Timer Texture if There is a sprite and write UISprite insted of UITexture.
	
	public float maxTime;//Max Time For Progress Bar.
	#endregion
	
	#region DELEGATES
	
	#endregion
	
	#region UNITY_CALLBACKS
	void OnEnable()
	{
		StartTurnTimer(maxTime);//Start When Object will Enable.
	}
	#endregion
	
	#region PUBLIC_METHODS
	public void StartTurnTimer(float maxTime)//Call This Method When You Want to start Timer.
	{
		this.maxTime = maxTime;//Set Max Time.
		StartCoroutine("StartTimer");
	}
	
	public void StopTimer()//Call This Method To Stop Timer.
	{
		this.gameObject.SetActive(false);
	}
	#endregion
	
	#region PRIVATE_METHODS
	private IEnumerator StartTimer()
	{
		timerTexture.color = Color.green;
		float i = 0;
		float rate = 1 / maxTime;
		while (i < 1)
		{
			i += rate * Time.deltaTime;
			timerTexture.fillAmount = Mathf.Lerp(1, 0, i);
			if (i > 0.75f)
				timerTexture.color = Color.red;
			yield return 0;
		}
	}
	#endregion
}
