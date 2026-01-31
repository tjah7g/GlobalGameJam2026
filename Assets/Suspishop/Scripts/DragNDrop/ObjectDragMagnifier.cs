using UnityEngine;

public class ObjectDragMagnifier : MonoBehaviour
{
    public Camera cam;
    private float zDistance;

    [SerializeField] private float speed = 10;
    private Vector3 dragOffset;
    private Collider2D coll;
    private Vector3 startDragPos;

    private SpriteRenderer spriteRenderer;
    private Sprite startSprite;
    [SerializeField] private Sprite newSprite;

    private void Start()
    {
        zDistance = Mathf.Abs(cam.transform.position.z - transform.position.z);
        coll = GetComponent<Collider2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        startSprite = spriteRenderer.sprite;
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
        
        spriteRenderer.sprite = newSprite;
    }
    private void OnMouseDown()
    {
        startDragPos = transform.position;
        dragOffset = transform.position - GetMousePosition();
    }
    private void OnMouseUp()
    {
        transform.position = startDragPos;

        spriteRenderer.sprite = startSprite;
    }
}
