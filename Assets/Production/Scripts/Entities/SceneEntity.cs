using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Production.Scripts.Entities {
    public class SceneEntity : MonoBehaviour {

        public string StartingSceneName;

        private AsyncOperation _asyncLoad;
        private AsyncOperation _asyncUnload;
        
        private void Start() {
            LoadScene(StartingSceneName);
        }

        public void UnloadScene(string scene) {
            if (!SceneManager.GetSceneByName(scene).isLoaded || _asyncUnload != null) return;
            Debug.Log("Unloading " + scene + "...");
            StartCoroutine(UnloadSceneAsync(scene));
        }
		
        public void LoadScene(string scene) {
            if (SceneManager.GetSceneByName(scene).isLoaded || _asyncLoad != null) return;
            Debug.Log("Loading " + scene + "...");
            StartCoroutine(LoadSceneAsync(scene));
        }

        public void ReloadScene(string scene) {
            Debug.Log("Reloading " + scene + "...");
            StartCoroutine(ReloadSceneAsync(scene));
        }

        public void ExitGame() {
            Application.Quit();
        }

        public IEnumerator ReloadSceneAsync(string scene) {
            yield return UnloadSceneAsync(scene);
            yield return LoadSceneAsync(scene);
        }
		
        private IEnumerator UnloadSceneAsync(string scene) {
            _asyncUnload = SceneManager.UnloadSceneAsync(scene);
            //Wait until the last operation fully loads to return anything
            while (!_asyncUnload.isDone) {
                yield return null;
            }
            _asyncUnload = null;
            Debug.Log(scene + " unloaded !");
        }

        private IEnumerator LoadSceneAsync(string scene) {
            _asyncLoad = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            //Wait until the last operation fully loads to return anything
            while (!_asyncLoad.isDone) {
                yield return null;
            }
            _asyncLoad = null;
            Debug.Log(scene + " loaded !");
        }

    }
}
