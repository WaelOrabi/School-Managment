using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Bases
{
    public class ResponseHandler
    {
        private Response<T> CreateResponse<T>(
            HttpStatusCode statusCode,
            bool succeeded,
            string message,
            T data = default,
            object meta = null)
        {
            return new Response<T>
            {
                StatusCode = statusCode,
                Succeeded = succeeded,
                Message = message ?? "Operation Successful",
                Data = data,
                Meta = meta
            };
        }


        public Response<T> GenerateDeletedResponse<T>()
        {
            return CreateResponse<T>(HttpStatusCode.OK, true, "Deleted Successfully");
        }

 
        public Response<T> GenerateSuccessResponse<T>(T entity, object meta = null)
        {
            return CreateResponse(HttpStatusCode.OK, true, "Added Successfully", entity, meta);
        }

 
        public Response<T> GenerateUnauthorizedResponse<T>()
        {
            return CreateResponse<T>(HttpStatusCode.Unauthorized, false, "Unauthorized");
        }

  
        public Response<T> GenerateBadRequestResponse<T>(string message = null)
        {
            return CreateResponse<T>(HttpStatusCode.BadRequest, false, message ?? "Bad Request");
        }
        public Response<T> GenerateUnprocessableEntityResponse<T>(string message = null)
        {
            return CreateResponse<T>(HttpStatusCode.UnprocessableEntity, false, message ?? "Unprocessable Entity");
        }
        public Response<T> GenerateNotFoundResponse<T>(string message = null)
        {
            return CreateResponse<T>(HttpStatusCode.NotFound, false, message ?? "Not Found");
        }
        public Response<T> GenerateCreatedResponse<T>(T entity, object meta = null)
        {
            return CreateResponse(HttpStatusCode.Created, true, "Created Successfully", entity, meta);
        }
    }
}
