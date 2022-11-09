using UnityEngine;

public class GenericMethodExample : MonoBehaviour
{
    void Start()
    {
        float newNum = 100.5f;
        Vector3 newVector = new Vector3(1, 3, 2);

        Evaluate("Hello World");
        Evaluate(10);
        Evaluate(newNum);
        Evaluate(newVector);
    }

    private void Evaluate<T>(T suppliedValue)
    {
        Debug.LogFormat("the Type of {0} is {1}", suppliedValue, typeof(T));
    }
}
