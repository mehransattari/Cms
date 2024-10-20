﻿namespace Common.AspNetCore;

public enum AppStatusCode
{
    Success = 1,
    NotFound = 2,
    BadRequest = 3,
    LogicError = 4,
    UnAuthorize = 5,
    ServerError
}