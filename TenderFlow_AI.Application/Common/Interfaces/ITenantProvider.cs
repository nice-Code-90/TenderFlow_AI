using System;
using System.Collections.Generic;
using System.Text;

namespace TenderFlow_AI.Application.Common.Interfaces
{
    public interface ITenantProvider
    {
        Guid GetTenantId();
    }
}
