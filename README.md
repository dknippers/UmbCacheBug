# Umbraco 17.2.0: Rebuild Database Cache bug

Rebuilding the database cache from scratch is broken in Umbraco 17.2.0.

This seems to occur in websites with at least 2 configured languages and property values that vary by culture.

## Steps to reproduce

1. Clone this repo
2. `dotnet run`
3. [Open the homepage](https://localhost:44323)
    - Observe the property values:
        - Checkbox: `True`
        - Textstring: `"123"`
4. Visit [/api/databasecache/clear](https://localhost:44323/api/databasecache/clear)
    - This runs `DELETE FROM cmsContentNu`
5. Restart the website (IMPORTANT)
    - The homepage does not load at the moment, ignore that.
6. [Open Umbraco > Settings > Published Status](https://localhost:44323/umbraco/section/settings/dashboard/published-status)
    - Rebuild Database Cache
    - Reload Memory Cache
7. [Open the homepage](https://localhost:44323)
8. Observe the property values are now missing:
    - Checkbox: `False`
    - Textstring: `""`

The above steps work fine in Umbraco 17.1.0 and the property values are NOT missing.

Something was probably changed in 17.2.0 with respect to the database cache which introduced this bug.
