﻿using FluentValidation;
using HomeApi.Contracts.Models.Rooms;

namespace HomeApi.Contracts.Validation
{
    /// <summary>
    /// Класс-валидатор запросов на добавление новой комнаты
    /// </summary>
    public class EditRoomRequestValidator : AbstractValidator<EditRoomRequest>
    {
        public EditRoomRequestValidator()
        {
            //RuleFor(x => x.NewArea).NotEmpty();
            //RuleFor(x => x.NewName).NotEmpty();
            //RuleFor(x => x.NewVoltage).NotEmpty();
            //RuleFor(x => x.GasConnected).NotEmpty();
        }
    }
}