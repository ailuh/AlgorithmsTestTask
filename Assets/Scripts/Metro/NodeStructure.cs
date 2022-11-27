using System.Collections.Generic;

namespace Metro
{
    public class NodeStructure
    {
        public readonly char[] Transfers;
        public readonly HashSet<string> LineNames;
        public bool IsVisited { set; get; }
        public char PreviousName { set; get; }

        public NodeStructure(char[] transfers, HashSet<string> lineNames)
        {
            LineNames = lineNames;
            Transfers = transfers;
            IsVisited = false;
            PreviousName = '\0';
        }
    }
}
