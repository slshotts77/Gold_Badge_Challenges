using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_Two_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]        
        public void Test()
        {
            Queue nextClaim = new Queue();
            nextClaim.Enqueue("ClaimID");
            nextClaim.Enqueue("ClaimType");
            nextClaim.Enqueue("Description");
            nextClaim.Enqueue("ClaimAmount");
            nextClaim.Enqueue("DateOfIncident");
            nextClaim.Enqueue("DateOfClaim");
            nextClaim.Enqueue("IsValid");

            Console.WriteLine($"Number of claims = {nextClaim.Count}");
                     
            Console.WriteLine($"The peek of nextClaim is: {nextClaim.Peek()}");
            Console.WriteLine($"Number of claims = {nextClaim.Count}");
        }
    }
}
