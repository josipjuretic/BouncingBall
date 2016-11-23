using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsite.Pood.BouncingBall;

namespace Vsite.Pood.BouncingBallTests
{
    [TestClass]
    public class LineInterSectionsTest
    {
        [TestMethod]
        public void LineIntersections_GetIntersectionForTwoOrtogonalLines()
        {
            Line horizontal = new Line(new PointD(5, 3), new PointD(9, 3));
            LineIntersections li = new LineIntersections(horizontal);
            Line vertical = new Line(new PointD(6, 2), new PointD(6, 7));
            PointD p = li.GetIntersection(vertical);
            Assert.AreEqual(6, p.X, 1e-5);
            Assert.AreEqual(3, p.Y, 1e-5);
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionForTwoNonIntersectingLines()
        {
            Line horizontal = new Line(new PointD(5, 3), new PointD(5, 7));
            LineIntersections li = new LineIntersections(horizontal);
            Line vertical = new Line(new PointD(6, 4), new PointD(6, 7));
            Assert.IsNull(li.GetIntersection(vertical));
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionForTwoParallelHorizontalLines()
        {
            Line horizontal1 = new Line(new PointD(5, 3), new PointD(9, 3));
            LineIntersections li = new LineIntersections(horizontal1);
            Line horizontal2 = new Line(new PointD(5, 4), new PointD(9, 4));
            Assert.IsNull(li.GetIntersection(horizontal2));
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionForTwoTouchingOrtogonalLines()
        {
            Line horizontal = new Line(new PointD(5, 3), new PointD(9, 3));
            LineIntersections li = new LineIntersections(horizontal);
            Line vertical = new Line(new PointD(9, 3), new PointD(9, 7));
            PointD p = li.GetIntersection(vertical);
            Assert.AreEqual(9, p.X, 1e-5);
            Assert.AreEqual(3, p.Y, 1e-5);
        }

        [TestMethod]
        public void LineIntersections_GetIntersectionForTwoInclinedLines()
        {
            Line line1 = new Line(new PointD(0, 0), new PointD(4, 4));
            LineIntersections li = new LineIntersections(line1);
            Line line2 = new Line(new PointD(0, 4), new PointD(4, 0));
            PointD p = li.GetIntersection(line2);
            Assert.AreEqual(2, p.X, 1e-5);
            Assert.AreEqual(2, p.Y, 1e-5);
        }

        [TestMethod]
        public void LineIntersection_SetCollisionPointsReturnsOneCollisionPointCollectionForNoCollisionPlane()
        {
            Line line1 = new Line(new PointD(0, 0), new PointD(4, 4));
            LineIntersections li = new LineIntersections(line1);
            CollisionPlane plane1 = new CollisionPlane(new PointD(3, 0), new PointD(3, 4));
            List <CollisionPlane> collisionPlanes = new List<CollisionPlane> { plane1 };
            var CollisionPoints = li.GetHashCodeCollisionPoints{ collisionPlanes};
            
            Assert.AreEqual(1, GetCollisionPoints.Count());
            Assert.AreEqual(3, GetCollisionPoints.First().Point.x ie-5);
            Assert.AreEqual(3, GetCollisionPoints.First().Point.y ie-5);
        }

        [TestMethod]
        public void LineIntersection_SetCollisionPointsReturnsTwoCollisionPointForTwoPlaneColladingCollectionForNoCollisionPlane()
        {
            Line line1 = new Line(new PointD(0, 3), new PointD(4, 7));
            LineIntersections li = new LineIntersections(line1);
            CollisionPlane plane1 = new CollisionPlane(new PointD(3, 0), new PointD(3, 4));
            CollisionPlane plane1 = new CollisionPlane(new PointD(0, 2), new PointD(0, 2));
            List<CollisionPlane> collisionPlanes = new List<CollisionPlane> { plane1 };
            var CollisionPoints = li.GetCollisionPoints{ collisionPlanes};

            Assert.AreEqual(2, CollisionPoints.Count());
            Assert.AreEqual(3, CollisionPoints.First().Point.x ie - 5);
            Assert.AreEqual(3, CollisionPoints.First().Point.y ie - 5);
        }
    }
}
