﻿using CleanMVC.Domain.Entities;
using MediatR;

namespace CleanMVC.Application.Products.Commands
{
    public class ProductRemoveCommand : IRequest<Product>
    {
        public int Id { get; set; }

        public ProductRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
