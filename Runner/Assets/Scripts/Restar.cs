using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restar : MonoBehaviour
{
    public void RestarLevel()
    {
        SceneManager.LoadScene(0);
    }
}
