using System.Threading.Tasks;
using System.Web.Http.Description;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BairesDev.Exam.Domain.Interface;
using BairesDev.Exam.Service.Model;
using BairesDev.Exam.Transversal;
using System.IO;
using System.Text;
using System;
using Microsoft.AspNetCore.Http;
using System.Net;
using NSwag.Annotations;

namespace BairesDev.Exam.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly InterfacePersonDomain _personDomain;
        public PersonController(IMapper mapper, InterfacePersonDomain personDomain)
        {
            this._personDomain = personDomain;
            this._mapper = mapper;
        }

        // POST: api/Person
        /// <param name="input">file with data of potential clients</param>
        /// <returns>List of ids of 100 best potentials clients </returns>
        /// <response code="200">operation successfully completed</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post([FromForm] PersonInputModel input)
        {
            try
            {
                var fileDTO = await _personDomain.GetPeopleFileWithIds(input.file);
                if (fileDTO.Status)
                {
                    var personOutputModel = _mapper.Map<Response<PersonOutputModel>>(fileDTO);
                    return personOutputModel.Data.OutputFile;
                }
                else
                {
                    //LogException(e);
                    throw new Exception(fileDTO.Message);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
