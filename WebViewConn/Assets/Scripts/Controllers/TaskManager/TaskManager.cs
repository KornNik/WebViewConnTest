﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    sealed class TaskManager : MonoBehaviour
    {
        private ITask _currentTask;
        private List<ITask> _tasks = new List<ITask>();

        public ITask CurrentTask => _currentTask;

        public void AddTask(IEnumerator taskAction, Action callback, TaskPriorityEnum taskPriority = TaskPriorityEnum.Default)
        {
            var task = TaskCustom.Create(taskAction, taskPriority).Subscribe(callback);

            ProcessingAddedTask(task, taskPriority);
        }
        public void Break()
        {
            if (_currentTask != null)
            {
                _currentTask.Stop();
            }
        }
        public void Restore()
        {
            TaskQueueProcessing();
        }
        public void Clear()
        {
            Break();

            _tasks.Clear();
        }
        private void ProcessingAddedTask(ITask task, TaskPriorityEnum taskPriority)
        {
            switch (taskPriority)
            {
                case TaskPriorityEnum.Default:
                    {
                        _tasks.Add(task);
                    }
                    break;
                case TaskPriorityEnum.High:
                    {
                        _tasks.Insert(0, task);
                    }
                    break;
                case TaskPriorityEnum.Interrupt:
                    {
                        if (_currentTask != null && _currentTask.Priority != TaskPriorityEnum.Interrupt)
                        {
                            _currentTask.Stop();
                        }

                        _currentTask = task;

                        task.Subscribe(TaskQueueProcessing).Start();
                    }
                    break;
            }

            if (_currentTask == null)
            {
                _currentTask = GetNextTask();

                if (_currentTask != null)
                {
                    _currentTask.Subscribe(TaskQueueProcessing).Start();
                }
            }
        }
        private void TaskQueueProcessing()
        {
            _currentTask = GetNextTask();

            if (_currentTask != null)
            {
                _currentTask.Subscribe(TaskQueueProcessing).Start();
            }
        }
        private ITask GetNextTask()
        {
            if (_tasks.Count > 0)
            {
                var returnValue = _tasks[0]; _tasks.RemoveAt(0);

                return returnValue;
            }
            else
            {
                return null;
            }
        }
    }
}
