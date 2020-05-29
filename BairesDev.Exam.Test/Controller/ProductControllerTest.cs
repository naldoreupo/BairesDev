using AutoMapper;
using Moq;
using Number8.Exam.Domain.Domain;
using Number8.Exam.Domain.Interface;
using Number8.Exam.Domain.Model;
using Number8.Exam.Service.Controllers;
using Number8.Exam.Transversal;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Tests
{
    public class ProductControllerTest
    {
        private  IMapper _mapper;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var mockProductDomain = new Mock<InterfaceProductDomain>();
            var product = new ProductDTO();
                        
            mockProductDomain.Setup(x => x.Save(product))
                .Returns(Task.FromResult(new Response<bool>()
                {
                    Status = true,
                    Message = "Operation completed"
                })
                );

            var controller = new ProductController(_mapper, mockProductDomain.Object);
       

        }


        //[Fact]
        //[Trait("Controller", "SaveUserCloudAccount_ShouldThrowException_WhenTokenIsEmpty")]
        //public void SaveUserCloudAccount_ShouldThrowException_WhenTokenIsEmpty()
        //{
        //    HttpContext.Current = new HttpContext(new HttpRequest(null, "http://tempuri.org", null), new HttpResponse(null));

        //    var cloudAccountInput = new CloudAccountInputModel
        //    {
        //        RefreshToken = string.Empty
        //    };

        //    _cloudAuthorizationServiceMock.Save(Arg.Any<CloudAccountInputModel>()).ReturnsForAnyArgs(new CloudAccountOutputModel());

        //    var result = _cloudAuthorizationController.SaveCloudAccount((int)ExternalProvidersEnum.GoogleDrive, cloudAccountInput);

        //    var negotiatedResult = Assert.IsType<NegotiatedContentResult<string>>(result);
        //    negotiatedResult.Content.Should().BeEquivalentTo("RefreshToken", "because RefreshToken is an empty string which is invalid");
        //    negotiatedResult.StatusCode.Should().BeEquivalentTo((HttpStatusCode)422, "because 422 is the standard status code to return for invalid data");
        //}
    }
}