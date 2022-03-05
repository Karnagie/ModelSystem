using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.Tests;
using UnityEngine;

namespace Tests.Edit.TestObjectFactory
{
    public class TestObject<T>
    {
        private object _entity;
        private List<FieldInfo> _testFields;

        public TestObject()
        {
            _testFields = new List<FieldInfo>();
            var privateFieldAccessType = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Default;
            Type entityType = typeof(T);
            object entity;

            if (entityType.IsSubclassOf(typeof(ScriptableObject)))
                entity = ScriptableObject.CreateInstance(entityType);
            else
                entity = MonoBehaviour.Instantiate(new GameObject($"{entityType.Name}")).AddComponent(entityType);
            
            var fields = entityType.GetFields(privateFieldAccessType);
            foreach (var field in fields)
            {
                if (field.GetCustomAttribute(typeof(TestFieldAttribute)) != null)
                {
                    _testFields.Add(field);
                }
            }
            _entity = entity;
        }

        public T Get()
        {
            return (T)_entity;
        }

        public void Set(object value)
        {
            int count = 0;
            foreach (var field in _testFields)
            {
                if (field.FieldType == value.GetType() && count == 0)
                {
                    field.SetValue(_entity, value);
                    count++;
                }
                else if (count > 0) throw new Exception($"There is more than one fields with type {field.FieldType} in {_entity.GetType().Name}");
            }
        }
        public void Set(object value, string name)
        {
            foreach (var field in _testFields)
            {
                TestFieldAttribute attr = (TestFieldAttribute)field.GetCustomAttribute(typeof(TestFieldAttribute));

                if (field.FieldType == value.GetType() && attr.Name == name)
                {
                    field.SetValue(_entity, value);
                    return;
                }
            }
            throw new Exception($"Not found test field with type {value.GetType().Name} and the name {name}");
        }
    }
}
