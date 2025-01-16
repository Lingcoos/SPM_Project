using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBaseManager<T> where T: new()
{
    private static T instance;
    public static T getInstance() 
    {
        if (instance == null)
            instance =new T();
        return instance;
    }
}
