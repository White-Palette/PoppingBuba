using System;
using System.Collections;
using UnityEngine;

public class ComboManager : MonoSingleton<ComboManager>
{
    public int Combo { get; private set; }
    public int MaxCombo { get; private set; }

    private float freezeTime = 0;

    public void AddCombo()
    {
        if (freezeTime > 0)
            return;
        Combo++;
        StartCoroutine(UIManager.Instance.ComboEffect());
    }

    public void ResetCombo()
    {
        if (freezeTime > 0)
            return;
        UpdateMaxCombo();

        Combo = 0;
    }

    public void UpdateMaxCombo()
    {
        if (Combo > MaxCombo)
        {
            MaxCombo = Combo;
        }
    }

    public void AddCombo(int combo)
    {
        if (freezeTime > 0)
            return;
        Combo += combo;
    }

    public void FreezeCombo(float time)
    {
        StartCoroutine(FreezeComboCoroutine(time));
    }

    private IEnumerator FreezeComboCoroutine(float time)
    {
        freezeTime = time;
        yield return new WaitForSeconds(time);
        freezeTime = 0;
    }
}