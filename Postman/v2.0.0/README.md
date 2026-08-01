This folder contains a [Postman](https://www.postman.com/) collection of all possible [Trakt.tv](https://trakt.tv/) [API](https://docs.trakt.tv/) requests for **Trakt.NET v2.0.0**.
The collection is saved in the file [Trakt_API_Requests.postman_collection.json](Trakt_API_Requests.postman_collection.json).

There are also two environments ([Trakt_API_Environment.postman_environment.json](Trakt_API_Environment.postman_environment.json) and [Trakt_API_Staging_Environment.postman_environment.json](Trakt_API_Staging_Environment.postman_environment.json)).

Both are used to store different kind of variables like Client-ID and -Secret, Access Token and Refresh Token, Note IDs, Smart List IDs, Sync IDs, and other variables which are used in the collection.
The environments are just different in that one is for normal API usage (https://api.trakt.tv) and the other one for staging API usage (https://api-staging.trakt.tv).
