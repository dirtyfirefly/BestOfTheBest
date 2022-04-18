using System.Collections;
using UnityEngine;

public class CustomCoroutine : MonoBehaviour, ICustomCoroutine
{
    public void StartTine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
}
