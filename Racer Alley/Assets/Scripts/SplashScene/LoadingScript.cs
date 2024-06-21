using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private void Start()
    {
        StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        while(true)
        {
            _slider.value += Time.deltaTime;
            yield return new WaitForSeconds(0.025f);

            if(_slider.value >= 1)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
