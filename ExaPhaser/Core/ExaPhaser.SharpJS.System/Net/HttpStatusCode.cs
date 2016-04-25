namespace SharpJS.System.Net
{
    public enum HttpStatusCode
    {
        Continue = 100,

        SwitchingProtocols,

        OK = 200,

        Created,

        Accepted,

        NonAuthoritativeInformation,

        NoContent,

        ResetContent,

        PartialContent,

        MultipleChoices = 300,

        Ambiguous = 300,

        MovedPermanently,

        Moved = 301,

        Found,

        Redirect = 302,

        SeeOther,

        RedirectMethod = 303,

        NotModified,

        UseProxy,

        Unused,

        RedirectKeepVerb,

        TemporaryRedirect = 307,

        BadRequest = 400,

        Unauthorized,

        PaymentRequired,

        Forbidden,

        NotFound,

        MethodNotAllowed,

        NotAcceptable,

        ProxyAuthenticationRequired,

        RequestTimeout,

        Conflict,

        Gone,

        LengthRequired,

        PreconditionFailed,

        RequestEntityTooLarge,

        RequestUriTooLong,

        UnsupportedMediaType,

        RequestedRangeNotSatisfiable,

        ExpectationFailed,

        UpgradeRequired = 426,

        InternalServerError = 500,

        NotImplemented,

        BadGateway,

        ServiceUnavailable,

        GatewayTimeout,

        HttpVersionNotSupported
    }
}