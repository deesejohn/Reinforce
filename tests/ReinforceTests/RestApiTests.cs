using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Newtonsoft.Json;
using Reinforce.RestApi;
using Reinforce.RestApi.Models;
using RestEase;
using Xunit;

namespace ReinforceTests
{
    public class RestApiTests
    {
        [Theory, AutoData]
        public async Task IDescribeGlobal(DescribeGlobalResponse expected)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<IDescribeGlobal>(handler);
            var result = await api.GetAsync(CancellationToken.None);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath("/services/data/v46.0/sobjects");
        }

        [Theory, AutoData]
        public async Task IDescribeLayouts(IEnumerable<DescribeLayout> expected)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<IDescribeLayouts>(handler);
            var result = await api.GetAsync(CancellationToken.None);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath("/services/data/v46.0/sobjects/Global/describe/layouts");
        }

        [Theory, AutoData]
        public async Task IDescribeLayoutsBySObjectName(IEnumerable<DescribeLayout> expected, string sObjectName)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<IDescribeLayouts>(handler);
            var result = await api.GetAsync(sObjectName, CancellationToken.None);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/describe/layouts");
        }

        [Theory, AutoData]
        public async Task ILimits(IDictionary<string, Limit> expected)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<ILimits>(handler);
            var result = await api.GetAsync(CancellationToken.None);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath("/services/data/v46.0/limits");
        }

        [Theory, AutoData]
        public async Task IQuery(QueryResponse<string> expected)
        {
            var query = "Select Id, Name From Account Where Active__c = 'Yes'";
            var handler = SetupHandler(expected);
            var api = SetupApi<IQuery>(handler);
            var result = await api.GetAsync<string>(query, CancellationToken.None);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath("/services/data/v46.0/query?q=Select+Id%2C+Name+From+Account+Where+Active__c+%3D+%27Yes%27");
        }

        [Theory, AutoData]
        public async Task IResourcesByVersion(IDictionary<string, string> expected)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<IResourcesByVersion>(handler);
            var result = await api.GetAsync(CancellationToken.None);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath("/services/data/v46.0");
        }

        [Theory, AutoData]
        public async Task ISObjectApprovalLayouts(ApprovalLayoutsResponse expected, string sObjectName)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<ISObjectApprovalLayouts>(handler);
            var result = await api.GetAsync(sObjectName, CancellationToken.None);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/describe/approvalLayouts");
        }

        [Theory, AutoData]
        public async Task ISObjectApprovalLayoutsByApprovalProcessName(ApprovalLayoutsResponse expected, string sObjectName, string approvalProcessName)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<ISObjectApprovalLayouts>(handler);
            var result = await api.GetAsync(sObjectName, approvalProcessName, CancellationToken.None);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/describe/approvalLayouts/{approvalProcessName}");
        }

        [Theory, AutoData]
        public async Task ISObjectBasicInformation(SObjectBasicInformationResponse expected, string sObjectName)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<ISObjectBasicInformation>(handler);
            var result = await api.GetAsync(sObjectName, CancellationToken.None);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}");
        }

        [Theory, AutoData]
        public async Task ISObjectBasicInformationPost(SuccessResponse expected, string sObjectName, IDictionary<string, string> sObject)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<ISObjectBasicInformation>(handler);
            var result = await api.PostAsync(sObjectName, sObject, CancellationToken.None);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}");
        }

        [Theory, AutoData]
        public async Task ISObjectBlobRetrieve(string sObjectName, string id, string blobField)
        {
            var handler = SetupHandler(null);
            var api = SetupApi<ISObjectBlobRetrieve>(handler);
            await api.GetAsync(sObjectName, id, blobField, CancellationToken.None);
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/{id}/{blobField}");
        }

        [Theory, AutoData]
        public async Task ISObjectCompactLayouts(CompactLayoutsResponse expected, string sObjectName)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<ISObjectCompactLayouts>(handler);
            var result = await api.GetAsync(sObjectName, CancellationToken.None);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/describe/compactLayouts");
        }

        [Theory, AutoData]
        public async Task ISObjectDescribe(string sObjectName)
        {
            var handler = SetupHandler(null);
            var api = SetupApi<ISObjectDescribe>(handler);
            await api.GetAsync(sObjectName, CancellationToken.None);
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/describe");
        }
        
        [Theory, AutoData]
        public async Task ISObjectGetDeleted(SObjectGetDeleted expected, string sObjectName)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<ISObjectGetDeleted>(handler);
            var result = await api.GetAsync(sObjectName);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/deleted");
        }

        [Theory, AutoData]
        public async Task ISObjectGetDeletedEnd(SObjectGetDeleted expected, string sObjectName, DateTimeOffset endDateAndTime)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<ISObjectGetDeleted>(handler);
            var result = await api.GetAsync(sObjectName, endDateAndTime: endDateAndTime);
            result.Should().BeEquivalentTo(expected);
            var end = Uri.EscapeDataString(endDateAndTime.ToString("yyyy-MM-ddTHH:mm:ss+00:00"));
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/deleted?end={end}");
        }

        [Theory, AutoData]
        public async Task ISObjectGetDeletedStart(SObjectGetDeleted expected, string sObjectName, DateTimeOffset startDateAndTime)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<ISObjectGetDeleted>(handler);
            var result = await api.GetAsync(sObjectName, startDateAndTime);
            result.Should().BeEquivalentTo(expected);
            var start = Uri.EscapeDataString(startDateAndTime.ToString("yyyy-MM-ddTHH:mm:ss+00:00"));
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/deleted?start={start}");
        }

        [Theory, AutoData]
        public async Task ISObjectGetDeletedStartAndEnd(SObjectGetDeleted expected, string sObjectName, DateTimeOffset startDateAndTime, DateTimeOffset endDateAndTime)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<ISObjectGetDeleted>(handler);
            var result = await api.GetAsync(sObjectName, startDateAndTime, endDateAndTime, CancellationToken.None);
            result.Should().BeEquivalentTo(expected);
            var start = Uri.EscapeDataString(startDateAndTime.ToString("yyyy-MM-ddTHH:mm:ss+00:00"));
            var end = Uri.EscapeDataString(endDateAndTime.ToString("yyyy-MM-ddTHH:mm:ss+00:00"));
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/deleted?start={start}&end={end}");
        }

        [Theory, AutoData]
        public async Task ISObjectGetUpdated(SObjectGetUpdatedResponse expected, string sObjectName)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<ISObjectGetUpdated>(handler);
            var result = await api.GetAsync(sObjectName);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/updated");
        }

        [Theory, AutoData]
        public async Task ISObjectGetUpdatedEnd(SObjectGetUpdatedResponse expected, string sObjectName, DateTimeOffset endDateAndTime)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<ISObjectGetUpdated>(handler);
            var result = await api.GetAsync(sObjectName, endDateAndTime: endDateAndTime);
            result.Should().BeEquivalentTo(expected);
            var end = Uri.EscapeDataString(endDateAndTime.ToString("yyyy-MM-ddTHH:mm:ss+00:00"));
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/updated?end={end}");
        }

        [Theory, AutoData]
        public async Task ISObjectGetUpdatedStart(SObjectGetUpdatedResponse expected, string sObjectName, DateTimeOffset startDateAndTime)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<ISObjectGetUpdated>(handler);
            var result = await api.GetAsync(sObjectName, startDateAndTime);
            result.Should().BeEquivalentTo(expected);
            var start = Uri.EscapeDataString(startDateAndTime.ToString("yyyy-MM-ddTHH:mm:ss+00:00"));
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/updated?start={start}");
        }

        [Theory, AutoData]
        public async Task ISObjectGetUpdatedStartAndEnd(SObjectGetUpdatedResponse expected, string sObjectName, DateTimeOffset startDateAndTime, DateTimeOffset endDateAndTime)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<ISObjectGetUpdated>(handler);
            var result = await api.GetAsync(sObjectName, startDateAndTime, endDateAndTime, CancellationToken.None);
            result.Should().BeEquivalentTo(expected);
            var start = Uri.EscapeDataString(startDateAndTime.ToString("yyyy-MM-ddTHH:mm:ss+00:00"));
            var end = Uri.EscapeDataString(endDateAndTime.ToString("yyyy-MM-ddTHH:mm:ss+00:00"));
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/updated?start={start}&end={end}");
        }

        [Theory, AutoData]
        public async Task ISObjectNamedLayouts(string sObjectName, string layoutName)
        {
            var handler = SetupHandler(null);
            var api = SetupApi<ISObjectNamedLayouts>(handler);
            await api.GetAsync(sObjectName, layoutName);
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/describe/namedLayouts/{layoutName}");
        }
        
        [Theory, AutoData]
        public async Task ISObjectRows(string expected, string sObjectName, string id)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<ISObjectRows>(handler);
            var result = await api.GetAsync<string>(sObjectName, id);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/{id}");
        }

        [Theory, AutoData]
        public async Task ISObjectRowsWithFields(string expected, string sObjectName, string id)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<ISObjectRows>(handler);
            var result = await api.GetAsync<string>(sObjectName, id, "Id,Name", CancellationToken.None);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/{id}?fields=Id%2CName");
        }

        [Theory, AutoData]
        public async Task ISObjectRowsPatch(string sObjectName, string id, string sObject)
        {
            var handler = SetupHandler(null);
            var api = SetupApi<ISObjectRows>(handler);
            await api.PatchAsync(sObjectName, id, sObject);
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/{id}");
        }

        [Theory, AutoData]
        public async Task ISObjectRowsDelete(string sObjectName, string id)
        {
            var handler = SetupHandler(null);
            var api = SetupApi<ISObjectRows>(handler);
            await api.DeleteAsync(sObjectName, id);
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/{id}");
        }

        [Theory, AutoData]
        public async Task ISObjectRowsByExternalId(string expected, string sObjectName, string fieldName, string fieldValue)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<ISObjectRowsByExternalId>(handler);
            var result = await api.GetAsync<string>(sObjectName, fieldName, fieldValue);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/{fieldName}/{fieldValue}");
        }

        [Theory, AutoData]
        public async Task ISObjectRowsByExternalIdPatch(SuccessResponse expected, string sObjectName, string fieldName, string fieldValue, string sObject)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<ISObjectRowsByExternalId>(handler);
            var result = await api.PatchAsync(sObjectName, fieldName, fieldValue, sObject);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/{fieldName}/{fieldValue}");
        }

        [Theory, AutoData]
        public async Task ISObjectRowsByExternalIdDelete(string expected, string sObjectName, string fieldName, string fieldValue)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<ISObjectRowsByExternalId>(handler);
            await api.DeleteAsync(sObjectName, fieldName, fieldValue);
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/{fieldName}/{fieldValue}");
        }

        [Theory, AutoData]
        public async Task ISObjectRowsByExternalIdPost(SuccessResponse expected, string sObjectName, string id, string sObject)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<ISObjectRowsByExternalId>(handler);
            var result = await api.PostAsync(sObjectName, id, sObject);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/{id}");
        }

        [Theory, AutoData]
        public async Task IVersions(IEnumerable<VersionResponse> expected)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<IVersions>(handler);
            var result = await api.GetAsync();
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data");
        }

        [Theory, AutoData]
        public async Task ISObjectPlatformAction(ObjectDescribeResponse expected, string query)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<ISObjectPlatformAction>(handler);
            var result = await api.GetAsync(query);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v46.0/sobjects/PlatformAction?q={query}");
        }

        [Theory, AutoData]
        public async Task ISObjectQuickActions(IEnumerable<QuickAction> expected, string sObjectName)
        {
            var handler = SetupHandler(expected);
            var api = SetupApi<ISObjectQuickActions>(handler);
            var result = await api.GetAsync(sObjectName);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/quickActions");
        }

        [Theory, AutoData]
        public async Task ISObjectQuickActionsByActionName(string sObjectName, string actionName)
        {
            var handler = SetupHandler(null);
            var api = SetupApi<ISObjectQuickActions>(handler);
            await api.GetAsync(sObjectName, actionName);
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/quickActions/{actionName}");
        }

        [Theory, AutoData]
        public async Task ISObjectQuickActionsPostByActionName(string sObjectName, string actionName, QuickAction action)
        {
            var handler = SetupHandler(null);
            var api = SetupApi<ISObjectQuickActions>(handler);
            await api.PostAsync(sObjectName, actionName, action);
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/quickActions/{actionName}");
        }

        [Theory, AutoData]
        public async Task ISObjectQuickActionsDescribe(string sObjectName, string actionName)
        {
            var handler = SetupHandler(null);
            var api = SetupApi<ISObjectQuickActions>(handler);
            await api.DescribeAsync(sObjectName, actionName);
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/quickActions/{actionName}/describe");
        }

        [Theory, AutoData]
        public async Task ISObjectQuickActionsDefaultValues(string sObjectName, string actionName)
        {
            var handler = SetupHandler(null);
            var api = SetupApi<ISObjectQuickActions>(handler);
            await api.DefaultValuesAsync(sObjectName, actionName);
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/quickActions/{actionName}/defaultValues");
        }

        [Theory, AutoData]
        public async Task ISObjectQuickActionsDefaultValuesByContextId(string sObjectName, string actionName, string contextId)
        {
            var handler = SetupHandler(null);
            var api = SetupApi<ISObjectQuickActions>(handler);
            await api.DefaultValuesAsync(sObjectName, actionName, contextId);
            handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/quickActions/{actionName}/defaultValues/{contextId}");
        }

        private class MockHttpMessageHandler : HttpMessageHandler
        {
            public HttpRequestMessage Request;
            public Task<HttpResponseMessage> ResponseMessage;
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Request = request;
                return ResponseMessage;
            }
            public void ConfirmPath(string path)
            {
                Request.RequestUri.PathAndQuery.Should().Be(path);
            }
        }

        private MockHttpMessageHandler SetupHandler(object response)
        {
            return new MockHttpMessageHandler
            {
                ResponseMessage = Task.FromResult(new HttpResponseMessage()
                {
                    Content = new StringContent(JsonConvert.SerializeObject(response)),
                })
            };
        }

        private TApi SetupApi<TApi>(MockHttpMessageHandler handler)
        {
            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost")
            };
            return RestClient.For<TApi>(client);
        }
    }
}
