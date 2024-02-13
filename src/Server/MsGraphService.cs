using Microsoft.Graph;
using Microsoft.Graph.Models;

namespace ReactBffProxy.Server;

public class MsGraphService
{
    private readonly GraphServiceClient _graphServiceClient;

    public MsGraphService(GraphServiceClient graphServiceClient)
    {
        _graphServiceClient = graphServiceClient;
    }

    public async Task<User?> GetGraphApiUser()
    {
        return await _graphServiceClient
            .Me
            .GetAsync();
    }

    public async Task<string> GetGraphApiProfilePhoto()
    {
        try
        {
            // Get user photo
            await using var photoStream = await _graphServiceClient
                .Me
                .Photo
                .Content
                .GetAsync();
            var photoByte = ((MemoryStream)photoStream).ToArray();
            var photo = Convert.ToBase64String(photoByte);

            return photo;
        }
        catch
        {
            return string.Empty;
        }
    }
}
