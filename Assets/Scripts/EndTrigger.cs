using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    public Mirror mirror;


    private void Awake()
    {

        mirror.Teleported += TriggerEnd;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerEnd()
    {
        mirror.counterpart.gameObject.SetActive(false);
        mirror.gameObject.SetActive(false);
        StartCoroutine(reloadScene());
    }

    private IEnumerator reloadScene()
    {
        yield return new WaitForSeconds(20);
        SceneManager.LoadScene("House");
    }
}
