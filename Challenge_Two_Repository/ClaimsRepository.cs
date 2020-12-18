using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Two_Repository
{
    public class ClaimsRepository
    {
        private Queue<ClaimInfo> _queueOfClaims = new Queue<ClaimInfo>();

        // Create
        public void AddNewClaim(ClaimInfo newClaim)
        {
            _queueOfClaims.Enqueue(newClaim);
        }
         
        // Read
        public Queue<ClaimInfo> GetAllClaims()
        {
                return _queueOfClaims;
        }
               
        // Next Claim
        public ClaimInfo NextClaim()
        {
            ClaimInfo nextClaim = _queueOfClaims.Peek();
            Console.WriteLine("Here is the next claim:");
            Console.WriteLine($"ClaimID: {nextClaim.ClaimID}\n");
            Console.WriteLine($"ClaimType: {nextClaim.ClaimType}\n");
            Console.WriteLine($"Description: {nextClaim.Description}\n");
            Console.WriteLine($"ClaimAmount: {nextClaim.ClaimAmount}\n");
            Console.WriteLine($"DateOfIncident: {nextClaim.DateOfIncident}\n");
            Console.WriteLine($"DateOfClaim: {nextClaim.DateOfClaim}\n");
            Console.WriteLine($"IsValid: {nextClaim.IsValid}");
            return nextClaim;
        }

        //Remove Fist Queue
        public void NextInQueue()
        {
            _queueOfClaims.Dequeue();        
        }
    }
}
