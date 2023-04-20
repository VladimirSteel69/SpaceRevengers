using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TritiumScript : MonoBehaviour
{

    //lets easy interactions
    public static TritiumScript Instance { get; private set; }              
  
     void Awake()     {
         if (Instance == null) {Instance = this; } else if (Instance != this) {Destroy(this); }
         DontDestroyOnLoad(gameObject);
    }

    public Text MyTrit;
    [SerializeField] public int CurrentTrit;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
