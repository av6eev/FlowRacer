using System;
using System.Collections.Generic;
using Level.Pull;
using Specification;

namespace Level.Specification
{
    [Serializable]
    public class LevelSpecification : BaseSpecification
    {
        public List<LevelPullDescription> Pulls;
    }
}