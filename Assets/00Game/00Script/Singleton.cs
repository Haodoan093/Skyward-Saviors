using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instant;
    public static T Instant 
    {
        get
        {
            if (_instant == null)
            { // kiem tra neu chua duoc khoi tao thi se tim den 
                if(FindObjectOfType<T>() != null)
                    _instant = FindObjectOfType<T>();
                else
                    new GameObject().AddComponent<T>().name="Singleton_ +"+typeof(T).ToString();
            }
            return _instant;
        }
    }
    private void Awake()
    {
        if(Instant != null&&_instant.gameObject.GetInstanceID()!=this.gameObject.GetInstanceID())
            Destroy(this.gameObject);// kiem tra neu da ton tai thi destroy
        else
            _instant= this.GetComponent<T>();// khoi tao
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
