using AutoMapper;
using BairesDev.Exam.Domain.Domain;
using BairesDev.Exam.Domain.Entity.Model;
using BairesDev.Exam.Transversal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Moq;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BairesDev.Exam.Domain.Test
{
    public class PersonDomainTest
    {
        [Fact]
        public async Task GetPeopleFileWithIds_ValidTypeReturn_ReturnFileAsync()
        {
            // Arrange
            var mockMapper = new Mock<IMapper>();
            var personDomain = new PersonDomain(mockMapper.Object);
            string test = "4567|arturo|perez|teleport engineering manager|Germany|Telecommunications|2|176";
            byte[] byteArray = Encoding.ASCII.GetBytes(test);
            MemoryStream stream = new MemoryStream(byteArray);
            IFormFile file = new FormFile(stream, 0, stream.Length, null, "people.in");

            // Act
            var result = await personDomain.GetPeopleFileWithIds(file);

            // Assert
            Assert.IsType<Response<FileOutputDTO>>(result);
            Assert.True(result.Status);
            Assert.Equal("people.out", result.Data.OutputFile.FileDownloadName);
            Assert.Equal("text/plain", result.Data.OutputFile.ContentType);
        }
    }
}
