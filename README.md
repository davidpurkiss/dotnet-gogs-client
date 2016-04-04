# dotnet-gogs-client (alpha)
.Net Client for Gogs

[![Build status](https://ci.appveyor.com/api/projects/status/q60gshgxeg7gp0lj?svg=true)](https://ci.appveyor.com/project/davidpurkiss/dotnet-gogs-client)

Cross-Platform support targeting the following platforms.

* .NET Framework 4.5 and 4.5.1
* ASP.NET Core 5.0
* Windows Universal 10
* Windows Phone 8.1
* Windows Phone Silverlight 8

**Note:** This library is currently in an Alpha state and does not support the complete Gogs REST API.

## Gogs Overview
Gogs is a simple, lightweight and cross-platform git service written in [Go](https://golang.org/).

See [https://gogs.io/](https://gogs.io/) for more details.

## Getting Started
Install the Gogs client library using NuGet.
```
Install-Package Gogs.Dnx
```

To create a client and authenticate, use the following code.

```
GogsClient client = new GogsClient("http://mygogsserver.com");
client.Authenticate("User", "Password");
```

`GogsClient.Authenticate` will return an access token but it is also stored in the client instance for all future requests.

## Documentation
Please see the [go-gogs-client wiki](https://github.com/gogits/go-gogs-client/wiki) for documentation at this stage.

## API Implementation Status
The following is the implementation list pulled from the [go-gogs-client wiki](https://github.com/gogits/go-gogs-client/wiki) and modified here to show the status for the .Net client.
- [ ] Activity
    - [ ] Feeds
    - [ ] Notifications
    - [ ] Starring
    - [ ] Watching
- [ ] Gists
- [ ] Git Data
    - [ ] Blobs
    - [ ] Commits
    - [ ] References
    - [ ] Tags
    - [ ] Trees
- [ ] Issues
    - [ ] Assignees
    - [ ] Comments
    - [ ] Labels
    - [ ] Milestones
- [ ] Miscellaneous
    - [ ] Gitignore
    - [ ] Markdown
- [ ] Organizations
    - [ ] Members
    - [ ] Teams
    - [ ] Webhooks
- [ ] Pull Requests
    - [ ] Review Comments
- [ ] Repositories
    - [ ] Collaborators
    - [ ] Comments
    - [ ] Commits
    - [ ] Contents
    - [ ] Deploy Keys
    - [ ] Forks
    - [ ] Releases
    - [ ] Webhooks
- [ ] Users
    - [ ] Emails
    - [ ] Followers
    - [ ] Public Keys
- [x] Administration
    - [-] Stats
    - [x] Users
    - [ ] Organizations
    - [x] Repositories
    - [x] Authentications
    - [-] Configuration
    - [ ] Notices

## Contributing
Please create an issue if you are interested in contributing.