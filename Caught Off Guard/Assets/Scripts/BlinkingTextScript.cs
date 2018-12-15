using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BlinkingTextScript : MonoBehaviour {

    public float blinkrate;
    public string message;

    private Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        StartCoroutine(BlinkText());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator BlinkText() {
        while (true) {
            text.text = "";
            yield return new WaitForSeconds(blinkrate);
            text.text = message;
            yield return new WaitForSeconds(blinkrate);
        }
    }
}
