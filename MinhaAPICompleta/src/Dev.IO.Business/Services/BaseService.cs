﻿using Dev.IO.Business.Interfaces;
using Dev.IO.Business.Models;
using Dev.IO.Business.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace Dev.IO.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificator _notificador;

        protected BaseService(INotificator notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notification(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }
}
