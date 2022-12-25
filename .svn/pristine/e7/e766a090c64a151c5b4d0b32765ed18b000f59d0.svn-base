using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Console = Core.DeveloperConsole.Scripts.Common.Console;

namespace Core.DeveloperConsole.Scripts.Backend {
    internal class AttributeCommand : Command {

        internal MethodInfo m_methodInfo;
        internal ParameterInfo[] m_parameters;
        internal Type[] m_paramTypes;

        private object[] m_paramObj;

        public AttributeCommand(string name, string description, ConsoleBackend backend) : base(name, description, backend) {
        }

        internal void Initialize(MethodInfo info) {
            m_methodInfo = info;
            m_methodInfo = info;
            m_parameters = info.GetParameters();
            m_paramTypes = m_parameters.Select(x => x.ParameterType).ToArray();
        }

        internal override void Execute(string line) {
            var split = line.TrimEnd().Split(' ');

            if (split.Length - 1 < m_parameters.Length) {
                Console.WriteLine("Wrong parameters count");
                return;
            }

            if (m_paramObj == null)
                m_paramObj = new object[m_paramTypes.Length];

            for (int i = 0; i < m_paramTypes.Length; i++) {
                try {
                    m_paramObj[i] = Convert.ChangeType(split[i + 1], m_paramTypes[i]);

                }
                catch (Exception e) {
                    Console.WriteLine("param(" + i + ") -" + e.Message);

                }
                if (m_paramObj[i] == null) {
                    return;
                }
            }

            var gos = GameObject.FindObjectsOfType(m_methodInfo.DeclaringType);
            int count = gos.Length;
            for (int i = 0; i < count; i++) {
                m_methodInfo.Invoke(gos[i], m_paramObj);
            }
        }
    }
}