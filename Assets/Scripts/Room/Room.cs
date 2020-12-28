using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private Door[] _doors;
    [SerializeField] private Ventelation[] _vents;
    [SerializeField] private TypeRoom _typeRoom;


    public enum TypeRoom
    {
        corridore, bathroom, kitchen, bedroom, storage, livingRoom
    }
}
