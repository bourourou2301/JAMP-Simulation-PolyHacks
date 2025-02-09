using System.Globalization;
using UnityEngine;

public class Poisson : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;

    public string Name
    {
        get { return _name; }
    }

    public string Description
    {
        get { return _description; }
    }

    private Vector3 originalScale;
    private bool isHovered = false;
    [SerializeField] private float scaleSpeed = 5f;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
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
