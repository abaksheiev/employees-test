using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using WebTest.Contracts.Enums;
using WebTest.Models.ApiDtos;

namespace WebTest.UnitTests
{
    public class EndToEndTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private const string ApiPath = "/Employees";

        private readonly WebApplicationFactory<Program> _factory;

        private readonly HttpClient _httpClient;

        public EndToEndTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }

        [Fact]
        public async Task WhenGetList_ShouldBeReturnOk()
        {
            // Act
            HttpResponseMessage response = await _httpClient.GetAsync($"{ApiPath}/list");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task WhenGetFilterWithEmptyParameters_ShouldBeReturnBadRequest()
        {
            // Act
            HttpResponseMessage response = await _httpClient.GetAsync($"{ApiPath}/filter");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task WhenGetList_ShouldBeReturnAllRecords() 
        {
            // Act
            HttpResponseMessage response = await _httpClient.GetAsync($"{ApiPath}/list");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<ResponseResult<List<EmployeeApiDto>>>(content);

            // Could be failed in case logic of number is changed
            responseData.Should().NotBeNull();
            responseData.Data.Count.Should().Be(24);
        }

        [Theory]
        [InlineData(EmployeeFilter.Age, 5)]
        [InlineData(EmployeeFilter.Salary, 5)]
        [InlineData(EmployeeFilter.Name, 5)]
        public async Task WhenGetListFilterWithLimit_ShouldBeLimitRecords(EmployeeFilter sorted, int limit)
        {
            // Act
            var url = $"{ApiPath}/filter?Sort={sorted}&Limit={limit}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<ResponseResult<List<EmployeeApiDto>>>(content);

            // Could be failed in case logic of number is changed
            responseData.Should().NotBeNull();
            responseData.Data.Should().NotBeNull();
            responseData.Data.Count.Should().Be(limit);
        }
    }
}
