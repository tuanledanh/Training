﻿using MSIA.WebFresher052023.Domain.Interface;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;

namespace MSIA.WebFresher052023.Infrastructure.UnitOfWorks
{
    // Sealed có nghĩa là ngăn class khác kế thừa class này
    public sealed class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private readonly DbConnection _connection;
        private DbTransaction? _transaction = null;
        // { get; }
        public DbConnection Connection => _connection;
        // { get; }
        public DbTransaction? Transaction => _transaction;
        #endregion

        #region Constructor
        public UnitOfWork(string connectionString)
        {
            _connection = new MySqlConnection(connectionString);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Bắt đầu một giao dịch mới
        /// </summary>
        /// Created by: ldtuan (19/07/2023)
        public void BeginTransaction()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _transaction = _connection.BeginTransaction();
            }
            else
            {
                _connection.Open();
                _transaction = _connection.BeginTransaction();
            }
        }

        /// <summary>
        /// Bắt đầu một giao dịch mới (phiên bản bất đồng bộ)
        /// </summary>
        /// Created by: ldtuan (19/07/2023)
        public async Task BeginTransactionAsync()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _transaction = await _connection.BeginTransactionAsync();
            }
            else
            {
                await _connection.OpenAsync();
                _transaction = await _connection.BeginTransactionAsync();
            }
        }

        /// <summary>
        /// Lưu các thay đổi trong giao dịch và kết thúc
        /// </summary>
        /// Created by: ldtuan (19/07/2023)
        public void Commit()
        {
            _transaction?.Commit();
            Dispose();
        }

        /// <summary>
        /// Lưu các thay đổi trong giao dịch và kết thúc (phiên bản bất đồng bộ)
        /// </summary>
        /// Created by: ldtuan (19/07/2023)
        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
            }
            await DisposeAsync();
        }

        /// <summary>
        /// Giải phóng tài nguyên liên quan đến giao dịch và đóng kết nối cơ sở dữ liệu
        /// </summary>
        /// Created by: ldtuan (19/07/2023)
        public void Dispose()
        {
            _transaction?.Dispose();
            _transaction = null;
            _connection.Close();
        }

        /// <summary>
        /// Giải phóng tài nguyên liên quan đến giao dịch và đóng kết nối cơ sở dữ liệu (phiên bản bất đồng bộ)
        /// </summary>
        /// Created by: ldtuan (19/07/2023)
        public async ValueTask DisposeAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
            }
            _transaction = null;
            await _connection.CloseAsync();
        }

        /// <summary>
        /// Hoàn tác các thay đổi trong giao dịch và kết thúc
        /// </summary>
        /// Created by: ldtuan (19/07/2023)
        public void Rollback()
        {
            _transaction?.Rollback();
            Dispose();
        }

        /// <summary>
        /// Hoàn tác các thay đổi trong giao dịch và kết thúc (phiên bản bất đồng bộ)
        /// </summary>
        /// Created by: ldtuan (19/07/2023)
        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
            }
            await DisposeAsync();
        } 
        #endregion
    }
}
