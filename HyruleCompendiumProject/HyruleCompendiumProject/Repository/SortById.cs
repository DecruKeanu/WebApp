using System.Collections.Generic;
using HyruleCompendiumProject.Model;

namespace HyruleCompendiumProject.Repository
{
    public sealed class SortById : IComparer<DataEntry>
    {
        public int Compare(DataEntry x, DataEntry y)
        {
            return x.Id.CompareTo(y.Id);
        }
    }
}
