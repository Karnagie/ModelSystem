using System;
using System.Collections.Generic;
using System.Linq;
using Core.BusEvents;
using Core.BusEvents.Handlers;
using Core.Exeptions;
using MetaGame.Actions;
using MetaGame.Architecture.Models;
using MetaGame.Architecture.Presenters;
using MetaGame.GameEssence.States;
using UnityEngine;

namespace MetaGame.GameEssence
{
    public class Game : MonoBehaviour, IPresenterHandler
    {
        [SerializeField] private PresentersFinder _finder;

        private GameStateMachine _stateMachine;
        private List<IPresenter> _presenters;
        private List<IModel> _models;
        private GameActionRunner _gameActionRunner;

        public GameActionRunner GameActionRunner => _gameActionRunner;

        private void Start()
        {
            EventBus.Subscribe(this);
            _gameActionRunner = new GameActionRunner(this);
            _models = new List<IModel>();
            _stateMachine = new GameStateMachine(_models);
            _presenters = _finder.FindPresentersOnCurrentScene();
            
            foreach (var presenter in _presenters.ToList())
            {
                presenter.Init(this);
                AddModel(presenter.GetModel());
            }
        }
        
        private void Update()
        {
            _stateMachine.Update(Time.deltaTime);
            
        }

        private void FixedUpdate()
        {
            _stateMachine.FixedUpdate(Time.deltaTime);
        }

        public IModel FindModel<T>(T modelType) where T : Type
        {
            foreach (var model in _models)
            {
                if (model.GetType() == modelType) return model;
            }
            throw new ConsoleException($"A model with the type {modelType} has not found!");
        }
        
        public IModel[] FindModels<T>(T modelType) where T : Type
        {
            var models = new List<IModel>();
            foreach (var model in _models)
            {
                if (modelType.IsInstanceOfType(model))
                {
                    models.Add(model);
                }
            }

            return models.ToArray();
        }
        
        public IModel[] FindModelsByBaseType<T>(T baseType) where T : Type
        {
            var models = new List<IModel>();
            foreach (var model in _models)
            {
                if (model.GetType().BaseType == baseType) models.Add(model);
            }

            return models.ToArray();
        }
        
        public IModel FindModelByName(string modelName)
        {
            foreach (var model in _models)
            {
                if (model.Name == modelName) return model;
            }
            throw new ConsoleException($"A model with the name {modelName} has not found!");
        }
        
        public void AddModel<T>(T model) where T : IModel
        {
            _models.Add(model);
        }

        public void AddPresenter(IPresenter presenter)
        {
            presenter.Init(this);
            _presenters.Add(presenter);
        }

        public void Pause()
        {
            _stateMachine.CastEvent(GameEvents.Pause);
        }
        
        public void Unpause()
        {
            _stateMachine.CastEvent(GameEvents.Run);
        }
    }
}
