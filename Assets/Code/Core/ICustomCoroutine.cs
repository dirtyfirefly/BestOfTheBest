using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICustomCoroutine
{
    void StartTine(IEnumerator coroutine);
}
