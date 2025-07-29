using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.CQRS
{
    public interface ICommand : ICommand<Unit> //Unit từ MediatR nghĩa là "không có return value" (tương tự void)
    {
    }
    public interface ICommand<out TRespones> : IRequest<TRespones> 
    { 
    }
}
