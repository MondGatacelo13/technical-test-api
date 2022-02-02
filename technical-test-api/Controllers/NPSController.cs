using api.common.Model;
using api.Common.Interfaces;
using api.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace technical_test_api.Controllers
{
    public class QueryParameters
    {
        [Required,]
        public string parkCode { get; set; }
        [Required]
        public string arriving { get; set; }
    }

    public class ResQueryParameters
    {
        [Required,]
        public string resId { get; set; }
        [Required]
        public string userEmail { get; set; }
    }


    [ApiController]
    [Route("api/[controller]")]
    public class NPSController : ControllerBase
    {
        private readonly ILogger<NPSController> _logger;
        private readonly ICustomerBusinessLayer _customerBusinessLayer;
        

        public NPSController(ILogger<NPSController> logger, ICustomerBusinessLayer customerBusinessLayer)
        {
            _logger = logger;
            _customerBusinessLayer = customerBusinessLayer;
        }


        // GET api/NPS/Customers

        [HttpGet("Customers")]

        public async Task<IActionResult> GetCustomersByParkCodeAndArriving([FromQuery] QueryParameters parameters)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var customers = await _customerBusinessLayer.GetCustomersByParkCodeAndArriving(parameters.parkCode, parameters.arriving);
                    if((int)customers.Count() > 0 && customers != null)
                    {
                        return Ok(customers);
                    }                 
                }
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseError()
                {
                    Message = "You must filter the contents of the talktoguests table by finding only records matching parkCode and arrived (exact string match).",
                    StatusCode = StatusCodes.Status400BadRequest
                });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseError()
                {
                    Message = ex.ToString(),
                    StatusCode = StatusCodes.Status500InternalServerError
                });
            }
        }


        [HttpPost("SaveCustomerResponse")]

        public async Task<IActionResult> SaveCustomerResponse([FromBody] ResQueryParameters parameters)
        {
            var model = new SpokenToGuestModel
            {
                ResId = parameters.resId,
                UserEmail = parameters.userEmail
            };
            try
            {
                if (ModelState.IsValid)
                {
                 await _customerBusinessLayer.SaveCustomerResponse(model);
                    return Ok();
                }
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseError()
                {
                    Message = "A new record must be inserted into the spokenToGuests table with these details.",
                    StatusCode = StatusCodes.Status400BadRequest
                });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseError()
                {
                    Message = ex.ToString(),
                    StatusCode = StatusCodes.Status500InternalServerError
                });
            }
        }
    }
}
