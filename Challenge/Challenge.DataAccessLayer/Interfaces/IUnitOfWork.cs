﻿namespace Challenge.DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }

        Task SaveChangesAsync();
    }
}