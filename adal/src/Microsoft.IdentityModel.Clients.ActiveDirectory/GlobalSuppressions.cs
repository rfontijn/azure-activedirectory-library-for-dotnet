﻿// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.

[assembly:
    System.Diagnostics.CodeAnalysis.SuppressMessage("Sonar Code Smell", "S101:Types should be named in camel case",
        Justification = "Acceptable use of common initialism", Scope = "type",
        Target = "~T:Microsoft.IdentityModel.Clients.ActiveDirectory.IWebUIFactory")]
[assembly:
    System.Diagnostics.CodeAnalysis.SuppressMessage("Sonar Vulnerability", "S2068:Credentials should not be hard-coded",
        Justification = "This is not a password, it's the name of a claim", Scope = "member",
        Target = "~F:Microsoft.IdentityModel.Clients.ActiveDirectory.OAuthParameter.Password")]
[assembly:
    System.Diagnostics.CodeAnalysis.SuppressMessage("Sonar Vulnerability", "S2068:Credentials should not be hard-coded",
        Justification = "This is not a password, it's the name of a claim", Scope = "member",
        Target = "~F:Microsoft.IdentityModel.Clients.ActiveDirectory.OAuthGrantType.Password")]
[assembly:
    System.Diagnostics.CodeAnalysis.SuppressMessage("Sonar Code Smell", "S3237:\"value\" parameters should be used",
        Justification = "Setter is required by JSON serializer but there is no intent to deserialize this type",
        Scope = "member",
        Target = "~P:Microsoft.IdentityModel.Clients.ActiveDirectory.JsonWebToken.JWTHeader.Algorithm")]
[assembly:
    System.Diagnostics.CodeAnalysis.SuppressMessage("Sonar Code Smell", "S3237:\"value\" parameters should be used",
        Justification = "Setter is required by JSON serializer but there is no intent to deserialize this type",
        Scope = "member", Target = "~P:Microsoft.IdentityModel.Clients.ActiveDirectory.JsonWebToken.JWTHeader.Type")]
[assembly:
    System.Diagnostics.CodeAnalysis.SuppressMessage("Sonar Code Smell", "S3237:\"value\" parameters should be used",
        Justification = "Setter is required by JSON serializer but there is no intent to deserialize this type",
        Scope = "member",
        Target =
            "~P:Microsoft.IdentityModel.Clients.ActiveDirectory.JsonWebToken.JWTHeaderWithCertificate.X509CertificateThumbprint")]
[assembly:
    System.Diagnostics.CodeAnalysis.SuppressMessage("Sonar Code Smell", "S1075:URIs should not be hardcoded",
        Justification = "This is an arbitrary placeholder value", Scope = "member",
        Target = "~F:Microsoft.IdentityModel.Clients.ActiveDirectory.Constant.SsoPlaceHolderUri")]
[assembly:
    System.Diagnostics.CodeAnalysis.SuppressMessage("Sonar Code Smell",
        "S1118:Utility classes should not have public constructors",
        Justification =
            "We cannot change the class/ctor to be static/private as this is now part of the new released public API surface",
        Scope = "type", Target = "~T:Microsoft.IdentityModel.Clients.ActiveDirectory.LoggerCallbackHandler")]
[assembly:
    System.Diagnostics.CodeAnalysis.SuppressMessage("Sonar Code Smell",
        "S2223:Non-constant static fields should not be visible",
        Justification = "We cannot change the visibility as this is now part of the new released public API surface",
        Scope = "member",
        Target = "~F:Microsoft.IdentityModel.Clients.ActiveDirectory.LoggerCallbackHandler.UseDefaultLogging")]