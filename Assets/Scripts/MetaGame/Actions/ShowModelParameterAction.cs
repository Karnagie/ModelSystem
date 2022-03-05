using System;
using System.Collections.Generic;
using System.Linq;
using Core.BusEvents;
using Core.BusEvents.Handlers;
using MetaGame.Architecture.Models;

namespace MetaGame.Actions
{
    public class ShowModelParameterAction : GameAction<GameActionRunner>
    {
        private readonly string _parameter;
        private readonly string _modelName;
        private List<IModel> _models;

        public ShowModelParameterAction(string parameter, string modelName)
        {
            _models = new List<IModel>();
            _parameter = parameter;
            _modelName = modelName;
        }
        
        protected override void Prepare(GameActionRunner runner)
        {
            if (_modelName == "all")
            {
                runner.Models.ToList().ForEach(m => {_models.Add(m);});
            }
            else
            {
                foreach (var obj in runner.Models)
                {
                    if (String.Equals(obj.Name, _modelName, StringComparison.CurrentCultureIgnoreCase)) _models.Add(obj);
                }
            }
        }

        protected override void Perform()
        {
            
        }

        protected override void Log()
        {
            try
            {
                if (_models.Count == 0)
                {
                    EventBus.RaiseEvent((IExceptionHandler handler) => handler.ThrowException($"Models with name '{_modelName}' not found :("));
                    return;
                }
                
                foreach (var model in _models)
                {
                    var type = model.GetType();
                    var pName = _parameter[0].ToString().ToUpper() + _parameter.Substring(1);
                    var field = type.GetProperty(pName);

                    var message = $"The parameter {_parameter} of {model.Name} not found";
                    if(field != null) message = $"The parameter {_parameter} of {model.Name} is {field.GetValue(model)}";
                    EventBus.RaiseEvent((IExceptionHandler handler) => handler.ThrowException(message));
                }
            }
            catch (Exception e)
            {
                EventBus.RaiseEvent((IExceptionHandler handler) => handler.ThrowException(@"Error in ShowModelParameterAction, void Log"));
                EventBus.RaiseEvent((IExceptionHandler handler) => handler.ThrowException(e.Message));
                throw;
            }
        }
    }
}