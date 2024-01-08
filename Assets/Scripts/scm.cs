using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class scm
{

    static void reset()
    {
        SceneManager.LoadScene(0);
    }
    public static IEnumerator restartGame(float sec)
    {
        yield return new WaitForSeconds(sec);
        reset();
    }

    public static void Endroll()
    {
        SceneManager.LoadScene(1);
    }
    public static void serclet()
    {
        SceneManager.LoadScene(2);
    }
}
