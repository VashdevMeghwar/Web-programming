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
        public int f;
        public int g;
        public int h; 
        public int x;
        public int y;
        public int px;
        public int py;
    }

   




    public class PathFinder
    {
        private byte[,] mGrid = null;
        private PriorityQueue<PathFinderNode> mOpen = new PriorityQueue<PathFinderNode>(new ComparePFNode());
        private List<PathFinderNode> mClose = new List<PathFinderNode>();
        private bool mStopped = true;
        private bool mStop = false;
        private int hFormula = 1;
        private bool mDiagonals = true;
        private int mHEstimate = 2;
        private int mSearchLimit = 10000;
        private double mCompletedTime = 0;
        private bool[,] isHurdle;

        public PathFinder(byte[,] grid,bool[,]nopath)
        {
            if (grid == null)
                throw new Exception("Grid cannot be null");
            if (nopath == null)
                throw new Exception("no hurdle");
            isHurdle = nopath;
            mGrid = grid;
        }

        //public bool Stopped
        //{
        //    get { return mStopped; }
        //}

        //public int Formula
        //{
        //    get { return hFormula; }
        //    set { hFormula = value; }
        //}

        //public bool Diagonals
        //{
        //    get { return mDiagonals; }
        //    set { mDiagonals = value; }
        //}



        //public int HeuristicEstimate
        //{
        //    get { return mHEstimate; }
        //    set { mHEstimate = value; }
        //}

        //public int SearchLimit
        //{
        //    get { return mSearchLimit; }
        //    set { mSearchLimit = value; }
        //}

        //public double CompletedTime
        //{
        //    get { return mCompletedTime; }
        //    set { mCompletedTime = value; }
        //}

        //public void FindPathStop()
        //{
        //    mStop = true;
        //}

        public List<PathFinderNode> FindPath(Point start, Point end,int num)
        {

            PathFinderNode parentNode;
            bool found = false;
            int gridX = mGrid.GetUpperBound(0);
            int gridY = mGrid.GetUpperBound(1);

            mStop = false;
            mStopped = false;
            mOpen.Clear();
            mClose.Clear();

            parentNode.g = 0;
            parentNode.h = mHEstimate;
            parentNode.f = parentNode.g + parentNode.h;
            parentNode.x = start.X;
            parentNode.y = start.Y;
            parentNode.px = parentNode.x;
            parentNode.py = parentNode.y;
            mOpen.Push(parentNode);
            while (mOpen.Count > 0 && !mStop)
            {
                parentNode = mOpen.Pop();
                if (parentNode.x == end.X && parentNode.y == end.Y)
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
                sbyte[,] direction = new sbyte[4, 2] { { 0, -1 }, { 1, 0 }, { 0, 1 }, { -1, 0 } };
                for (int i = 0; i < 4; i++)
                {
                    PathFinderNode newNode=new PathFinderNode();
                    newNode.x = parentNode.x + direction[i, 0];
                    newNode.y = parentNode.y + direction[i, 1];
                    if (newNode.x < 0 || newNode.y < 0 || newNode.x > num-1 || newNode.y > num-1)
                        continue;
                    if (isHurdle[newNode.x, newNode.y])
                        continue;
                    int newG = parentNode.g + mGrid[newNode.x, newNode.y];

                    if (newG == parentNode.g)
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

                    if (foundInOpenIndex != -1 && mOpen[foundInOpenIndex].g <= newG)
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
                    if (foundInCloseIndex != -1 && mClose[foundInCloseIndex].g <= newG)
                        continue;

                    newNode.px = parentNode.x;
                    newNode.py = parentNode.y;
                    newNode.f = newG;

                    newNode.f = mHEstimate * (Math.Abs(newNode.x - end.X) + Math.Abs(newNode.y - end.Y));
                    newNode.f = newNode.f + newNode.f;
                    mOpen.Push(newNode);
                }
                mClose.Add(parentNode);
            }
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
                if (x.f > y.f)
                    return 1;
                else if (x.f < y.f)
                    return -1;
                return 0;
            }
        }
    }
}
