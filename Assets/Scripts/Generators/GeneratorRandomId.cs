using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorRandomId : MonoBehaviour
{
    private List<string> _IDs = new List<string>();
    private static GeneratorRandomId _instantiate;
    static public GeneratorRandomId Instantiate
    {
        get
        {
            if (_instantiate == null) 
            {
                _instantiate = new GameObject("GeneratorIDRoom").AddComponent<GeneratorRandomId>();
            }
            return _instantiate;
        }
    }
    public string GetRandomId(string typeRoom)
    {
        string result = typeRoom + GetPostfix();
        while (CheckingUniquenessID(result) == false)
            result = typeRoom + GetPostfix();

        return result;
    }


    private bool CheckingUniquenessID(string idForCheck)
    {
        foreach (var id in _IDs)
        {
            if (idForCheck == id)
                return false;
        }
        return true;
    }

    private string GetPostfix() 
    {
        string result = "";
        for (int i = 0; i < 4; i++)
        {
            result += Random.Range(0, 10);
        }
        return "-" + result;
    }

}
