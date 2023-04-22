using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private Character character;
    
    private void OnTriggerEnter(Collider other)
    { 
        if(other.CompareTag(Constant.TAG_CHARACTER))
        {
            Debug.Log(Constant.TAG_CHARACTER);
            Character c = other.GetComponent<Character>();
            character.AddTarget(c);
            character.ChangeState(new AttackState());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Constant.TAG_CHARACTER))
        {
            Character c = other.GetComponent<Character>();
            character.RemoveTarget(c);
        }
    }
}
