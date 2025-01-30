using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpScare : MonoBehaviour
{
    public float timeGap;
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(timewait());
    }

    IEnumerator timewait()
    {
        yield return new WaitForSeconds(timeGap);
        gameObject.SetActive(false);
    }
}
