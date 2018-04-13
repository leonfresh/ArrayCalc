using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ArrayCalc.Controllers
{
    public class ArrayCalcController : ApiController
    {
        [HttpGet]
        [Route("api/arraycalc/reverse")]
        public HttpResponseMessage Reverse([FromUri] int[] productIds)
        {
            if (productIds == null || productIds.Length <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "[Reverse Method] Error: Please provide at least one productIds.");
            }

            int[] reverseProductIds = new int[productIds.Length];

            int count = 0;
            for (int i = productIds.Length - 1; i >= 0; i--)
            {
                reverseProductIds[count] = productIds[i];
                count++;
            }

            return Request.CreateResponse(HttpStatusCode.OK, reverseProductIds);
        }

        [HttpGet]
        [Route("api/arraycalc/deletepart")]
        public HttpResponseMessage DeletePart([FromUri] int[] productIds, [FromUri] int position)
        {
            if (productIds == null || productIds.Length <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "[DeletePart Method] Error: Please provide at least one productIds.");
            }

            if (position == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "[DeletePart Method] Error: Please provide the position variable.");
            }

            if (position > productIds.Length)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, 
                    "[DeletePart Method] Error: Position integer was higher than the number of products.");
            }

            int[] modifiedProductIds = new int[productIds.Length - 1];

            bool positionDeleted = false;
            for (var i = 0; i < modifiedProductIds.Length; i++)
            {
                if (i == position - 1)
                {
                    positionDeleted = true;
                }

                modifiedProductIds[i] = positionDeleted ? productIds[i + 1] : productIds[i];
            }

            return Request.CreateResponse(HttpStatusCode.OK, modifiedProductIds);
        }
    }
}