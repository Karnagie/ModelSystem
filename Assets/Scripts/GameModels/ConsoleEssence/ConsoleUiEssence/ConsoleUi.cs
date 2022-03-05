using System;
using Core.BusEvents;
using Core.BusEvents.Handlers;
using TMPro;
using UnityEngine;

namespace GameModels.ConsoleEssence.ConsoleUiEssence
{
    public class ConsoleUi : IExceptionHandler
    {
        private const int Capacity = 66;

        private TMP_Text _linePrefab;
        private TMP_Text _debug;
        private readonly TMP_InputField _input;
        private readonly GameObject _console;
        private int _lines;
        
        public event Action<string> OnCommandEntered;

        public ConsoleUi(TMP_Text debug, TMP_InputField input, GameObject console)
        {
            EventBus.Subscribe(this);
            _debug = debug;
            ThrowException("Initialization...");
            ThrowException("Enter '?' to see information about commands");
            _input = input;
            _console = console;
            input.onEndEdit.AddListener(OnEndCommand);
        }
        
        public void Open()
        {
            _console.SetActive(true);
        }

        public void Close()
        {
            _console.SetActive(false);
        }

        public bool IsOpened()
        {
            return _console.activeSelf;
        }

        private void OnEndCommand(string command)
        {
            OnCommandEntered?.Invoke(command);
            _input.text = "";
        }

        public void ThrowException(string exception)
        {
            _debug.text += exception+"\n";
            _lines++;
            if (_lines >= Capacity) ClearHalfLines();
        }

        public void Clear()
        {
            _debug.text = "";
            _lines = 0;
        }

        private void ClearHalfLines()
        {
            var text = _debug.text;
            var lines = text.Split('\n');
            _debug.text = "";
            for (int i = 0; i < Capacity / 2; i++)
            {
                _debug.text += lines[Capacity / 2 + i] + "\n";
            }
            _lines /= 2;
        }
    }
}