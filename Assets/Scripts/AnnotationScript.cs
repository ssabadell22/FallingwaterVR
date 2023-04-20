using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnotationScript : MonoBehaviour
{
    [SerializeField] private AnnotationManager _annotationManager;
    [SerializeField] private AnnotationId _annotationId;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"trigger enter {other.name}");
        _annotationManager.DisplayAnnotation(_annotationId);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"trigger exit {other.name}");
        _annotationManager.HideAnnotation();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
