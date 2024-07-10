using System.Collections;
using UnityEngine;

public class LightsOutButton : PuzzleButton
{
    public bool Value { get; private set; }
    Vector2Int myPosition;
    LightsOutController controller;

    public override void OnInteract(InteractModule module)
    {
        base.OnInteract(module);

        if (!canInteract) return;

        FlipLight();
        controller.toggleAdjacentValues(myPosition);
        SoundManager.Instance.PlayButtonSound(transform.position);
    }

    public void SetButtonLightStatus(bool isLight)
    {
        objectRenderer.material.color = isLight ? highlightColor : defaultColor;
    }

    public void SetButtonValue(bool value)
    {
        this.Value = value;
        SetButtonLightStatus(value);
    }

    public void FlipLight()
    {
        SetButtonValue(!Value);
    }

    public void SetPosition(Vector2Int position, LightsOutController controller)
    {
        this.controller = controller;
        myPosition = position;
    }

    protected override IEnumerator BlinkButtonCoroutine()
    {
        objectRenderer.material.color = highlightColor;
        yield return new WaitForSeconds(1);
        objectRenderer.material.color = defaultColor;
    }
}