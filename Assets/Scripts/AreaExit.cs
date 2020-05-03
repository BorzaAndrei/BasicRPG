using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{

    public string areaToLoad;

    public string areaTransitionName;

    public AreaEntrance entrance;

    public float waitToLoad = 1f;
    private bool sholdLoadAfterFade;

    // Start is called before the first frame update
    void Start()
    {
        entrance.transitionName = areaTransitionName;
    }

    // Update is called once per frame
    void Update()
    {
        if (sholdLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;
            if (waitToLoad <= 0)
            {
                sholdLoadAfterFade = false;
                SceneManager.LoadScene(areaToLoad);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //SceneManager.LoadScene(areaToLoad);
            sholdLoadAfterFade = true;
            UIFade.instance.FadeToBlack();

            PlayerController.instance.areaTransitionName = areaTransitionName;
        }
    }
}
