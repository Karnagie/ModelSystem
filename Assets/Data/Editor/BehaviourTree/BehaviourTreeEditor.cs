using System;
using System.Collections.Generic;
using System.Linq;
using Core.BehaviourTreeModel;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Data.Editor
{
    public class BehaviourTreeEditor : EditorWindow
    {
        private BehaviourTreeView _treeView;
        private InspectorView _inspectorView;
        private IMGUIContainer _blackboardView;

        private SerializedObject _treeObject;
        private string[] _keys;
        
        [MenuItem("BehaviourTreeEditor/Editor")]
        public static void OpenWindow()
        {
            BehaviourTreeEditor wnd = GetWindow<BehaviourTreeEditor>();
            wnd.titleContent = new GUIContent("BehaviourTreeEditor");
        }

        [OnOpenAsset]
        public static bool OnOpenAsset(int instance, int line)
        {
            if (Selection.activeObject is BehaviourTree)
            {
                OpenWindow();
                return true;
            }

            return false;
        }

        public void CreateGUI()
        {
            VisualElement root = rootVisualElement;
        
            // Import UXML
            var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Data/Editor/BehaviourTree/BehaviourTreeEditor.uxml");
            visualTree.CloneTree(root);
            
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Data/Editor/BehaviourTree/BehaviourTreeEditor.uss");
            root.styleSheets.Add(styleSheet);

            _treeView = root.Q<BehaviourTreeView>();
            _inspectorView = root.Q<InspectorView>();
            _blackboardView = root.Q<IMGUIContainer>();
            _blackboardView.onGUIHandler = () =>
            {
                if(_treeObject?.targetObject == null) return;
                _treeObject?.Update();
                
                EditorGUILayout.LabelField("Actions:", EditorStyles.boldLabel);
                if (_keys != null)
                {
                    foreach (var key in _keys)
                    {
                        EditorGUILayout.LabelField($"-{key}");
                    }
                }
                _treeObject?.ApplyModifiedProperties();
            };
            _treeView.OnNodeSelected += OnNodeSelectionChanged; 
            OnSelectionChange();
        }

        private void OnEnable()
        {
            EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }

        private void OnDisable()
        {
            EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
        }
        
        private void OnPlayModeStateChanged(PlayModeStateChange obj)
        {
            switch (obj)
            {
                case PlayModeStateChange.EnteredEditMode:
                    OnSelectionChange();
                    break;
                case PlayModeStateChange.ExitingEditMode:
                    break;
                case PlayModeStateChange.EnteredPlayMode:
                    OnSelectionChange();
                    break;
                case PlayModeStateChange.ExitingPlayMode:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(obj), obj, null);
            }
        }

        private void OnSelectionChange()
        {
            var tree = Selection.activeObject as BehaviourTree;
            
            if (!tree)
            {
                if (Selection.activeGameObject)
                {
                    IBehaviourTreeHandler behaviourTreeHandler = Selection.activeGameObject.GetComponent<IBehaviourTreeHandler>();
                    if (behaviourTreeHandler != null)
                    {
                        tree = behaviourTreeHandler.BehaviourTree;
                    }
                }
            }

            if (Application.isPlaying)
            {
                if (tree)
                {
                    _treeView?.PopulateView(tree); 
                }
            }
            else
            {
                if (tree)//AssetDatabase.CanOpenAssetInEditor(tree.GetInstanceID())
                {
                    _treeView.PopulateView(tree); 
                }
            }

            if (tree != null)
            {
                _treeObject = new SerializedObject(tree);
                
                var t = tree.GetType();
                var t1 = t.GetProperty("blackboard");
                var t2 = t1.GetValue(tree) as Blackboard;
                _keys = t2.objects.Keys.ToArray();
            }
        }

        private void OnNodeSelectionChanged(NodeView view)
        {
            _inspectorView.UpdateSelection(view);
        }

        private void OnInspectorUpdate()
        {
            _treeView?.UpdateNodeStates();
        }
    }
}
