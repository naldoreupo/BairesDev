using BairesDev.Exam.Domain.Interface;
using BairesDev.Exam.Domain.Model;
using BairesDev.Exam.Transversal;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using Microsoft.AspNetCore.Mvc;
using BairesDev.Exam.Domain.Entity.Model;

namespace BairesDev.Exam.Domain.Domain
{
    public class PersonDomain : InterfacePersonDomain
    {
        private readonly IMapper _mapper;

        public PersonDomain(IMapper mapper)
        {
            this._mapper = mapper;
        }

        public async Task<Response<FileOutputDTO>> GetPeopleFileWithIds(IFormFile file)
        {
            try
            {
                var listPeople = await GetPeopleFromFile(file);
                var outputFile = await CreateFileWithIds(listPeople);
                var fileOutputDTO = new FileOutputDTO() { OutputFile = outputFile };

                return new Response<FileOutputDTO>()
                {
                    Status = true,
                    Message = GlobalVariables.operationCompletedMessage,
                    Data = fileOutputDTO
                };
            }
            catch (Exception ex)
            {
                return new Response<FileOutputDTO>()
                {
                    Status = false,
                    Message = ex.Message
                };
            }
        }

        private async Task<List<PersonDTO>> GetPeopleFromFile(IFormFile file)
        {
            var response = new List<PersonDTO>();

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (true)
                {
                    string line = await reader.ReadLineAsync();
                    if (line == null) { break; }
                    var person = line.Split('|').ToList();

                    int personId, numberOfRecommendations, numberOfConnections;
                    int.TryParse(person[0], out personId);
                    int.TryParse(person[6], out numberOfRecommendations);
                    int.TryParse(person[7], out numberOfConnections);

                    response.Add(new PersonDTO()
                    {
                        PersonId = personId,
                        Name = person[1].ToString(),
                        LastName = person[2].ToString(),
                        CurrentRole = person[3].ToString(),
                        Country = person[4].ToString(),
                        Industry = person[5].ToString(),
                        NumberOfRecommendations = numberOfRecommendations,
                        NumberOfConnections = numberOfConnections
                    });
                }
            }
            return response.OrderByDescending(person => person.NumberOfRecommendations)
                            .Take(GlobalVariables.numberPotentialClients).ToList();
        }

        private async Task<FileStreamResult> CreateFileWithIds(List<PersonDTO> listPeople)
        {
            var listIds = string.Empty;

            listPeople.ForEach(person => listIds += person.PersonId.ToString() + "\n");

            byte[] byteArray = Encoding.ASCII.GetBytes(listIds);
            MemoryStream stream = new MemoryStream(byteArray);
            StreamReader reader = new StreamReader(stream);

            return new FileStreamResult(stream, GlobalVariables.outputMimeType) { FileDownloadName = GlobalVariables.outputFileName };
        }
    }
}
