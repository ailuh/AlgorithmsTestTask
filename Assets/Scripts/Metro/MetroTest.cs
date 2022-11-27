using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Metro
{
    public class MetroTest : MonoBehaviour
    {
        [FormerlySerializedAs("_startPoint")] [SerializeField] private TMP_InputField startPoint;
        [FormerlySerializedAs("_finishPoint")] [SerializeField] private TMP_InputField finishPoint;
        [FormerlySerializedAs("_result")] [SerializeField] private TMP_Text result;
        private GraphClass _metro;
        private readonly string _availableKeys = "ABCDEFGHJKLMNO";
    
        void Start()
        {
            _metro = new GraphClass();
            _metro.AddNode('A', new NodeStructure(new[]{'B'}, new HashSet<string>{"RED"}));
            _metro.AddNode('B', new NodeStructure(new[]{'A', 'H', 'C'}, new HashSet<string>{"RED", "BLACK"}));
            _metro.AddNode('C', new NodeStructure(new[]{'B', 'K', 'D', 'J'}, new HashSet<string>{"RED", "GREEN"}));
            _metro.AddNode('D', new NodeStructure(new[]{'C', 'L', 'J', 'E'}, new HashSet<string>{"RED", "BLUE"}));
            _metro.AddNode('E', new NodeStructure(new[]{'D', 'J', 'M', 'F'}, new HashSet<string>{"RED", "GREEN"}));
            _metro.AddNode('F', new NodeStructure(new[]{'E', 'J', 'G'}, new HashSet<string>{"RED", "BLACK"}));
        
            _metro.AddNode('H', new NodeStructure(new[]{'B', 'J'}, new HashSet<string>{"BLACK"}));
            _metro.AddNode('J', new NodeStructure(new[]{'C', 'H', 'D', 'E', 'F', 'O'}, new HashSet<string>{"BLACK", "BLUE", "GREEN"}));
            _metro.AddNode('G', new NodeStructure(new[]{'F'}, new HashSet<string>{"BLACK"}));
        
            _metro.AddNode('O', new NodeStructure(new[]{'J'}, new HashSet<string>{"BLUE"}));
            _metro.AddNode('L', new NodeStructure(new[]{'D', 'K', 'M', 'N'}, new HashSet<string>{"GREEN", "BLUE"}));
            _metro.AddNode('N', new NodeStructure(new[]{'L'}, new HashSet<string>{"BLUE"}));
        
            _metro.AddNode('K', new NodeStructure(new[]{'C', 'L'}, new HashSet<string>{"GREEN"}));
            _metro.AddNode('M', new NodeStructure(new[]{'E', 'L'}, new HashSet<string>{"GREEN"}));
        
        }

        public void CalculateOptimalPath()
        {
            var pointStart = startPoint.text;
            var pointFinish = finishPoint.text;
            if (_availableKeys.Contains(pointStart) && _availableKeys.Contains(pointFinish))
            {
                if (pointStart.Length.Equals(1) && pointFinish.Length.Equals(1))
                {
                    var resultOptimalPath = _metro.FindOptimalPath(pointStart[0], pointFinish[0]);
                    result.text = resultOptimalPath;
                }
            }
        }
    }
}
