using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpikes : MonoBehaviour
{
    public list<CharacterControl> ListCharacters = new List<CharacterControl>();

    // Start is called before the first frame update
    private void Start()
    {
        ListCharacters.Clear();
    }
    public static bool IsTrap() 
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterControl control = other.gameObject.transform.root.gameObject.GetComponent<CharacterControl>();

        if (control != null)
        {
             if (!ListCharacters.Contains(control))
        }
    }

    private void OnTriggerExit(Collider other)
     {
        CharacterControl control = other.gameObject.transform.root.gameObject.GetComponent<CharacterControl>();

        if (control != null)
        {
             if (!ListCharacters.Contains(control))
             {
                ListCharacters.Remove(control);
             }
        }
    }
}
