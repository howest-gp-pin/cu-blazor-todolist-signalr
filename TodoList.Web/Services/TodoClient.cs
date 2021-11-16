using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using TodoList.Web.Domain;
using TodoList.Web.Hubs;

namespace TodoList.Web.Services
{
    public class TodoClient
    {
        protected HubConnection connection = null;
        protected Action<TodoItem> callback;

        public TodoClient(Action<TodoItem> callback)
        {
            this.callback = callback;

            connection = new HubConnectionBuilder()
               .WithUrl("https://localhost:5001/todohub")
               .Build();
        }

        public async Task Start()
        {
            connection.On("RemoteItemAdded", callback);

            await connection.StartAsync();
        }

        public async Task AddItem(TodoItem newItem)
        {
            await connection.SendAsync(nameof(TodoHub.AddTodo), newItem);
        }


    }
}
