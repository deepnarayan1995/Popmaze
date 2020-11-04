using UnityEngine;

public class CloudVariables : MonoBehaviour
{

    public static int[] FiveImportantValues { get; set; }

    private void Awake()
    {
        FiveImportantValues = new int[5];
    }


}
