using System;
using GameModels.ConsoleEssence.ConsoleUiEssence;
using MetaGame.Actions;
using MetaGame.Architecture.Models;
using MetaGame.GameEssence;
using TMPro;
using UnityEngine;

namespace GameModels.ConsoleEssence
{
    public class Console : IModel
    {
        private readonly ConsoleUi _ui;
        private readonly GameActionRunner _gameActionRunner;
        private readonly ConsoleCommandReader _reader;
        private readonly Game _game;
        private readonly ConsoleInput _input;
        
        public Console(TMP_Text debug, Game game, TMP_InputField input, GameObject console)
        {
            _gameActionRunner = game.GameActionRunner;
            _game = game;
            _reader = new ConsoleCommandReader();
            _ui = new ConsoleUi(debug, input, console);
            _ui.OnCommandEntered += GetCommand;
            _input = new ConsoleInput();
            _input.Enable();
            _input.Console.Open.performed += _ => ToggleUI();
            ConsoleActions.UI = _ui;
            ToggleUI();
        }
        
        public void FixedTick(float deltaTime)
        {
            
        }

        public string Name { get; } = "Console";

        public void Tick(float deltaTime)
        {
            
        }
        
        private void GetCommand(string command)
        {
            try
            {
                var readerCommand = _reader.Read(command);
                ICommandArgs args = readerCommand.Args;
                GameAction<GameActionRunner> action;

                action = readerCommand.ActionInfo.action(args);
                _gameActionRunner.Execute(action);
            }
            catch (Exception e)
            {
                _ui.ThrowException(e.Message);
                throw;
            }
        }
        

        private void ToggleUI()
        {
            if (_ui.IsOpened())
            {
                _game.Unpause();
                _ui.Close();
            }
            else
            {
                _game.Pause();
                _ui.Open();
            }
        }
    }
}