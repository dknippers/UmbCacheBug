using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Infrastructure.Scoping;

namespace UmbCacheBug;

[Route("/api/[controller]/[action]")]
public class DatabaseCacheController
(
    IScopeProvider scopeProvider
) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Clear()
    {
        using var scope = scopeProvider.CreateScope();
        scope.Database.Execute("DELETE FROM cmsContentNu");
        scope.Complete();

        return Ok("Database cache cleared");
    }
}
