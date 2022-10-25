using System;
using System.Collections.Generic;
using System.Text;

namespace PolygonEditor
{
    public class Perpendicular
    {
        public Edge e1;
        public Edge e2;
        public Func<float, float> fe1;
        public Func<float, float> fe2;
        public (float? e1, float? e2) X;
        public (float? e1, float? e2) Y;
        public float Ae1;
        public float Ae2;
        public Perpendicular(Edge e1, Edge e2)
        {
            this.e1 = e1;
            this.e2 = e2;
            fe1 = null;
            fe2 = null;
            X = Y = (null,null);
            Ae1 = 0;
            Ae2 = 0;
        }
        static public bool SameVertex(Polygon.Vertex v1, Polygon.Vertex v2) => v1.X == v2.X && v1.Y == v2.Y;
        public Polygon.Vertex GetMoveVertex()
        {
            if (SameVertex(e1.v2, e2.v1))
                return e2.v2;
            if (SameVertex(e1.v1, e2.v2))
                return e2.v1;
            return e2.v2;
        }
        public void MakePerpendicular()
        {
            float a = e1.v1.X, b = e1.v1.Y;
            float c = e1.v2.X, d = e1.v2.Y;
            float e = e2.v1.X, f = e2.v1.Y;
            float g = e2.v2.X, h = e2.v2.Y;

            Polygon.Vertex move = GetMoveVertex();
            Edge nextedge = Property.workingpolyg.edges[SameVertex(move, e2.v1) ? (e2.v1.prev, e2.v1) : (e2.v2, e2.v2.next)];
            Polygon.Vertex premove = SameVertex(nextedge.v1, e2.v2) ? e2.v1 : e2.v2;
            Edge copyedge = new Edge(nextedge);
            Polygon.Vertex oldone = new Polygon.Vertex(move);
            float A = (d - b) / (c - a); // e1!
            if (A == 0)
            {
                //pozioma krecha;
                float newY = SameVertex(nextedge.v1, e2.v2) ? e2.v2.Y + (nextedge.v2.Y - nextedge.v1.Y) / 2 : e2.v1.Y + (nextedge.v1.Y - nextedge.v2.Y) / 2;
                Func<float, float> fnext = Functions.by2points(nextedge.v1, nextedge.v2);
                if (nextedge.perpe != null)
                {
                    if (fnext!= null)
                        newY = fnext(premove.X);
                }
                if (fnext == null && nextedge.perpe != null)
                {
                    premove.X = move == nextedge.v1 ? nextedge.v1.X : nextedge.v2.X;
                    X.e2 = premove.X;
                }
                else
                {
                    move.X = premove.X;
                    move.Y = newY;
                    X.e2 = move.X;
                }
                Y.e1 = d;
                fe1 = null;
                fe2 = null;
                var len = new LengthRelation(move,oldone);
                len.MoveEdges();
            }
            else if (float.IsNaN(A) || float.IsInfinity(A))
            {
                //pionowa krecha!
                float newY = premove.Y; //SameVertex(nextedge.v1, e2.v2) ? e2.v2.X + (nextedge.v2.X - nextedge.v1.X) / 2 : e2.v1.X+ (nextedge.v1.X - nextedge.v2.X) / 2;
                Func<float, float> fnext = Functions.by2points(nextedge.v1, nextedge.v2);
                if (nextedge.perpe != null)
                {
                    if (fnext != null)
                        newY = fnext(move.X);
                }
                if (nextedge.perpe != null)
                {
                    premove.Y = move == nextedge.v1 ? nextedge.v1.Y : nextedge.v2.Y;
                    Y.e2 = premove.Y;
                }
                else
                {
                    move.Y = newY;
                    Y.e2 = move.Y;
                }
                X.e1 = a;
                fe1 = null;
                fe2 = null;
                var len = new LengthRelation(move, oldone);
                len.MoveEdges();
            }
            else
            {
                // coś innego!
                float newA = -1 / A;
                float B = premove.Y - newA * premove.X;
                float Be1 = e1.v1.Y - A * e1.v1.X;
                fe1 = (x) => { return A * x + Be1; };
                Ae1 = A;
                Polygon.Vertex pastmove = move == nextedge.v1 ? nextedge.v2 : nextedge.v1;
                
                float newx = move.X + (pastmove.X - move.X) / 2;
                
                float nextA = (nextedge.v2.Y - nextedge.v1.Y) / (nextedge.v2.X - nextedge.v1.X);
                float nextB = nextedge.v1.Y - nextA * nextedge.v1.X;
                float tmp = (nextB - B) / (newA - nextA);
                if (float.IsNaN(tmp) == false && float.IsInfinity(tmp) == false)
                    newx = tmp;
                fe2 = (x) => { return newA * newx + B; }; // move

                Ae2 = newA;
                move.X = newx;
                move.Y = fe2(newx);

                var len = new LengthRelation(move, oldone,2);
                len.MoveEdges();
            }
        }
    }
}
