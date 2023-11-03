using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndCheckValue : MonoBehaviour
{
    public TurnChecker turnChecker;

    private void OnTriggerEnter2D(Collider2D other)
    {
        KilledPieces killed = other.GetComponent<KilledPieces>();
        if (killed.value == 1)
        {
            turnChecker.Value1();
            GetComponent<AudioSource>().Play();
        }
        if (killed.value == 2)
        {
            turnChecker.Value2();
            GetComponent<AudioSource>().Play();
        }
        if (killed.value == 3)
        {
            turnChecker.Value3();
            GetComponent<AudioSource>().Play();
        }
        if (killed.value == 4)
        {
            turnChecker.Value4();
            GetComponent<AudioSource>().Play();
        }
        if (killed.value == 5)
        {
            turnChecker.Value5();
            GetComponent<AudioSource>().Play();
        }

        Destroy(other.gameObject);
    }
}
