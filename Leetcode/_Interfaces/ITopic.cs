using Leetcode._Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode._Interfaces
{
    public interface ITopicLC 
    { 
        public void Cases(){ }
    }

    public interface IArrayLC : ITopicLC { }
    public interface IMatrixLC : ITopicLC { }

    public interface IStringLC : ITopicLC { }
    public interface IStringMatchingLC : ITopicLC { }


    public interface ISortingLC : ITopicLC { }
    public interface IBinarySearchLC : ITopicLC { }
    public interface ITwoPointersLC : ITopicLC { }
    public interface IOrderedSetLC : ITopicLC { }

    public interface IBitManipulationLC : ITopicLC { }
    public interface IHashTableLC : ITopicLC { }
    public interface ICountingLC : ITopicLC { }
    public interface IPrefixSumLC : ITopicLC { }
    public interface ISlidingWindowLC : ITopicLC { }
    public interface IOrderedMapLC : ITopicLC { }
    public interface IMemoizationLC : ITopicLC { }

    public interface ITreeLC : ITopicLC { }
    public interface IBinarySearchTreeLC : ITopicLC { }
    public interface ISegmentTreeLC : ITopicLC { }

    public interface IMathLC : ITopicLC { }
    public interface IGreedyLC : ITopicLC { }
    public interface INumberTheoryLC : ITopicLC { }
    public interface ISimulationLC : ITopicLC { }

    public interface IStackLC : ITopicLC { }
    public interface IQueueLC : ITopicLC { }
    public interface IRecursionLC : ITopicLC { }
    public interface IPriorityQueueLC : ITopicLC { }
    public interface IMonotonicQueueLC : ITopicLC { }

    public interface IMonotonicStackLC : ITopicLC { }
    public interface IGrafLC : ITopicLC { }
    public interface IBreadthFirstLC : ITopicLC { }
    public interface IHeapLC : ITopicLC { }
    public interface IShortestPathLC : ITopicLC { }
    public interface IDepthFirstSearchLC : ITopicLC { }
    public interface IEulerianCircuitLC : ITopicLC { }
    public interface IDynamicProgrammingLC : ITopicLC { }
    public interface IIteratorLC : ITopicLC { }



}
