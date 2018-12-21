using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fundidos : MonoBehaviour {

    public Image fundido;
    public string[] escenas;

	// Use this for initialization
	void Start () {
        fundido.CrossFadeAlpha(0, 2, false);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FadeOut(int s)
    {
        fundido.CrossFadeAlpha(1, 1, false);
        StartCoroutine(CambioScene(escenas[s]));
    }

    IEnumerator CambioScene(string escena)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(escena, LoadSceneMode.Additive);
    }
}
