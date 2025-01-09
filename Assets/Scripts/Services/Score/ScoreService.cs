using NaughtyAttributes;
using Playground.Models;
using Playground.Services.Save;
using UnityEngine;
using Zenject;

namespace Playground.Services.Score
{
    public class ScoreService
#if UNITY_EDITOR
        : MonoBehaviour
#endif
    {
        #region Variables

        [SerializeField] private int _scoreToAddDebug;

        private SaveService _saveService;

        #endregion

        #region Setup/Teardown

        [Inject]
        public void Construct(SaveService saveService)
        {
            _saveService = saveService;
        }

        #endregion

        #region Public methods

        public void ChangeScore(int value)
        {
            GameData gameData = _saveService.GetData<GameData>();

            gameData.score += value;
            gameData.score = Mathf.Max(0, gameData.score);

            _saveService.Save<GameData>();
        }

        public void Initialize()
        {
            // This is test
            _saveService.GetData<GameData>();
        }

        #endregion

        #region Private methods

        [Button]
        private void ChangeScoreDebug()
        {
            ChangeScore(_scoreToAddDebug);
        }

        #endregion
    }
}