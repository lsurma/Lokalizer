namespace Lokalizer.Abstractions;

public interface IRequestSender
{
    public Task<TResponse> SendAsync<TResponse>(object request, CancellationToken cancellationToken = default);
}