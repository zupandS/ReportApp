using MediatR;
using Report.Contracts.Requests;
using Report.Contracts.Responses;

namespace Report.Application.Commands.AuthCommands.RefreshCommand
{
    public class RefreshCommand : IRequest<RefreshResponse>
    {
        public RefreshRequest RefreshModel { get; set; }
    }
}