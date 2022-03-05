using MetaGame.GameEssence;
using Presenters.Types;
using TMPro;
using UnityEngine;
using Console = GameModels.ConsoleEssence.Console;

namespace Presenters.ConsoleEssence
{
    public class ConsolePresenter : AwakePresenter
    {
        [SerializeField] private TMP_Text _debug;
        [SerializeField] private TMP_InputField _input;
        
        public override void Init(Game game)
        {
            _model = new Console(_debug, game, _input, gameObject);
        }
    }
}