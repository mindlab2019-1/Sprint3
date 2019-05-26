using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnotationManager : MonoBehaviour
{
    public static AnnotationManager Instance;

    public GameObject AnnotationPrefab;

    public List<Annotation> Annotations;
    private List<Annotation> preMadeAnnotations;

    private void Awake() {
        Instance = this;
    }
    //    void Start()
    // {
        
    //     for (int i = 0; i < 5; i++)
    //     {
    //         preMadeAnnotations.Add(Instantiate(AnnotationPrefab).GetComponent<Annotation>());
    //         preMadeAnnotations[i].GetComponentInChildren<Canvas>().enabled = false;
    //     }
    // }

    // public void NewAnnotation(Vector3 _v, string _s)
    // {
    //     var _a = new Annotation();
    //     if (preMadeAnnotations.Count > 0){
    //         _a = preMadeAnnotations[preMadeAnnotations.Count-1];
    //         preMadeAnnotations.Remove(_a);
    //         _a.GetComponentInChildren<Canvas>().enabled = false;

    //     }
    //     else
    //     {
    //         _a = Instantiate(AnnotationPrefab).GetComponent<Annotation>();
    //     }
        


    public void NewAnnotation(Vector3 _v, string _s)
    {
        var _a = Instantiate(AnnotationPrefab).GetComponent<Annotation>();

        _a.Initialise(_v, _s);

        Annotations.Add(_a);
    }
}
