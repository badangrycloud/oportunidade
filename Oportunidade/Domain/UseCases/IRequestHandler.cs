using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UseCases
{
    public interface IRequestHandler<in TRequest, out TResponse>
    {
        TResponse Handle(TRequest data);
    }
}
