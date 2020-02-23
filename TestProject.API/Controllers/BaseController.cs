using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestProject.Application.DTOs;
using TestProject.Domain.Models;

namespace TestProject.API.Controllers
{
    public class BaseController : Controller
    {
        protected new IActionResult Response(DomainStatusCodes statusCode, object result = null)
        {
            HttpStatusCode httpStatusCode;

            switch (statusCode)
            {
                case DomainStatusCodes.Success:
                    httpStatusCode = HttpStatusCode.OK;
                    break;
                case DomainStatusCodes.ValidationError:
                case DomainStatusCodes.UniqueViolation:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    break;
                case DomainStatusCodes.RecordNotFound:
                    httpStatusCode = HttpStatusCode.NotFound;
                    break;
                case DomainStatusCodes.RecordAlreadyExists:
                    httpStatusCode = HttpStatusCode.Conflict; // security vulnerability? Its okay for test project
                    break;
                default:
                    httpStatusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            return StatusCode((int)httpStatusCode, new ResponseDTO { StatusCode = statusCode, Result = result });
        }
    }
}
