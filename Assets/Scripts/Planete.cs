using UnityEngine;

public class Planete : MonoBehaviour
{
    [SerializeField] private float gravity;
    [SerializeField] private float distanceFromSun;

    private Vector3 originalScale;
    private bool isHovered = false;
    [SerializeField] private float scaleSpeed = 5f;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        transform.Rotate(Vector3.down * 50 * Time.deltaTime, Space.Self);

        //If u hover on it
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
        {
            isHovered = true;
        }
        else
        {
            isHovered = false;
        }

        float t = scaleSpeed * Time.deltaTime;
        if (isHovered)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale * 2, t);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, t);
        }
    }
}
