using System.Collections;
using UnityEngine;

public class SimonSaysButton : PuzzleButton
{
    SimonSaysController controller;
    [SerializeField] float lightUpDuration = 1f;
    private int value;

    protected override void Awake()
    {
        base.Awake();
        LightUpColor();
    }

    public override void OnInteract(InteractModule module)
    {
        base.OnInteract(module);

        if (!canInteract) return;
        controller.OnButtonPressed(value);
        ButtonBlink();
    }

    public void SetReturnValue(int value, SimonSaysController controller)
    {
        this.controller = controller;
        this.value = value;
    }

    public void LightUpColor()
    {
        objectRenderer.material.color = highlightColor;
    }

    public void UnlightUpColor()
    {
        objectRenderer.material.color = defaultColor;
    }

    protected override IEnumerator BlinkButtonCoroutine()
    {
        SoundManager.Instance.PlayMusicKey(transform.position + new Vector3(0, 0, 2f), value);
        LightUpColor();
        yield return new WaitForSeconds(lightUpDuration);
        UnlightUpColor();
    }
}