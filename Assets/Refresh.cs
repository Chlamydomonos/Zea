using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Refresh : MonoBehaviour
{
    public GameObject creator;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(delegate()
        {
            Transform[] kernels = creator.GetComponentsInChildren<Transform>();
            foreach(var i in kernels)
            {
                if(i != creator.transform)
                    Destroy(i.gameObject);
            }
            creator.SetActive(false);
            creator.SetActive(true);
        });
    }
}
