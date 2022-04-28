using UnityEngine;

public static class Helper
{
    public static T FindComponentInChildWithTag<T>(this GameObject parent, string tag) where T:Component
    {
        Transform t = parent.transform;
		
        foreach (Transform tr in t)
        {
            if (tr.CompareTag(tag))
                return tr.GetComponent<T>();
        }
		
        return null;
    }
}