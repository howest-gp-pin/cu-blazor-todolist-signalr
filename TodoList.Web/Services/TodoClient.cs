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
        public TodoClient()
        {
            connection = new HubConnectionBuilder()
               .WithUrl("https://localhost:5001/todohub")
               .Build();
        }

        public void Configure(Action<TodoItem> callback)
        {
            connection.On("RemoteItemAdded", callback);
        }

        public async Task Start()
        {
            await connection.StartAsync();
        }


        public async Task AddItem(TodoItem newItem)
        {
            await connection.SendAsync(nameof(TodoHub.AddTodo), newItem);
        }


    }
}
