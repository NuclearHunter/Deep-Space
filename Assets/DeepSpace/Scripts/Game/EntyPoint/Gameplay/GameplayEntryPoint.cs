using System.Collections;
using UnityEngine;

namespace DeepSpace
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        public IEnumerator Initialization()
        {
            Debug.Log("Game init");
            yield return null;
        }

        public void Run()
        {
            Debug.Log("Game run");
        }
    }
}