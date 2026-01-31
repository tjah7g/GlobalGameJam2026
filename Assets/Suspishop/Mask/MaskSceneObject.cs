using DG.Tweening;
using UnityEngine;

public class MaskSceneObject : MonoBehaviour
{
    [SerializeField]
    private MaskData maskData;

    SpriteRenderer spriteRenderer;

    #region dotween

    private Sequence clickSequence;
    private Vector3 originalScale;
    private float originalAlpha;

    #endregion

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = maskData.sprite;

        MaskManager.Instance.OnMaskChanged += HandleMaskChanged;

        originalScale = transform.localScale;
        originalAlpha = spriteRenderer.color.a;
    }

    void OnDestroy()
    {
        if (MaskManager.Instance != null)
            MaskManager.Instance.OnMaskChanged -= HandleMaskChanged;
    }

    void setSelectedMask()
    {
        MaskManager.Instance.SetSelectedMask(maskData);
    }

    private void OnMouseDown()
    {
        if (clickSequence != null && clickSequence.IsActive())
            clickSequence.Kill();

        clickSequence = DOTween.Sequence();

        clickSequence.Append(transform.DOShakeRotation(.5f, 30, 10, 10, true));
        clickSequence.Join(transform.DOScale(10f, .5f));
        clickSequence.Join(spriteRenderer.DOFade(0f, .4f));

        clickSequence.OnComplete(() =>
        {
            setSelectedMask();
            ResetTween();
        });
    }

    void ResetTween()
    {
        transform.DOScale(originalScale, .3f);
        spriteRenderer.DOFade(originalAlpha, .3f);
        transform.DORotate(Vector3.zero, .3f);
    }

    private void OnMouseEnter()
    {
        spriteRenderer.sprite = maskData.spriteHover;
    }
    
    private void OnMouseExit()
    {
        spriteRenderer.sprite = maskData.sprite;
    }

    void HandleMaskChanged(MaskData selected)
    {
        bool isSelected = MaskManager.Instance.selectedMask == maskData;
        this.gameObject.SetActive(!isSelected);
    }
}
