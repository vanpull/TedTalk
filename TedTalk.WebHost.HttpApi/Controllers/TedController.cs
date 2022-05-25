using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TedTalk.Application.Contracts;
using TedTalk.Application.Contracts.Dtos;

namespace TedTalk.WebHost.HttpApi.Controllers
{
    [Route("api/v1/teds")]
    public class TedController : ApiControllerBase
    {
        private readonly ITedService _tedService;
        public TedController(ITedService tedService)
        {
            _tedService = tedService;
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<ApiResponse> GetAll()
        {
            try
            {
                var teds = _tedService.GetAll().Skip(0).Take(100).ToList();
                var result = new OkResponse("Request successful", teds);
                return Ok(result);
            }
            catch (Exception)
            {
                //Log exception 
                return Error();
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<ApiResponse> GetById(int id)
        {
            try
            {
                var teds = _tedService.GetById(id);
                var result = new OkResponse("Request successful", teds);
                return Ok(result);
            }
            catch (Exception)
            {
                //Log exception 
                return Error();
            }
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<ApiResponse> Add([FromBody]TedDto ted)
        {
            try
            {
                _tedService.Add(ted);
                var result = new OkResponse("Record has been added successfully");
                return Ok(result);
            }
            catch (Exception)
            {
                //Log exception 
                return Error();
            }
        }

        [HttpPut("")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<ApiResponse> Update([FromBody] TedDto tedDto)
        {
            try
            {
                if(tedDto == null)
                {
                    return BadRequest();
                }

                if (tedDto.Id == 0)
                {
                    return BadRequest();
                }

                var ted = _tedService.GetById(tedDto.Id);

                if (ted == null)
                {
                    return NotFound();
                }

                //TODD: Model validation

                _tedService.Update(tedDto);
                var result = new OkResponse("Record has been updated successfully");
                return Ok(result);
            }
            catch (Exception)
            {
                //Log exception 
                return Error();
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<ApiResponse> Delete(int id)
        {
            try
            {   
                if (id == 0)
                {
                    return BadRequest();
                }

                var ted = _tedService.GetById(id);

                if (ted == null)
                {
                    return NotFound();
                }


                _tedService.Delete(id);
                var result = new OkResponse("Record has been deleted successfully");
                return Ok(result);
            }
            catch (Exception)
            {
                //Log exception 
                return Error();
            }
        }



    }
}
