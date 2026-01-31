using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;

public class ObjectDrag : MonoBehaviour
{
    public Camera cam;
    private float zDistance;

    [SerializeField] private float speed = 10;
    private Vector3 dragOffset;
    private Collider2D coll;
    private Vector3 startDragPos;
    private Vector3 initialSize;

    private void Start()
    {
        zDistance = Mathf.Abs(cam.transform.position.z - transform.position.z);
        coll = GetComponent<Collider2D>();

        initialSize = transform.localScale;
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = zDistance;

        Vector3 pos = cam.ScreenToWorldPoint(mousePos);
        return pos;
    }
    private void OnMouseDrag()
    {
        transform.position = Vector3.MoveTowards(transform.position, GetMousePosition() + dragOffset, speed * Time.deltaTime);

        // HARDCODE KHUSUS POTION (BELUM DIRAPIKAN)
        transform.localScale = new Vector3(.5f, .5f, 1f);
    }
    private void OnMouseDown()
    {
        startDragPos = transform.position;
        dragOffset = transform.position - GetMousePosition();
    }
    private void OnMouseUp()
    {
        coll.enabled = false;
        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
        coll.enabled = true;

        if (hitCollider != null && hitCollider.TryGetComponent(out IObjectDropArea objectDropArea))
        {
            transform.DOShakeRotation(.2f, 30, 10, 10, true);
            objectDropArea.OnObjectDrop(this);
        }
        else
        {
            transform.position = startDragPos;
            transform.localScale = initialSize;
        }
    }
}
