using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MetaGame.Architecture.Presenters
{
    public class PresentersFinder : MonoBehaviour
    {
        public List<IPresenter> FindPresentersOnCurrentScene()
        {
            var list = new List<IPresenter>();
            
            var objects = FindObjectsOfType<MonoBehaviour>().OfType<IAwakePresenter>();
            var awakePresenters = objects as IAwakePresenter[] ?? objects.ToArray();
            foreach (var presenter in awakePresenters)
            {
                list.Add(presenter);
            }
            
            var objects1 = FindObjectsOfType<MonoBehaviour>().OfType<IStartPresenter>();
            var presenters = objects1 as IStartPresenter[] ?? objects1.ToArray();
            foreach (var presenter in presenters)
            {
                list.Add(presenter);
            }
            
            return list;
        }
    }
}