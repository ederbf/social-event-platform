﻿using ActivityPlatform.Domain;

namespace ActivityPlatform.Application.Services.Authentication
{
    public record AuthenticationResult(
        User User,
        string Token
    );
}
