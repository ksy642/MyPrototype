using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticCoroutines
{
    // 공통 기능을 수행하는 Static 코루틴
    public static IEnumerator DelayedAction(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();

        // 사용방법, 람다를 사용(delegate)
        // StartCoroutine(StaticCoroutines.DelayedAction(2f, () => Debug.Log("2 seconds have passed")));
    }
}