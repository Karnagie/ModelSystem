using System;
using GameModels.ConsoleEssence.Actions;
using GameModels.ConsoleEssence.ConsoleUiEssence;
using MetaGame.Actions;

namespace GameModels.ConsoleEssence
{
    public class ConsoleCommand
    {
        private readonly ICommandArgs _args;
        private readonly ActionInfo _actionInfo;
        
        public ActionInfo ActionInfo => _actionInfo;
        public ICommandArgs Args => _args;

        public ConsoleCommand(ActionInfo actionInfo, ICommandArgs args)
        {
            _actionInfo = actionInfo;
            _args = args;
        }
    }

    public class ShowModelParameterArgs : ICommandArgs
    {
        public string Model;
        public string Parameter;

        public ShowModelParameterArgs(string parameter, string model)
        {
            Parameter = parameter;
            Model = model;
        }
    }

    public static class ConsoleActions
    {
        public static ConsoleUi UI;

        public static ActionInfo[] Infos =
        {
            new ActionInfo(
                "Show [parameter] [model name]",
                "show name all",
                "show", 
                args =>
                {
                    var convArgs = args as ShowModelParameterArgs;
                    return new ShowModelParameterAction(convArgs.Parameter, convArgs.Model);
                }, 
                words => new ShowModelParameterArgs(words[1], words[2])),
            new ActionInfo(
                "clear console", 
                "clear", 
                "clear", 
                args =>
                {
                    return new ClearAction(UI);
                }, 
                words => null),
            new ActionInfo(
                "show commands info", 
                "?", 
                "?", 
                args =>
                {
                    return new InfoAction();
                }, 
                words => null),
            new ActionInfo(
                "show commands examples", 
                "help", 
                "help", 
                args =>
                {
                    return new ShowExamplesAction();
                }, 
                words => null)
        };
    }

    public struct ActionInfo
    {
        public string info;
        public string example;
        public string name;
        public Func<ICommandArgs, GameAction<GameActionRunner>> action;
        public Func<string[], ICommandArgs> args;

        public ActionInfo(
            string info, 
            string example, 
            string name, 
            Func<ICommandArgs, GameAction<GameActionRunner>> action, 
            Func<string[], ICommandArgs> args)
        {
            this.info = info;
            this.example = example;
            this.name = name;
            this.action = action;
            this.args = args;
        }
    }
}