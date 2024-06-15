using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticCoroutines
{
    // ���� ����� �����ϴ� Static �ڷ�ƾ
    public static IEnumerator DelayedAction(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();

        // �����, ���ٸ� ���(delegate)
        // StartCoroutine(StaticCoroutines.DelayedAction(2f, () => Debug.Log("2 seconds have passed")));
    }
}