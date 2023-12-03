using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    int Memories = 0;

    [SerializeField] Text MemoriesText;
    
    [SerializeField] AudioSource collectionSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other .gameObject.gameObject.CompareTag("Memory"))
        {
            Destroy(other.gameObject);
            Memories++;
           MemoriesText.text = "Memories:" + Memories;
            collectionSound.Play();
        }
    }
}
