using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
namespace AI_Assignment.Algo
{
    public struct PathFinderNode
    {
        public int F;
        public int G;
        public int H;  // f = gone + heuristic
        public int x;
        public int y;
        public int px; // Parent
        public int py;
    }

    public enum PathFinderNodeType
    {
        Start = 1,
        End = 2,
        Open = 4,
        Close = 8,
        Current = 16,
        Path = 32
    }





    public class PathFinder
    {
        private byte[,] mGrid = null;
        private PriorityQueueB<PathFinderNode> mOpen = new PriorityQueueB<PathFinderNode>(new ComparePFNode());
        private List<PathFinderNode> mClose = new List<PathFinderNode>();
        private bool mStopped = true;
        private bool mStop = false;
        private int hFormula = 1;
        private bool mDiagonals = true;
        private int mHEstimate = 2;
        private int mSearchLimit = 2000;
        private double mCompletedTime = 0;

        public PathFinder(byte[,] grid)
        {
            if (grid == null)
                throw new Exception("Grid cannot be null");

            mGrid = grid;
        }

        public bool Stopped
        {
            get { return mStopped; }
        }

        public int Formula
        {
            get { return hFormula; }
            set { hFormula = value; }
        }

        public bool Diagonals
        {
            get { return mDiagonals; }
            set { mDiagonals = value; }
        }



        public int HeuristicEstimate
        {
            get { return mHEstimate; }
            set { mHEstimate = value; }
        }

        public int SearchLimit
        {
            get { return mSearchLimit; }
            set { mSearchLimit = value; }
        }

        public double CompletedTime
        {
            get { return mCompletedTime; }
            set { mCompletedTime = value; }
        }

        public void FindPathStop()
        {
            mStop = true;
        }

        public List<PathFinderNode> FindPath(Point start, Point end)
        {

            PathFinderNode parentNode;
            bool found = false;
            int gridX = mGrid.GetUpperBound(0);
            int gridY = mGrid.GetUpperBound(1);

            mStop = false;
            mStopped = false;
            mOpen.Clear();
            mClose.Clear();

            sbyte[,] direction;
            if (mDiagonals)
                direction = new sbyte[8, 2] { { 0, -1 }, { 1, 0 }, { 0, 1 }, { -1, 0 }, { 1, -1 }, { 1, 1 }, { -1, 1 }, { -1, -1 } };
            else
                direction = new sbyte[4, 2] { { 0, -1 }, { 1, 0 }, { 0, 1 }, { -1, 0 } };


            parentNode.G = 0;
            parentNode.H = mHEstimate;
            parentNode.F = parentNode.G + parentNode.H;
            parentNode.x = start.X;
            parentNode.y = start.Y;
            parentNode.px = parentNode.x;
            parentNode.py = parentNode.y;
            mOpen.Push(parentNode);
            while (mOpen.Count > 0 && !mStop)
            {
                parentNode = mOpen.Pop();

                if (parentNode.x == end.X && parentNode.x == end.Y)
                {
                    mClose.Add(parentNode);
                    found = true;
                    break;
                }

                if (mClose.Count > mSearchLimit)
                {
                    mStopped = true;
                    return null;
                }
                for (int i = 0; i < (mDiagonals ? 8 : 4); i++)
                {
                    PathFinderNode newNode;
                    newNode.x = parentNode.x + direction[i, 0];
                    newNode.y = parentNode.y + direction[i, 1];

                    if (newNode.x < 0 || newNode.y < 0 || newNode.x >= gridX || newNode.y >= gridY)
                        continue;

                    int newG = parentNode.G + mGrid[newNode.x, newNode.y];


                    if (newG == parentNode.G)
                    {
                        continue;
                    }

                    int foundInOpenIndex = -1;
                    for (int j = 0; j < mOpen.Count; j++)
                    {
                        if (mOpen[j].x == newNode.x && mOpen[j].y == newNode.y)
                        {
                            foundInOpenIndex = j;
                            break;
                        }
                    }
                    if (foundInOpenIndex != -1 && mOpen[foundInOpenIndex].G <= newG)
                        continue;

                    int foundInCloseIndex = -1;
                    for (int j = 0; j < mClose.Count; j++)
                    {
                        if (mClose[j].x == newNode.x && mClose[j].y == newNode.y)
                        {
                            foundInCloseIndex = j;
                            break;
                        }
                    }
                    if (foundInCloseIndex != -1 && mClose[foundInCloseIndex].G <= newG)
                        continue;

                    newNode.px = parentNode.x;
                    newNode.py = parentNode.y;
                    newNode.G = newG;

                    newNode.H = mHEstimate * (Math.Abs(newNode.x - end.X) + Math.Abs(newNode.y - end.Y));
                    newNode.F = newNode.G + newNode.H;
                    mOpen.Push(newNode);
                }

                mClose.Add(parentNode);
            }

            // mCompletedTime = HighResolutionTime.GetTime();
            if (found)
            {
                PathFinderNode fNode = mClose[mClose.Count - 1];
                for (int i = mClose.Count - 1; i >= 0; i--)
                {
                    if (fNode.px == mClose[i].x && fNode.py == mClose[i].y || i == mClose.Count - 1)
                    {
                        fNode = mClose[i];
                    }
                    else
                        mClose.RemoveAt(i);
                }
                mStopped = true;
                return mClose;
            }
            mStopped = true;
            return null;
        }
        internal class ComparePFNode : IComparer<PathFinderNode>
        {
            public int Compare(PathFinderNode x, PathFinderNode y)
            {
                if (x.F > y.F)
                    return 1;
                else if (x.F < y.F)
                    return -1;
                return 0;
            }
        }
    }
}
