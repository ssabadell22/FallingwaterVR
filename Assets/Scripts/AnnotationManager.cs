using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public enum AnnotationId
{
    PolishedStoneFloor = 0,
    FireplaceStone = 1,
    PosttensionedBeams = 2
}
public class AnnotationManager: MonoBehaviour
{
    [SerializeField] private GameObject _annotationCanvas;
    [SerializeField] private TMP_Text _annotationText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayAnnotation(AnnotationId annotationId)
    {
        string annoText = "";
        switch (annotationId)
        {
            case AnnotationId.FireplaceStone:
                annoText = "The raised stone formations on the floor in the foreground are said to be boulders "
                    + "which were on the site, left in place intentionally. Frank Lloyd Wright described this "
                    + "boulder as \"Kaufmann's favorite spot for lying in the sun and listening to the falls.\" "
                    + "So according to Wright this feature is the starting point for the home, determining the "
                    + "height of the main floor.";
                break;
            case AnnotationId.PolishedStoneFloor:
                annoText = "The stone floor was waxed to resemble polished river stones.";
                break;
            case AnnotationId.PosttensionedBeams:
                annoText = "The cantilevered terraces deflected almost immediately after construction, and "
                   + "continued to tilt down and crack. Deflection was measured at 7 inches in 1994. "
                   + "They were repaired from 1998-2002 with a post-tensioning cable system along 3 of the 4 "
                   + "major reinforced concrete beams under the living room.";
                break;
        }

        _annotationText.text = annoText;
        _annotationCanvas.SetActive(true);
    }

    public void HideAnnotation()
    {
        _annotationText.text = "";
        _annotationCanvas.SetActive(false);
    }
}
