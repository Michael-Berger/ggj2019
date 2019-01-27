using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorScreen : MonoBehaviour
{

    private Material material;
    private new Light light;

    private void Awake()
    {
        material = GetComponent<MeshRenderer>().material;
        material.DisableKeyword("_EMISSION");
        light = GetComponentInChildren<Light>();
        light.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowAfterDelay(float delay)
    {
        StartCoroutine(_ShowAfterDelay(delay));
    }

    private IEnumerator _ShowAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        material.EnableKeyword("_EMISSION");
        light.enabled = true;
    }
}
