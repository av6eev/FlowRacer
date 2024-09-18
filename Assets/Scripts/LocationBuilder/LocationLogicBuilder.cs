﻿using GameScenes.Level;
using GameScenes.UI;
using Level;
using Presenter;
using SceneManagement;
using Specification.Scene;
using UnityEngine;

namespace LocationBuilder
{
    public class LocationLogicBuilder
    {
        private readonly GameModel _gameModel;
        private readonly PresentersList _presenters;
        private readonly SceneSpecification _specification;

        public LocationLogicBuilder(GameModel gameModel, PresentersList presenters, SceneSpecification specification)
        {
            _gameModel = gameModel;
            _presenters = presenters;
            _specification = specification;
        }

        public void Build()
        {
            var sceneView = GameObject.Find(_specification.PrefabId).GetComponent<LocationSceneView>();
            
            switch (_specification.SceneId)
            {
                case SceneConst.Ui:
                    _presenters.Add(new UiScenePresenter(_gameModel, (UiSceneView)sceneView));
                    break;
                case SceneConst.Level:
                    var model = new LevelModel(_gameModel.Specifications.LevelSpecifications["1"]);
                    _presenters.Add(new LevelScenePresenter(_gameModel, model, (LevelSceneView)sceneView));
                    break;
            }
        }
    }
}