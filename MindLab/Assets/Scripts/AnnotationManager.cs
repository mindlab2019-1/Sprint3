using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnotationManager : MonoBehaviour
{
    public static AnnotationManager Instance;

    public GameObject AnnotationPrefab;

    public List<Annotation> Annotations;

    private void Awake() {
        Instance = this;
    }

    public void NewAnnotation(Vector3 _v, string _s)
    {
        var _a = Instantiate(AnnotationPrefab).GetComponent<Annotation>();

        _a.Initialise(_v, _s);

        Annotations.Add(_a);
    }
}
