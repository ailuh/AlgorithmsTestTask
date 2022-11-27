using System;
using System.Collections.Generic;
using System.Text;

namespace Metro
{
   public class GraphClass
   {
      private readonly Dictionary<char, int> _paths = new ();
      private readonly Dictionary<char, NodeStructure> _nodes = new();
      public void AddNode(char key, NodeStructure node) => _nodes[key] = node;
      private StringBuilder _path;

      public string FindOptimalPath(char startPoint, char finishPoint)
      {
         foreach (var node in _nodes)
         {
            _paths[node.Key] = int.MaxValue;
         }
         _paths[startPoint] = 0;
         foreach (var node in _nodes)
         {
            char v = '\0';
            foreach (var nodeIn in _nodes)
            {
               if (!nodeIn.Value.IsVisited & ((v.Equals('\0')) || _paths[nodeIn.Key] < _paths[node.Key]))
               {
                  v = nodeIn.Key;
               }
            }

            if (_paths[v] == int.MaxValue) break;
            _nodes[v].IsVisited = true;
            foreach (var neighbourNode in _nodes[v].Transfers)
            {
               if ((_paths[v] + 1) < _paths[neighbourNode])
               {
                  _paths[neighbourNode] = _paths[v] + 1;
                  _nodes[neighbourNode].PreviousName = v;
               }
            }
         }

         var first = finishPoint;
         var path = finishPoint.ToString();
         var changes = 0;
         while (!first.Equals(startPoint))
         {
            var previousLines = _nodes[first].LineNames;
            first = _nodes[first].PreviousName;
            _nodes[first].LineNames.IntersectWith(previousLines);
            if (!(previousLines.Count > 0))
            {
               changes++;
            }

            path += first;
         }

         var result = $"Line {Reverse(path)}, Changes {changes}";
         return result;
      }

      private string Reverse(string s)
      {
         char[] charArray = s.ToCharArray();
         Array.Reverse(charArray);
         return new string(charArray);
      }
   }
}
