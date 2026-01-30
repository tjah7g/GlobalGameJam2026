using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    public Camera cam;
    private float zDistance;

    [SerializeField] private float speed = 10;
    private Vector3 dragOffset;
    private Collider2D coll;
    private Vector3 startDragPos;

    private void Start()
    {
        zDistance = Mathf.Abs(cam.transform.position.z - transform.position.z);
        coll = GetComponent<Collider2D>();
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
            objectDropArea.OnObjectDrop(this);
        }
        else
        {
            transform.position = startDragPos;
        }
    }
}
