﻿//------------------------------------------------------------------------------
//
// Copyright (c) Microsoft Corporation.
// All rights reserved.
//
// This code is licensed under the MIT License.
//
// Permission is hereby granted free of charge to any person obtaining a copy
// of this software and associated documentation files(the "Software") to deal
// in the Software without restriction including without limitation the rights
// to use copy modify merge publish distribute sublicense and / or sell
// copies of the Software and to permit persons to whom the Software is
// furnished to do so subject to the following conditions :
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND EXPRESS OR
// IMPLIED INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM DAMAGES OR OTHER
// LIABILITY WHETHER IN AN ACTION OF CONTRACT TORT OR OTHERWISE ARISING FROM
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Microsoft.Identity.Core.Instance
{
    internal class B2CAuthority : AadAuthority
    {
        public const string Prefix = "tfp"; // The http path of B2C authority looks like "/tfp/<your_tenant_name>/..."
        public const string B2CCanonicalAuthorityTemplate = "https://{0}/{1}/{2}/{3}/";

        internal B2CAuthority(string authority, bool validateAuthority) : base(authority, validateAuthority)
        {
            Uri authorityUri = new Uri(authority);
            string[] pathSegments = authorityUri.AbsolutePath.Substring(1).Split(new [] { '/'}, StringSplitOptions.RemoveEmptyEntries);
            if (pathSegments.Length < 3)
            {
                throw new ArgumentException(CoreErrorMessages.B2cAuthorityUriInvalidPath);
            }

            CanonicalAuthority = string.Format(CultureInfo.InvariantCulture, B2CCanonicalAuthorityTemplate, authorityUri.Authority,
                pathSegments[0], pathSegments[1], pathSegments[2]);

            AuthorityType = AuthorityType.B2C;
        }

        protected override async Task<string> GetOpenIdConfigurationEndpointAsync(string userPrincipalName, RequestContext requestContext)
        {
            if (ValidateAuthority && !IsInTrustedHostList(new Uri(CanonicalAuthority).Host))
            {
                throw new ArgumentException(CoreErrorMessages.UnsupportedAuthorityValidation);
            }

            return await Task.Run(() => GetDefaultOpenIdConfigurationEndpoint()).ConfigureAwait(false);
        }
        
        internal override string GetTenantId()
        {
            return new Uri(CanonicalAuthority).Segments[2].TrimEnd('/');
        }

        internal override void UpdateTenantId(string tenantId)
        {
            Uri authorityUri = new Uri(CanonicalAuthority);
            var segments = authorityUri.Segments;

            var b2cPrefix = segments[1].TrimEnd('/');
            var b2cPolicy = segments[3].TrimEnd('/');

            CanonicalAuthority = string.Format(CultureInfo.InvariantCulture, B2CCanonicalAuthorityTemplate, 
                authorityUri.Authority, b2cPrefix, tenantId, b2cPolicy);
        }
    }
}
