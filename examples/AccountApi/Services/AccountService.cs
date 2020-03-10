using System.Net;
using System;
using System.Threading;
using System.Threading.Tasks;
using AccountApi.Models;
using RestEase;
using Reinforce.RestApi;
using System.Collections.Generic;
using Reinforce.BulkApi2;
using Reinforce.BulkApi2.Models;
using System.IO;
using CsvHelper;
using Reinforce.RestApi.Models;

namespace AccountApi.Services
{
    public class AccountService : IAccountService
    {
        private readonly ICloseOrAbortAJob _closeOrAbortAJob;
        private readonly ICreateAJob _createAJob;
        private readonly IQuery _query;
        private readonly ISObjectRows _sObjectRows;
        private readonly IUploadJobData _uploadJobData;
        private readonly IComposite _composite;

        public AccountService(
            ICloseOrAbortAJob closeOrAbortAJob,
            ICreateAJob createAJob,
            IQuery query,
            ISObjectRows sObjectRows,
            IUploadJobData uploadJobData,
            IComposite composite
        )
        {
            _closeOrAbortAJob = closeOrAbortAJob ?? throw new ArgumentNullException(nameof(closeOrAbortAJob));
            _createAJob = createAJob ?? throw new ArgumentNullException(nameof(createAJob));
            _query = query ?? throw new ArgumentNullException(nameof(query));
            _sObjectRows = sObjectRows ?? throw new ArgumentNullException(nameof(sObjectRows));
            _uploadJobData = uploadJobData ?? throw new ArgumentNullException(nameof(uploadJobData));
            _composite = composite;
        }

        public async Task<IEnumerable<Account>> ReadAsync(CancellationToken cancellationToken)
        {
            var response = await _query.GetAsync<Account>("Select Id, Name From Account", cancellationToken);
            return response.Records;
        }

        public async Task<Account> ReadAsync(string id, CancellationToken cancellationToken)
        {
            try
            {
                return await _sObjectRows.GetAsync<Account>(nameof(Account), id, cancellationToken);
            }
            catch (ApiException exception) when (exception.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public Task UpdateAsync(string id, AccountUpdate account, CancellationToken cancellationToken)
        {
            return _sObjectRows.PatchAsync(nameof(Account), id, account, cancellationToken);
        }

        public async Task UpdateAsync(IEnumerable<Account> accounts, CancellationToken cancellationToken)
        {
            var job = await _createAJob.PostAsync(new CreateAJobRequest(nameof(Account), OperationEnum.Update), cancellationToken);
            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memoryStream))
                using (var csvWriter = new CsvWriter(streamWriter))
                {
                    streamWriter.NewLine = "\n";
                    csvWriter.WriteRecords(accounts);
                }
                await _uploadJobData.PutAsync(job.Id, memoryStream.ToArray(), cancellationToken);
            }
            await _closeOrAbortAJob.PatchAsync(job.Id, new CloseOrAbortAJobRequest(JobStateEnum.UploadComplete), cancellationToken);
        }

        public async Task<CompositeResponse> Composite(CancellationToken cancellationToken)
        {
            var compRequest = new CompositeRequest()
            {
                items = new List<CompositeRequestItem>()
                {
                    new CompositeRequestItem()
                    {
                        url = "/services/data/v47.0/sobjects/account/0013O00000DXklUQAT",
                        method = "GET",
                        referenceId = "1"
                    }
                    ,
                    new CompositeRequestItem()
                    {
                        url = "/services/data/v47.0/sobjects/account/0013O00000DXklUQAT",
                        method = "GET",
                        referenceId = "2"
                    }
                }
            };

            var resp = await _composite.PostAsync<CompositeResponse>(compRequest, cancellationToken);

            return resp;

        }
    }
}