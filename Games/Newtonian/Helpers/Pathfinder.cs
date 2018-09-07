using System;
using System.Collections.Generic;
using System.Linq;

namespace Joueur.cs.Games.Newtonian.Helpers
{
    public static class Pathfinder
    {
        /// <summary>Finds shortest path from any start to any target</summary>
        /// <typeparam name="T">Node type</typeparam>
        /// <param name="starts">Starting points for the path</param>
        /// <param name="targets">Targets for the path</param>
        /// <param name="getNeighbors">Function in the following format: node => neighbors</param>
        /// <param name="getCost">Cost function given a node. Return null if the given node is blocked. Format is node => cost</param>
        /// <returns>A <see cref="IEnumerable{T}"/> containing <see cref="Node{T}"/> to represent the path. <see cref="Node{T}"/> wraps <see cref="T"/> and contains metadata about the node.</returns>
        public static IEnumerable<Node<T>> FindPath<T>(IEnumerable<T> starts, IEnumerable<T> targets, Func<T, IEnumerable<T>> getNeighbors, Func<T, float?> getCost)
        {
            return Pathfinder.FindPath(starts, targets, getNeighbors, getCost, node => 0);
        }

        /// <summary>Finds shortest path from any start to any target</summary>
        /// <typeparam name="T">Node type</typeparam>
        /// <param name="starts">Starting points for the path</param>
        /// <param name="targets">Targets for the path</param>
        /// <param name="getNeighbors">Function in the following format: node => neighbors</param>
        /// <param name="getCost">Cost function given a node and its parent. Return null if the given node is blocked. Format is (node, parent) => cost</param>
        /// <returns>A <see cref="IEnumerable{T}"/> containing <see cref="Node{T}"/> to represent the path. <see cref="Node{T}"/> wraps <see cref="T"/> and contains metadata about the node.</returns>
        public static IEnumerable<Node<T>> FindPath<T>(IEnumerable<T> starts, IEnumerable<T> targets, Func<T, IEnumerable<T>> getNeighbors, Func<T, Node<T>, float?> getCost)
        {
            return Pathfinder.FindPath(starts, targets, getNeighbors, getCost, node => 0);
        }

        /// <summary>Finds shortest path from any start to any target</summary>
        /// <typeparam name="T">Node type</typeparam>
        /// <param name="starts">Starting points for the path</param>
        /// <param name="targets">Targets for the path</param>
        /// <param name="getNeighbors">Function in the following format: node => neighbors</param>
        /// <param name="getCost">Cost function given a node. Return null if the given node is blocked. Format is node => cost</param>
        /// <param name="getH">Heuristic function given a node. It will not be called if <see cref="getCost"/> returns null for the given node.</param>
        /// <returns>A <see cref="IEnumerable{T}"/> containing <see cref="Node{T}"/> to represent the path. <see cref="Node{T}"/> wraps <see cref="T"/> and contains metadata about the node.</returns>
        public static IEnumerable<Node<T>> FindPath<T>(IEnumerable<T> starts, IEnumerable<T> targets, Func<T, IEnumerable<T>> getNeighbors, Func<T, float?> getCost, Func<T, float> getH) {
            return Pathfinder.FindPath(starts, targets, getNeighbors, (node, parent) => getCost(node), getH);
        }

        /// <summary>Finds shortest path from any start to any target</summary>
        /// <typeparam name="T">Node type</typeparam>
        /// <param name="starts">Starting points for the path</param>
        /// <param name="targets">Targets for the path</param>
        /// <param name="getNeighbors">Function in the following format: node => neighbors</param>
        /// <param name="getCost">Cost function given a node and its parent. Return null if the given node is blocked. Format is (node, parent) => cost</param>
        /// <param name="getH">Heuristic function given a node. It will not be called if <see cref="getCost"/> returns null for the given node.</param>
        /// <returns>A <see cref="IEnumerable{T}"/> containing <see cref="Node{T}"/> to represent the path. <see cref="Node{T}"/> wraps <see cref="T"/> and contains metadata about the node.</returns>
        public static IEnumerable<Node<T>> FindPath<T>(IEnumerable<T> starts, IEnumerable<T> targets, Func<T, IEnumerable<T>> getNeighbors, Func<T, Node<T>, float?> getCost, Func<T, float> getH)
        {
            HashSet<T> targetSet = new HashSet<T>(targets);
            if (!targetSet.Any())
                return Enumerable.Empty<Node<T>>();

            MinHeap<Node<T>> open = new MinHeap<Node<T>>(starts.Select(s => new Node<T>(s, null, 0, getH(s))));
            HashSet<T> closed = new HashSet<T>();

            while (open.Any())
            {
                Node<T> cur = open.Pop();
                closed.Add(cur.Value);

                // Check if done (ensure it checks first node)
                if (targetSet.Contains(cur.Value))
                {
                    return Pathfinder.BuildPath(cur);
                }

                // Add neighbors
                foreach (T neighbor in getNeighbors(cur.Value))
                {
                    if (closed.Contains(neighbor) || open.Any(n => n.Value.Equals(neighbor)))
                        continue;

                    // Create next node
                    float? cost = getCost(neighbor, cur);

                    // Check if done (bypass wall check)
                    if (targetSet.Contains(neighbor))
                    {
                        return Pathfinder.BuildPath(new Node<T>(neighbor, cur, cost ?? 0, 0));
                    }
                    
                    // Check if wall
                    if (cost.HasValue)
                    {
                        // Add the neighbor to the open heap
                        open.Add(new Node<T>(neighbor, cur, (float) cost, getH(neighbor)));
                    }
                }
            }

            return Enumerable.Empty<Node<T>>();
        }

        private static IEnumerable<Node<T>> BuildPath<T>(Node<T> lastNode)
        {
            // Stacks are FILO, so basically it'll reverse the order of the elements you add to it
            Stack<Node<T>> nodes = new Stack<Node<T>>();
            while (lastNode != null)
            {
                nodes.Push(lastNode);
                lastNode = lastNode.Parent;
            }

            return nodes;
        }

        /// <inheritdoc />
        /// <summary>Wrapper for a node in a graph containing nodes of type <see cref="!:T" /></summary>
        /// <typeparam name="T">The type of node being wrapped by this class</typeparam>
        public class Node<T> : IComparable<Node<T>>
        {
            public T Value { get; }
            public Node<T> Parent { get; }

            /// <summary>Cost to move from <see cref="Parent"/> to here</summary>
            public float Cost { get; }

            /// <summary>Cost to move from start to here</summary>
            public float G { get; }

            /// <summary>Estimated distance from target</summary>
            public float H { get; }

            /// <summary>Total weight of this node</summary>
            public float F => this.G + this.H;

            public Node(T value, Node<T> parent, float cost, float h)
            {
                this.Value = value;
                this.Parent = parent;
                this.Cost = cost;
                this.H = h;

                // Cause this is more efficient than doing this in the getter
                this.G = (this.Parent?.G ?? 0) + this.Cost;
            }

            public int CompareTo(Node<T> other) => this.F.CompareTo(other.F);
            
            public static explicit operator T(Node<T> self) => self.Value;
        }
    }
}
