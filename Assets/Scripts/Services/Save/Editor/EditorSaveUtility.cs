using UnityEditor;
using UnityEngine;

namespace Playground.Services.Save.Editor
{
    public static class EditorSaveUtility
    {
        #region Private methods

        [MenuItem("Tools/Save/Open Save Folder")]
        private static void OpenSaveFolder()
        {
            EditorUtility.RevealInFinder(Application.persistentDataPath);
        }

        #endregion
    }
}