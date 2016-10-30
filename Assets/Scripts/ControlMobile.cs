using UnityEngine;
using System.Collections;

public class ControlMobile  : MonoBehaviour {


	#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR

	void Start () {


	Destroy (this.gameObject);
        //otro comentario
        
	}
	#endif


}
