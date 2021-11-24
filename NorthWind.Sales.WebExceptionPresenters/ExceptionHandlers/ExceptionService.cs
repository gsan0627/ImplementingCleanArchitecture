using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NorthWind.Sales.WebExceptionPresenters.ExceptionHandlers
{
    public class ExceptionService
    {
        readonly Dictionary<Type, Type> _exceptionHandler = new Dictionary<Type, Type>();
        public ExceptionService()
        {
            Type[] types =
                Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in types)
            {
                var handlers = type.GetInterfaces()
                    .Where(i => 
                     i.IsGenericType &&
                     i.GetGenericTypeDefinition() == typeof(IExceptionHandler<>));

                foreach (Type handler in handlers)
                {
                    var exceptionType = handler.GetGenericArguments()[0];
                    _exceptionHandler.TryAdd(exceptionType, type);
                }
            }
        }

        public Task<ProblemDetails> Handle(Exception exception)
        {
            Task<ProblemDetails> result;

            if(_exceptionHandler.TryGetValue(exception.GetType(),
                out Type handlerType))
            {
                var handler = Activator.CreateInstance(handlerType);
                result = (Task<ProblemDetails>)handlerType.GetMethod(
                    nameof(IExceptionHandler<Type>.Handle))
                    .Invoke(handler,
                        new object[] { exception });
            }
            else
            {
                result = new GeneralExceptionHandler()
                    .Handle(new Entities.Exceptions.GeneralException(
                        "Ha ocurrido un error al procesar la respuesta",
                        "Consulte al administrador."));
            }

            return result;
        }

    }
}
