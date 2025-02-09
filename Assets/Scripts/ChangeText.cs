using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _descriptionText;

    [SerializeField] private List<GameObject> poissons;
    void Start()
    {
        _nameText.text = "";
        _descriptionText.text = "";
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        foreach (GameObject poisson in poissons)
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == poisson)
                {
                    Poisson poissonScript = poisson.GetComponent<Poisson>();
                    Change(poissonScript.Name, poissonScript.Description);
                }
            }
            else
            {
                Change("", "");
            }
            
        }
    }

    private void Change(string name, string description)
    {
        _nameText.text = name;
        _descriptionText.text = description;
    }
}
