using System.Collections.Generic;
using System;

namespace QuickPuzzle.EntityFactory
{
    public class EntityDescription
    {
        public string Name { get; set; }

        public ICollection<PropertyDescription> Properties { get; set; }
    }
}
